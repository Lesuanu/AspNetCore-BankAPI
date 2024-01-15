using Microsoft.AspNetCore.Identity;

namespace BankManagement.Auth
{
    public class BankAuthUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Email { get; set;}
        public string Password { get; set;}

    }
}
