using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository.LogsRepo
{
    public interface ILogsRepository 
    {
        Task<String> GetAllLogs(int id);
    }
}
