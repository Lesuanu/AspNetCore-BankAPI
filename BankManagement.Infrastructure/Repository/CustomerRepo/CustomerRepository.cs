using BankManagement.Infrastructure.Exceptions;
using BankManagement.Infrastructure.Models.BankCustomer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository.CustomerRepo
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankContext _bankContext;
        public CustomerRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public async Task<BankCustomer1> AddCustomer(BankCustomer1 employee)
        {
            await _bankContext.AddAsync(employee);
            await  _bankContext.SaveChangesAsync(); 

            return employee;    
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var employee = await _bankContext.BankCustomers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(employee != null)
            {
                _bankContext.BankCustomers.Remove(employee);
                await _bankContext.SaveChangesAsync();
            }
 
             return false;            
        }

        public async Task<IEnumerable<BankCustomer1>> GetAllCustomer()
        {
            return await _bankContext.BankCustomers.ToListAsync();
        }

        public async Task<BankCustomer1> GetAllCustomerById(int id)
        {
            var result = await  _bankContext.BankCustomers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(result == null)
            {
                throw new BankException($"Customer {result?.Username} with id {result?.Id} was not found");
            }
            return result!;
        }

        public async Task<BankCustomer1> GetAllCustomerByName(string name)
        {
            var result = await _bankContext.BankCustomers.Where(x => x.LastName == name).FirstOrDefaultAsync();
            if (string.IsNullOrEmpty(name))
            {
                throw new BankException($"Customer with id {result?.LastName} was not found");
            }
            return result!;
        }

        public async Task<BankCustomer1> UpdateCustomer(BankCustomer1 employee, int id)
        {
            var bankCustomer = await _bankContext.BankCustomers.FirstOrDefaultAsync(x => x.Id == id);

            if (bankCustomer != null)
            {
                _bankContext.Entry<BankCustomer1>(bankCustomer).CurrentValues.SetValues(employee);
            }

            return bankCustomer!;
        }
    }
}
