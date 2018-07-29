using AppCETN.Models;
using System.Collections.Generic;
using AppCETN.Infrastructure.Repositories;

namespace AppCETN.Services
{
    class CETNHombreService
    {
        /// <summary>
        /// No utilizado - Función de ejemplo
        /// Devuelve todos los hombres de un archivo de json en forma de lista.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Humano> GetAllHombresJSON()
        {
            var textJSON = (new HombreRepository()).GetAllJson();
            if (string.IsNullOrEmpty(textJSON)) return null;

            IEnumerable<Humano> ListaHombres = JsonService.Deserializar<IEnumerable<Hombre>>(textJSON);
            return ListaHombres;
        }
    }
}
