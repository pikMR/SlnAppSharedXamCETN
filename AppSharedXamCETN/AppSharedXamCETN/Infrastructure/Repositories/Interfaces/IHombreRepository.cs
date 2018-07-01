using AppCETN.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCETN.Infrastructure.Repositories
{
    interface IHombreRepository
    {
        Task<IEnumerable<Hombre>> GetAll();
        JObject GetAllJson();
    }
}
