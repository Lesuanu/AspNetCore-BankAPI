using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Models.BankEmployee
{
    public class BankEmployeeImage
    {
        public int Id { get; set; }
        public IFormFile? File { get; set; }
        public string ImageName { get; set; } = string.Empty; 
    }
}
