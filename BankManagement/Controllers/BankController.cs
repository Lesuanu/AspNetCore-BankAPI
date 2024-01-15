using BankManagement.Infrastructure.Models.BankEmployee;
using BankManagement.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BankManagement.Infrastructure.Repository;
using System.Collections.Generic;

namespace BankManagement.Controllers
{
    [Route("bankemployees")]
    public class BankController : Controller
    {
        public BankController()
        {

        }
    }
}
