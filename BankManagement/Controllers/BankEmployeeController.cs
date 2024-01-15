using BankManagement.Infrastructure.Models.BankEmployee;
using BankManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BankManagement.Controllers
{
    [Route("bankemployees")]
    public class BankEmployeeController : ControllerBase
    {
        private readonly IBankRepository _bankRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BankEmployeeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BankEmployeeController(IBankRepository bankRepository,
            IUnitOfWork unitOfWork, ILogger<BankEmployeeController> logger)
        {
            _bankRepository = bankRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
           // _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("get-employees")]
        public async Task<IEnumerable<BankEmployee1>> GetAllEmployee()
        {
            var bankCustomers = await _bankRepository.GetAllEmployee();
            return bankCustomers;
        }

        [HttpGet("get-employee")]
        public async Task<BankEmployee1> GetBankEmployee(int id)
        {
            var employee = await _bankRepository.GetAllEmployeeById(id);
            return employee;
        }

        [HttpPost("add-employee")]
        public async Task<BankEmployee1> AddEmployee([FromBody] BankEmployee1 bankEmployee)
        {
             _logger.LogInformation("this is a bug");
            var employeeAdd = await _bankRepository.AddEmployee(bankEmployee);
            return employeeAdd;
        }

        [HttpDelete("delete-employee")]
        public Task<bool> RemoveEmployee(int id)
        {
            return _bankRepository.DeleteEmployee(id);
        }

        [HttpPatch("update-employee")]
        public async Task<BankEmployee1> UpdateEmployee(BankEmployee1 bankEmployee, int id)
        {
            var employeeUpdate = await _bankRepository.UpdateEmployee(bankEmployee, id);
            return employeeUpdate;
        }
         
        [HttpPost("upload")]
        public async
            Task<string> Upload([FromForm] BankEmployeeImage image)
        {
            if(image.File.Length > 0)
            {
                try
                {
                    if(!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\" + image.File.FileName))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
                    }

                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images\\" + image.File.FileName))
                    {
                        image.File.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Images\\" + image.File.FileName;
                    }
                }
                catch(Exception ex) 
                {
                    return ex.Message;
                }
            }
            else
            {
                return "image upload failed";
            }
        }
    }
}
