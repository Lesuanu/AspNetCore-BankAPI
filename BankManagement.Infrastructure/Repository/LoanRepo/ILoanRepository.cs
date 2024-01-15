using BankManagement.Infrastructure.Models.BankCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository.LoanRepo
{
    public interface ILoanRepository
    {
        Task GetLoan(int id);
        Task RejectLoan(int id);
        Task TransferLoan(int id, BankLoan bankLoan);
    }
}
