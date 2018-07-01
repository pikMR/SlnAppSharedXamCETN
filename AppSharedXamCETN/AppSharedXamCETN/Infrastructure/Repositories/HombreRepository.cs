using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppCETN.Models;
using Newtonsoft.Json.Linq;

namespace AppCETN.Infrastructure.Repositories
{
    class HombreRepository : IHombreRepository
    {

        /// <summary>
        ///  Devuelve todos los usuarios Hombres en db
        /// </summary>
        /// <returns></returns>
        IEnumerable<Hombre> GetAll()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Devuelve todos los usuarios Hombres
        /// Implementación para base de datos con db async
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Hombre>> IHombreRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        public JObject GetAllJson()
        {
            throw new System.NotImplementedException();
        }

        internal void InsertHombreJSON(string strJSON)
        {
            // obtiene el archivo, e inserta el contenido del json,
            // si no existe el archivo lo crea e introduce el json.
            throw new NotImplementedException();
        }

    }
}
