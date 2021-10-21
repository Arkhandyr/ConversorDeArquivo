using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ConversorDeArquivo
{
    class JsonConfig
    {
        protected const string pathAppConfig = "appsettings.json";
        public static JObject AppConfig => JObject.Parse(File.ReadAllText(pathAppConfig));
        public static string In_TXT => AppConfig[nameof(In_TXT)].ToString();
        public static string Out_PDF => AppConfig[nameof(Out_PDF)].ToString();
    }
}
