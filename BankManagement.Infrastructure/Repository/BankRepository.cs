using BankManagement.Infrastructure.Models.BankEmployee;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly BankContext _bankContext;  
        public BankRepository(BankContext bankContext)
        {
            _bankContext = bankContext; 
        }
        public async Task<BankEmployee1> AddEmployee(BankEmployee1 employee)
        {
             await _bankContext.BankEmployees.AddAsync(employee);
             await _bankContext.SaveChangesAsync();
            
             return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employeeToDel = await _bankContext.BankEmployees.
                                            Include(x => x.BankEmployeeSalary).Where(x => x.BankEmployee1Id == id).FirstOrDefaultAsync();
            if (employeeToDel is null)
            {
                return false;
            }
      
            _bankContext.BankEmployees.Remove(employeeToDel);
            await _bankContext.SaveChangesAsync();  
            
            return true;
        }

        public async Task<IEnumerable<BankEmployee1>> GetAllEmployee()
        {
            return  await _bankContext.BankEmployees.
                                    Include(x => x.BankEmployeeSalary).ToListAsync();
        }

        public async Task<BankEmployee1> GetAllEmployeeById(int id)
        {
            var result =  await _bankContext.BankEmployees.FirstOrDefaultAsync(x => x.BankEmployee1Id == id);
            if(result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
            
        }

        public Task<BankEmployee1> GetAllEmployeeByName(string firstName)
        {
            var result = _bankContext.BankEmployees.Where(x => x.FirstName == firstName);
            
            return (Task<BankEmployee1>)result;
        }

        public async Task<BankEmployee1?> UpdateEmployee(BankEmployee1 employee, int id)
        {
            var productResult = await _bankContext.BankEmployees
                                                             .FirstOrDefaultAsync(e => e.BankEmployee1Id == id);
            if (productResult is not null)
            {
                _bankContext.Entry<BankEmployee1>(productResult).CurrentValues.SetValues(employee);
                await _bankContext.SaveChangesAsync();
            }
            return productResult;
        }
    }
}
