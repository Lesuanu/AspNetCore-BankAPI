using System;
using System.ComponentModel.DataAnnotations;

namespace BankManagement.Auth.Service
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
