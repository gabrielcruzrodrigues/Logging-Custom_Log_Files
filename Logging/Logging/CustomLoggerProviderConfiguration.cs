namespace Logging.Logging
{
    public class CustomLoggerProviderConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning; //define o nível mínimo de log a ser registrado
        public int EventId { get; set; } = 0; //define o ID do evento de log, com o padrão sendo zero
    }
}
