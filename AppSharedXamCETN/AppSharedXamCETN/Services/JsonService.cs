using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppCETN.Services
{
    public class JsonService
    {
        public static T Deserializar<T>(JObject json)
        {
            return JsonConvert.DeserializeObject<T>(json.ToString());
        }

        public static string Generar(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
