using BankManagement.Infrastructure.Models.BankCustomer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository.GenericRepository
{
    public class GenericBankRepository<T> : IGenericBankReposiory<T> where T : class
    {
        private readonly BankContext _context;
        //private readonly DbSet<T> _entities;

        public GenericBankRepository(BankContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
           // _entities = context.Set<T>();
        }

        public T AddEmployee(T entity)
        {
            var result = _context.Set<T>().Add(entity);
            return result as T;
        }

        public bool DeleteEmployee(T id)
        {
           var result =  _context.Set<T>().Remove(id);
            if (result is T)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<T> GetAllEmployee()
        {
            var result = _context.Set<T>().ToList();
            return result;
        }

        public T GetEmployeeById(int id)
        {
            var result = _context.Set<T>().Find(id);
            return result;
        }

        public T UpdateEmployee(T employee)
        {
           var result = _context.Set<T>().Update(employee);
            return result as T;
        }
    }
}
