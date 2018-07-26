using AppCETN.Models;
using System.Collections.Generic;
using AppCETN.Infrastructure.Repositories;
using System.Threading.Tasks;
using AppSharedXamCETN.Infrastructure.Repositories;

namespace AppCETN.Services
{
    class CETNHombreService
    {
        /// <summary>
        /// Devuelve todos los hombres de un archivo de json en forma de lista.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Humano> GetAllHombresJSON()
        {
            var textJSON = (new HumanoRepository()).GetAllJson();
            if (string.IsNullOrEmpty(textJSON)) return null;

            IEnumerable<Humano> ListaHombres = JsonService.Deserializar<IEnumerable<Humano>>(textJSON);
            return ListaHombres;
        }

        internal static async Task<bool> InsertHombreJSON(object data)
        {
            string strJSON = JsonService.Generar(data);
            return await (new HombreRepository()).InsertHombreJSON(strJSON);
        }

        public static IEnumerable<Hombre> GetAllHombres()
        {
            return null;
        }
    }
}
