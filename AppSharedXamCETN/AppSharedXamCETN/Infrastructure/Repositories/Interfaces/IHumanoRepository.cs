using System.Threading.Tasks;

namespace AppCETN.Infrastructure.Repositories
{
    interface IHumanoRepository
    {
            Task<bool> GenerarHumanoJSON(string data);
            string GetAllJson();
    }
}
