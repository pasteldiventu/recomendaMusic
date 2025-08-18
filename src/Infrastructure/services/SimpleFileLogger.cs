using System.Text;

namespace Infrastructure.Services
{
    // Esta classe implementa o padrão Singleton através do ciclo de vida da Injeção de Dependência
    public class SimpleFileLogger
    {
        private readonly string _logFilePath = "log.txt";

        public void Log(string message)
        {
            try
            {
                using (var writer = new StreamWriter(_logFilePath, true, Encoding.UTF8))
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                }
            }
            catch (Exception ex)
            {
                // Em um logger real, teríamos uma política de fallback. Aqui, apenas ignoramos.
                Console.WriteLine($"Erro ao escrever no log: {ex.Message}");
            }
        }
    }
}