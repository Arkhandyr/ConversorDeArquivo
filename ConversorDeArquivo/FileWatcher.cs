using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace ConversorDeArquivo
{
    public class FileWatcher
    {
        private static ILogger<Worker> Logger;

        public static void Iniciar(ILogger<Worker> _logger)
        {
            Logger = _logger;
            VerificarDiretorios();
        }

        private static void VerificarDiretorios()
        {
            var watcher = new FileSystemWatcher(JsonConfig.In_TXT);

            watcher.Created += new FileSystemEventHandler(OnCreated);

            watcher.IncludeSubdirectories = false;

            watcher.EnableRaisingEvents = true;

            Logger.LogInformation("Verificou o diretório {diretorio}: ", JsonConfig.In_TXT);
        }

        private static void OnCreated(object sender, FileSystemEventArgs txt)
        {
            Logger.LogInformation("OnCreated chamado com arquivo : {arquivo.FullPath}", txt.FullPath);

            Task.Run(() => ConversorPDF.GerarPDF(new FileStream(txt.FullPath, FileMode.Open, FileAccess.Read, FileShare.Read)));
        }
    }
}
