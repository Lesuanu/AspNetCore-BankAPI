﻿using BankManagement.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BankManagement.Auth.ApiKey
{
    public class ApiKeyAuthenticationHandler :  AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string API_KEY_HEADER = "Api-Key";

        private readonly BankContext _context;

        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            BankContext context
        ) : base(options, logger, encoder, clock)
        {
            _context = context;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //if (!Request.Headers.ContainsKey(API_KEY_HEADER))
            //{
            //    return AuthenticateResult.Fail("Header Not Found.");
            //}

            //string apiKeyToValidate = Request.Headers[API_KEY_HEADER];

            //var apiKey = await _context.UserApiKeys
            //    .Include(uak => uak.User)
            //    .SingleOrDefaultAsync(uak => uak.Value == apiKeyToValidate);

            //if (apiKey == null)
            //{
            //    return AuthenticateResult.Fail("Invalid key.");
            //}

            //return AuthenticateResult.Success(CreateTicket(apiKey.User));
            return null;
        }

        private AuthenticationTicket CreateTicket(IdentityUser user)
        {
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return ticket;
        }
    }
}
