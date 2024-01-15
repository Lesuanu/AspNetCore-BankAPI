using BankManagement.Infrastructure.Models.BankCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository.LoanRepo
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BankContext _bankContext;
        public LoanRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public Task GetLoan(int id)
        {
            var result = _bankContext.BankLoan.Where(x => x.Id == id);
            return Task.FromResult(result);
        }

        public Task RejectLoan(int id)
        {
            var result = _bankContext.BankLoan.Where(x => x.Id != id);
            return Task.FromResult(result);
        }

        public Task TransferLoan(int id, BankLoan bankLoan)
        {
            throw new NotImplementedException();
        }
    }
}
