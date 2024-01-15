using BankManagement.Auth;
using BankManagement.Auth.ApiKey;
using BankManagement.Auth.RegisterModel;
using BankManagement.Auth.Roles;
using BankManagement.Auth.Service;
using BankManagement.Infrastructure;
using BankManagement.Infrastructure.Repository;
using BankManagement.Infrastructure.Repository.LogsRepo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddControllers().AddJsonOptions(x =>
            // x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BankManagement", Version = "v1" });
            });
            services.AddDbContext<BankContext>(options =>
                                        options.UseSqlServer(Configuration.GetConnectionString("BankDbConnection"),
                                         b => b.MigrationsAssembly("BankManagement")));

           // services.AddHostedService<LogsBackgroundService>();
            services.AddIdentity<BankAuthUser, UserRoles>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
             .AddEntityFrameworkStores<BankContext>()
             .AddDefaultTokenProviders();

           // services.AddHttpLogging();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<JwtService>();
            services.AddControllers();
            services.AddCookiePolicy(options => { });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = Configuration["Jwt:ValidAudience"],
                        ValidIssuer = Configuration["Jwt:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])
                        )
                    };
                })
                 .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>(
                        "ApiKey",
                         options => { }
                  );

            services.AddAuthorization(options => {
                options.AddPolicy("RequireManagementRole", policy => policy.RequireRole("Administrator"));

                options.AddPolicy("Withdrawal Limit at 60000", policy => policy.Requirements.Add(new WithDrawalLimitRequirememt(90000)));
            });
            services.AddSingleton<IAuthorizationHandler, WithdrawalLimitHandler>();
            services.AddSingleton<IAuthorizationHandler, WWithdrawalLimiAuthorizationHandler>();
            //[Authorize(Roles = "")]
            //[Authorize(Policy = "")]

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                    .SetIsOriginAllowed(origin => true)
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BankManagement v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

           // app.UseHttpLogging();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class WWithdrawalLimiAuthorizationHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
