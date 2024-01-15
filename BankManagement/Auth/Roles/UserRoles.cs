using Microsoft.AspNetCore.Identity;
using System;
using System.Data;

namespace BankManagement.Auth.Roles
{
    public class UserRoles : IdentityRole
    {
        public const string Customer = "Customer";
        public const string Employee = "Employee";


    }

    public static class UserRoleVerification
    {
        public static string CheckRoles(UserRoles userRoles) => userRoles switch
        {
           
        };
     
      
    }
  

}
