using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
                new Humano
                {
                IdEntidad = 1,
                Nombre = "Manuela" , Descripcion = "Jamona1",
                Ojo = instanciaOjos[2],
                Pelo = instanciaCabello[2],
                Pecho = instanciaPecho[1],
                Culo = instanciaCulo[2],
                Fisionomia = instanciaFisio[0],
                Prenda1 = instanciaprenda1[3],
                Prenda2 = instanciaprenda2[0]
                },
                new Humano {
                IdEntidad = 2,
                Nombre = "Maria" , Descripcion = "Jamona2",
                Ojo = instanciaOjos[1],
                Pelo = instanciaCabello[3],
                Pecho = instanciaPecho[0],
                Culo = instanciaCulo[0],
                Fisionomia = instanciaFisio[0],
                Prenda1 = instanciaprenda1[2],
                Prenda2 = instanciaprenda2[0]
                },
                new Humano {
                IdEntidad = 3,
                Nombre = "Jacinta" , Descripcion = "Jamona3",
                Ojo = instanciaOjos[3],
                Pelo = instanciaCabello[1],
                Pecho = instanciaPecho[1],
                Culo = instanciaCulo[0],
                Fisionomia = instanciaFisio[1],
                Prenda1 = instanciaprenda1[0],
                Prenda2 = instanciaprenda2[1]
                },
                new Humano {
                IdEntidad = 4,
                Nombre = "Ana" , Descripcion = "Jamona4",
                Ojo = instanciaOjos[5],
                Pecho = instanciaPecho[1],
                Culo = instanciaCulo[0],
                Fisionomia = instanciaFisio[0],
                Pelo = instanciaCabello[1],
                Prenda1 = instanciaprenda1[0],
                Prenda2 = instanciaprenda2[2]
                },
                new Humano {
                IdEntidad = 5,
                Nombre = "Sofia" , Descripcion = "Jamona5",
                Ojo = instanciaOjos[0],
                Pecho = instanciaPecho[2],
                Culo = instanciaCulo[0],
                Fisionomia = instanciaFisio[1],
                Pelo = instanciaCabello[5],
                Prenda1 = instanciaprenda1[3],
                Prenda2 = instanciaprenda2[0]
                },
                new Humano {
                IdEntidad = 6,
                Nombre = "Carmena" , Descripcion = "Jamona6",
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


        internal void UpdateData(Humano objetosrc,Humano objend)
        {
            var _item = Items.Where((Humano arg) => arg == objetosrc).FirstOrDefault();
            Items.Remove(_item);
            Items.Add(objend);
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

        public  Task<bool> UpdateItemAsync(Humano item , Humano objend)
        {
            var _item = Items.Where((Humano arg) => arg == item).FirstOrDefault();
            Items.Remove(_item);
            Items.Add(objend);
            return Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var _item = Items.Where((Humano arg) => arg.IdEntidad == id).FirstOrDefault();
            Items.Remove(_item);
            return await Task.FromResult(true);
        }

        public async Task<Humano> GetItemAsync(string id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.Apodo == id));
        }

        public async Task<IEnumerable<Humano>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }
    }
}