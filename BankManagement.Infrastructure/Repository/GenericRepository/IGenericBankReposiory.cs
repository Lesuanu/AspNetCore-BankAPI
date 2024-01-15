using BankManagement.Infrastructure.Models.BankEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository.GenericRepository
{
    public interface IGenericBankReposiory<T>
    {
        IEnumerable<T> GetAllEmployee();
        T GetEmployeeById(int id);
        T AddEmployee(T entity);  
        bool DeleteEmployee(T id);
        T UpdateEmployee(T employee);
    }
}
