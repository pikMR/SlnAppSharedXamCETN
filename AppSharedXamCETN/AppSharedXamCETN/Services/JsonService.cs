using Newtonsoft.Json;

namespace AppCETN.Services
{
    public class JsonService
    {
        private static string JSONfinal = null;
        public static T Deserializar<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string Generar(object obj)
        {
            JSONfinal = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return JSONfinal;
        }
    }
}
