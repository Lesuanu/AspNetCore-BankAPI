using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository.LogsRepo
{
    public class LogsRepository : ILogsRepository
    {
        private readonly IBankRepository bankRepository;
        private readonly BankContext context;

        public LogsRepository(IBankRepository bankRepository, BankContext context)
        {
            this.bankRepository = bankRepository;
            this.context = context;
        }

        public async Task<string> GetAllLogs(int id)
        {
            var employee = await bankRepository.GetAllEmployeeById(id);

            //context.BankLogs.

            return "";
        }
    }
}
