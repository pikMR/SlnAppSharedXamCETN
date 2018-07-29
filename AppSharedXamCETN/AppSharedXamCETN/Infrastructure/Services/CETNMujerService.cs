using AppCETN.Infrastructure.Repositories;
using AppCETN.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppCETN.Services
{
    class CETNMujerService
    {
        /// <summary>
        /// No utilizado - Función de ejemplo
        /// Devuelve todas las mujeres de un archivo de json en forma de lista.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Humano> GetAllMujeresJSON()
        {
            var textJSON = (new HombreRepository()).GetAllJson();
            if (string.IsNullOrEmpty(textJSON)) return null;

            IEnumerable<Humano> ListaHombres = JsonService.Deserializar<IEnumerable<Mujer>>(textJSON);
            return ListaHombres;
        }
    }
}
