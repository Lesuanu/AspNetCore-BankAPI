using System.ComponentModel.DataAnnotations;

namespace BankManagement.Auth.RegisterModel
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }   
        public string Password { get; set; } 
        public string Email { get; set; }
    }
}
