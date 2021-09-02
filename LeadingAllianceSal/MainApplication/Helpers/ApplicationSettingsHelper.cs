using MainApplication.Configs.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MainApplication.Helpers
{
    public static class ApplicationSettingsHelper
    {
        public static T GetModelFromJsonFile<T>(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly(); //   .GetAssembly(typeof(StakeFactorIntegrationModel));
            var obj = Deserialize<T>(fileName, assembly);
            return obj;
        }

        public static T Deserialize<T>(string fileName, Assembly assembly)
        {
            var file = assembly.GetManifestResourceNames().First(res => res.Contains(fileName));
            return JsonConvert.DeserializeObject<T>(ReadFromAssembly(file, assembly));
        }

        public static string ReadFromAssembly(string fileName, Assembly assembly)
        {
            using (Stream stream = ResourceStream(fileName, assembly))
            {
                using (StreamReader s = new StreamReader(stream))
                {
                    if (s == null)
                        throw new FileNotFoundException(string.Format($"{fileName} not found"));
                    else
                        return s.ReadToEnd();
                }
            }
        }

        public static Stream ResourceStream(string fileName, Assembly assembly)
        {
            return assembly.GetManifestResourceStream(fileName);
        }
    }
}
