using System.Collections.Generic;
using AppCETN.Models;
using Newtonsoft.Json.Linq;

namespace AppCETN.Infrastructure.Repositories
{
    interface IMujerRepository
    {
        IEnumerable<Mujer> GetAll();
        JObject GetAllJson();
        void InsertMujerJSON(object data);
    }
}
