using BankManagement.Infrastructure.Models.BankEmployee;
using System.Collections.Generic;

namespace BankManagement.Infrastructure.Repository
{
    public interface IBankRepository
    {
        Task<IEnumerable<BankEmployee1>> GetAllEmployee();
        Task<BankEmployee1> GetAllEmployeeByName(string id);
        Task<BankEmployee1> GetAllEmployeeById(int id);
        Task<bool> DeleteEmployee(int id);
        Task<BankEmployee1> UpdateEmployee(BankEmployee1 employee, int id);
        Task<BankEmployee1> AddEmployee(BankEmployee1 employee);    
    }
}
