using BankManagement.Infrastructure.Models.BankCustomer;
using BankManagement.Infrastructure.Models.BankEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository.CustomerRepo
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<BankCustomer1>> GetAllCustomer();
        Task<BankCustomer1> GetAllCustomerByName(string id);
        Task<BankCustomer1> GetAllCustomerById(int id);
        Task<bool> DeleteCustomer(int id);
        Task<BankCustomer1> UpdateCustomer(BankCustomer1 employee, int id);
        Task<BankCustomer1> AddCustomer(BankCustomer1 employee);
    }
}
