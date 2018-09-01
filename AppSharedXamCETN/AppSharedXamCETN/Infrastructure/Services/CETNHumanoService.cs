using AppCETN.Models;
using AppCETN.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCETN.Services
{
    class CETNHumanoService
    {
        internal static async Task<bool> GenerarHumanoJSON(object data)
        {
            string strJSON = JsonService.Generar(data);
            return await (new HumanoRepository()).GenerarHumanoJSON(strJSON);
        }

        /// <summary>
        /// Devuelve todos los humanos de un archivo de json en forma de lista.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Humano> GetAllHombresJSON()
        {
            var textJSON = (new HumanoRepository()).GetAllJson();
            if (string.IsNullOrEmpty(textJSON)) return null;

            try
            {
                return JsonService.Deserializar<IEnumerable<Humano>>(textJSON);
            }
            catch (System.Exception)
            {
                return new List<Humano>();
            }
        }
    }
}
