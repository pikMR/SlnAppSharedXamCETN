using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCETN.Models;

[assembly: Xamarin.Forms.Dependency(typeof(AppCETN.Services.MockDataStore))]
namespace AppCETN.Services
{
    public class MockDataStore : IDataStore<Humano>
    {
        public List<Humano> Items;
        //public static string JSON { get; set; }
        public MockDataStore()
        {
            if (Items == null)
            {
                var instanciaOjos = CETNDomainService.ObtenerValoresOjos();
                var instanciaCabello = CETNDomainService.ObtenerValoresCabello();
                var instanciaPecho = CETNDomainService.ObtenerValoresPecho();
                var instanciaCulo = CETNDomainService.ObtenerValoresNalgas();
                var instanciaFisio = CETNDomainService.ObtenerValoresFisionomia();
                var instanciaprenda1 = CETNDomainService.ObtenerValoresPrendaSup();
                var instanciaprenda2 = CETNDomainService.ObtenerValoresPrendaInf();
                Items = new List<Humano>();
                var mockItems = CETNDomainService.GetAllHombresJSON();

                if (mockItems != null)
                {
                    foreach (var item in mockItems)
                    {
                        Items.Add(item);
                    }
                }
            }
            //JSON = JsonService.Generar(Items);
        }

        internal void UpdateData(Humano item)
        {
            var _item = Items.Where(e=>e.IdEntidad == item.IdEntidad).FirstOrDefault();
            Items.Remove(_item);
            Items.Add(item);
        }

        public async Task<bool> AddItemAsync(Humano item)
        {
            Items.Add(item);
            return await Task.FromResult(true);
        }

        public  async Task<bool> UpdateItemAsync(Humano item)
        {
            var _item = Items.Where((Humano arg) => arg.Apodo == item.Apodo).FirstOrDefault();
            Items.Remove(_item);
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var _item = Items.Where((Humano arg) => arg.IdEntidad == id).FirstOrDefault();
            Items.Remove(_item);
            return await Task.FromResult(true);
        }

        public async Task<Humano> GetItemAsync(string id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.IdEntidad.ToString() == id));
        }

        public async Task<IEnumerable<Humano>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }
    }
}