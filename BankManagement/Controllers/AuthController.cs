using BankManagement.Auth;
using BankManagement.Auth.ApiKey;
using BankManagement.Auth.LoginModel;
using BankManagement.Auth.RegisterModel;
using BankManagement.Auth.Roles;
using BankManagement.Auth.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Controllers
{
    [Route("users")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<BankAuthUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration config;
        private readonly JwtService _jwtService;
        private readonly ApiKeyService _apiKeyService;
        public AuthController(UserManager<BankAuthUser> userManager, JwtService jwtService, ApiKeyService apiKeyService,
                                RoleManager<IdentityRole> roleManager, IConfiguration configuration )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            config = configuration;
            _jwtService = jwtService;
            _apiKeyService = apiKeyService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var userClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach(var userRole in userRoles)
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var bankUserSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));

                var token = new JwtSecurityToken(
                    issuer: config["Jwt:ValidIssuer"],
                    audience: config["jwt:ValidAudience"],
                    expires: DateTime.Now.AddHours(9),
                    claims: userClaims,
                    signingCredentials: new SigningCredentials(bankUserSignInKey, SecurityAlgorithms.HmacSha256));

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            
            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterViewModelResponse>> CreateUserAsync(RegisterViewModel model)
        { 
            if (!ModelState.IsValid)
            {
                return null;
            }
            var result = await _userManager.CreateAsync(new BankAuthUser { UserName = model.UserName, Email = model.Email },
                        model.Password);
            if(!result.Succeeded) 
            {
                return BadRequest();
            }
            // model.Password = null;
            return new RegisterViewModelResponse
            {
                Success = "Success",
                Message = "User Created Successfully"
            };
        }

        [HttpPost("regiter-role")]
        public async Task<IActionResult> RegisterWithRoles([FromBody] RegisterViewModel model, string role)
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                        new RegisterViewModelResponse { Message = "User already Exist" });
            }
            var validUser = await _userManager.CreateAsync(new BankAuthUser { UserName = model.UserName, Email = model.Email },
                        model.Password);

            if(!validUser.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                        new RegisterViewModelResponse { Message = "User creation failed" });
            }
  
            if (!await _roleManager.RoleExistsAsync(UserRoles.Customer))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));

                await _userManager.AddToRoleAsync(user, UserRoles.Customer);           
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Employee))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));

                await _userManager.AddToRoleAsync(user, UserRoles.Employee);
            }

            return Ok();

        }
       
        [HttpGet("{username}")]
        public async Task<ActionResult<RegisterViewModel>> GetUsersAsync(string username)
        {
           var result =  await _userManager.FindByNameAsync(username);   
           if(result == null)
            {
                return NotFound();
            }
            return new RegisterViewModel
            {
                UserName = $"{result.UserName} with {result.Email}with not found",
                Email = result.Email,
            };
        }

        [HttpPost("token")]
        public async Task<ActionResult<AuthResponse>> GenerateToken(AuthRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Error");
            }
            var user = await _userManager.FindByNameAsync (request.UserName);
            if(user == null)
            {
                return BadRequest("Error");
            }
            var validPassword = await _userManager.CheckPasswordAsync(user, request.Password);  
            if (!validPassword)
            {
                return BadRequest("Error");
            }
            var token = _jwtService.CreateToken(user);
            return Ok(token);
        }


        [HttpPost("ApiKey")]
        public async Task<ActionResult> CreateApiKey(AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var token = _apiKeyService.CreateApiKey(user);

            return Ok(token);
        }
    }
}
