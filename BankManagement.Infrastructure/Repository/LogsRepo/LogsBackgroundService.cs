using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository.LogsRepo
{
    public class LogsBackgroundService : IHostedService
    {
        private readonly IBankRepository _bankRepository;
        public ILogger<LogsBackgroundService> _logger;
        public IServiceProvider Services { get; }

        public LogsBackgroundService(IBankRepository bankRepository, ILogger<LogsBackgroundService> logger, IServiceProvider services)
        {
            _bankRepository = bankRepository;
            _logger = logger;
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<BankContext>();

               // await scopedProcessingService.DoWork(stoppingToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class LogsInterceptors : DbCommandInterceptor
    {

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            //if(command.CommandType.HasFlag())
            //if (command.Transaction.SaveAsync(command.) { }
            return base.ReaderExecuted(command, eventData, result);
        }
    }
}
