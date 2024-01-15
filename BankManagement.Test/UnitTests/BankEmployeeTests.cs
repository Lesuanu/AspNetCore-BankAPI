using BankManagement.Controllers;
using BankManagement.Infrastructure;
using BankManagement.Infrastructure.Models.BankEmployee;
using BankManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankManagement.Test.UnitTests
{
    public  class BankEmployeeTests
    {
        public Mock<IBankRepository> _mockRepo;
        public Mock<IUnitOfWork> _mockUnitOfWork;
        public Mock<ILogger<BankEmployeeController>> _mockLogger;

        public BankEmployeeController _Controller;
        public BankEmployeeTests()
        {
            _mockLogger = new Mock<ILogger<BankEmployeeController>>();   
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockRepo = new Mock<IBankRepository>();
            _Controller = new BankEmployeeController(_mockRepo.Object, _mockUnitOfWork.Object, _mockLogger.Object);
        }

        [Fact]
        public async void GetAllEmployee_Null_ReturnsListofEmployees()
        {
            _mockRepo.Setup(x => x.GetAllEmployee())
                .ReturnsAsync(new List<BankEmployee1>() { new BankEmployee1 { }, new BankEmployee1 { } });

            var result = await _Controller.GetAllEmployee();

            var emp = Assert.IsType<List<BankEmployee1>>(result);

            Assert.Equal(2, emp.Count);
        }
    }
}
