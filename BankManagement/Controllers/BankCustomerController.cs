using BankManagement.Infrastructure;
using BankManagement.Infrastructure.Models.BankEmployee;
using BankManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.Controllers
{
    [Route("bankcustomers")]
    public class BankCustomerController : ControllerBase
    {
        private readonly ILogger<BankCustomerController> _logger;

        public BankCustomerController()
        {

        }
    }
    
     
    
}
