using AppCETN.Models;
using System.Collections.Generic;
using AppCETN.Infrastructure.Repositories;
using System;

namespace AppCETN.Services
{
    class CETNHombreService
    {
        /// <summary>
        /// Devuelve todos los hombres de un archivo de json en forma de lista.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Hombre> GetAllHombresJSON()
        {
            Newtonsoft.Json.Linq.JObject json = (new HombreRepository()).GetAllJson();
            IEnumerable<Hombre> ListaHombres = JsonService.Deserializar<IEnumerable<Hombre>>(json);
            return ListaHombres;
        }

        internal static void InsertHombreJSON(object data)
        {
            string strJSON = JsonService.Generar(data);
            (new HombreRepository()).InsertHombreJSON(strJSON);
        }

        public static IEnumerable<Hombre> GetAllHombres()
        {
            return null;
        }
    }
}
