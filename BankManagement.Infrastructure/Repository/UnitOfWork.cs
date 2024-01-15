using BankManagement.Infrastructure.Models.BankEmployee;
using BankManagement.Infrastructure.Repository.GenericRepository;

namespace BankManagement.Infrastructure.Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly BankContext _bankContext;

        public GenericBankRepository<BankEmployee1> _bankRepository;
        public GenericBankRepository<BankEmployee1> BankRepository
        {
            get
            {
                this._bankRepository ??= new GenericBankRepository<BankEmployee1>(_bankContext);
                return _bankRepository;
            }
        }

        public UnitOfWork(BankContext bankContext)
        {
            _bankContext = bankContext ?? throw new ArgumentNullException(nameof(bankContext));
        }
        public Task SaveChangesAsync()
        {
            _bankContext.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
