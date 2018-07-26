using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppCETN.Models;
using Newtonsoft.Json.Linq;

namespace AppCETN.Infrastructure.Repositories
{
    class MujerRepository : IMujerRepository
    {
        public IEnumerable<Mujer> GetAll()
        {
            throw new NotImplementedException();
        }

        public JObject GetAllJson()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertMujerJSON(object data)
        {
            return await Task.FromResult(true);
        }
        void IMujerRepository.InsertMujerJSON(object data)
        {

        }
    }
}
