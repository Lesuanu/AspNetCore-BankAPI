using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Identity;

namespace BankManagement.Auth.Service
{
    public interface IJwtService
    {
        JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration);
        Claim[] CreateClaims(IdentityUser user);
        SigningCredentials CreateSigningCredentials();
        AuthResponse CreateToken(IdentityUser user);
    }
}
