using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Activos.Infrastructure.Utils
{
    public class ConvertToJson
    {
        public static string Serialize<T>(T obj)
        {
            var configuracion = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var result = JsonConvert.SerializeObject(obj, configuracion);
            return result;
        }
    }
}
