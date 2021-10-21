using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConversorDeArquivo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            FileWatcher.Iniciar(logger);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Horário: {time}", DateTimeOffset.Now);
                _logger.LogInformation("Nº Threads: {threads}", Process.GetCurrentProcess().Threads.Count);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
