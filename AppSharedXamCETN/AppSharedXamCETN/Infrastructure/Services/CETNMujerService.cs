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
        /// Devuelve todos los hombres de un archivo de json en forma de lista.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Mujer> GetAllMujeresJSON()
        {
            Newtonsoft.Json.Linq.JObject json = (new MujerRepository()).GetAllJson();
            IEnumerable<Mujer> ListaHombres = JsonService.Deserializar<IEnumerable<Mujer>>(json.ToString());
            return ListaHombres;
        }

        internal static async Task<bool> InsertMujerJSON(object data)
        {
            string strJSON = JsonService.Generar(data);
            return await (new MujerRepository()).InsertMujerJSON(strJSON);
        }
    }
}
