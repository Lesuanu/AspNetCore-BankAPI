using BankManagement.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;

namespace BankManagement.Auth.ApiKey
{
    public class ApiKeyService
    {
        private readonly BankContext _context;

        public ApiKeyService(BankContext context)
        {
            _context = context;
        }

        public ApiKeyModel CreateApiKey(IdentityUser user)
        {
            var newApiKey = new ApiKeyModel
            {
                User = user,
                Value = GenerateApiKeyValue()
            };

          //Todo -  _context.UserApiKeys.Add(newApiKey);

            _context.SaveChanges();

            return newApiKey;
        }

        private string GenerateApiKeyValue() =>
            $"{Guid.NewGuid().ToString()}-{Guid.NewGuid().ToString()}";
    }
}

