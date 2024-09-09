
using System.IO;

namespace Logging.Logging
{
    public class CustomerLogger : ILogger
    {
        readonly string loggerName;
        readonly CustomLoggerProviderConfiguration loggerConfig;

        public CustomerLogger(string name, CustomLoggerProviderConfiguration config)
        {
            this.loggerName = name;
            this.loggerConfig = config;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel) //verifica se o nível do log que será escrito esta permitido nas configurações
        {
            return logLevel == loggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";
            ToWriteOnFile(message);
        }

        private void ToWriteOnFile(string message)
        {
            string pathFileLog = @"c:\logs\arquivo_de_logs.txt";
            using (StreamWriter streamWriter = new StreamWriter(pathFileLog, true))
            {
                try
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
                catch(Exception)
                {
                    throw;
                }
            }

        }
    }
}
