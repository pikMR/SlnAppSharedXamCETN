using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppCETN.Models;

[assembly: Xamarin.Forms.Dependency(typeof(AppCETN.Services.MockDataStore))]
namespace AppCETN.Services
{
    public class MockDataStore : IDataStore<Humano>
    {
        //public static List<Humano> Items;
        public List<Humano> Items;
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

                var mockItems = new List<Humano>
            {
                new Hombre
                {
                IdEntidad = 1,
                Nombre = "Manuel" , Descripcion = "Mecánico",
                Ojo = instanciaOjos[2],
                Pelo = instanciaCabello[2],
                Pecho = instanciaPecho[1],
                Culo = instanciaCulo[2],
                Fisionomia = instanciaFisio[0],
                Prenda1 = instanciaprenda1[3],
                Prenda2 = instanciaprenda2[0]
                },
                new Mujer {
                IdEntidad = 2,
                Nombre = "Maria" , Descripcion = "Ejecutiva",
                Ojo = instanciaOjos[1],
                Pelo = instanciaCabello[3],
                Pecho = instanciaPecho[0],
                Culo = instanciaCulo[0],
                Fisionomia = instanciaFisio[0],
                Prenda1 = instanciaprenda1[2],
                Prenda2 = instanciaprenda2[0]
                },
                new Hombre {
                IdEntidad = 3,
                Nombre = "Luis" , Descripcion = "Periodista",
                Ojo = instanciaOjos[3],
                Pelo = instanciaCabello[1],
                Pecho = instanciaPecho[1],
                Culo = instanciaCulo[0],
                Fisionomia = instanciaFisio[1],
                Prenda1 = instanciaprenda1[0],
                Prenda2 = instanciaprenda2[1]
                },
                new Mujer {
                IdEntidad = 4,
                Nombre = "Isabel" , Descripcion = "Actriz",
                Ojo = instanciaOjos[5],
                Pecho = instanciaPecho[1],
                Culo = instanciaCulo[0],
                Fisionomia = instanciaFisio[0],
                Pelo = instanciaCabello[1],
                Prenda1 = instanciaprenda1[0],
                Prenda2 = instanciaprenda2[2]
                },
                new Hombre {
                IdEntidad = 5,
                Nombre = "Juan" , Descripcion = "Fontanero",
                Ojo = instanciaOjos[0],
                Pecho = instanciaPecho[2],
                Culo = instanciaCulo[0],
                Fisionomia = instanciaFisio[1],
                Pelo = instanciaCabello[5],
                Prenda1 = instanciaprenda1[3],
                Prenda2 = instanciaprenda2[0]
                },
                new Mujer {
                IdEntidad = 6,
                Nombre = "Carmena" , Descripcion = "Lista del paro",
                Ojo = instanciaOjos[5],
                Pecho = instanciaPecho[1],
                Culo = instanciaCulo[0],
                Fisionomia = instanciaFisio[1],
                Pelo = instanciaCabello[2],
                Prenda1 = instanciaprenda1[0],
                Prenda2 = instanciaprenda2[1]
                },
            };
                foreach (var item in mockItems)
                {
                    Items.Add(item);
                }
            }
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