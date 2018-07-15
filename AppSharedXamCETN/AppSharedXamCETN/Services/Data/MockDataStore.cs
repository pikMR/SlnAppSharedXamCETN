using System;
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

        public MockDataStore()
        {
            var instanciaOjos = CETNDomainService.ObtenerValoresOjos();
            Items = new List<Humano>();
            var mockItems = new List<Humano>
            {
                new Humano { Nombre = "Manuela" , Descripcion = "Jamona1",
                Ojo = instanciaOjos[2],
                Pelo = new Cabello() { Tam = "Largo" , Color = "Rubio"},
                Pecho = "Grande",
                Culo = "Grande",
                Fisionomia = "Delgado",
                Prenda1 = new PrendaSuperior(){ Nombre = "@string/prenda_superior_hombre_2" , Color = "Amarilla"},
                Prenda2 = new PrendaInferior(){ Nombre = "@string/prenda_inferior_hombre_2" , Color = "Amarilla"}
                },
                new Humano { Nombre = "Maria" , Descripcion = "Jamona2",
                Ojo = instanciaOjos[1],
                Pelo = new Cabello() { Tam = "Trenzado" , Color = "Rojizo"},
                Pecho = "Mediano",
                Culo = "Mediano",
                Fisionomia = "Fuerte",
                Prenda1 = new PrendaSuperior(){ Nombre = "@string/prenda_superior_hombre_3" , Color = "Negra"},
                Prenda2 = new PrendaInferior(){ Nombre = "@string/prenda_inferior_hombre_1" , Color = "Amarilla"}
                },
                new Humano { Nombre = "Jacinta" , Descripcion = "Jamona3",
                Ojo = instanciaOjos[3],
                Pelo = new Cabello() { Tam = "De punta" , Color = "Rubio"},
                Pecho = "Grande",
                Culo = "Grande",
                Fisionomia = "Pesado",
                Prenda1 = new PrendaSuperior(){ Nombre = "@string/prenda_superior_hombre_4" , Color = "Azul"},
                Prenda2 = new PrendaInferior(){ Nombre = "@string/prenda_inferior_hombre_2" , Color = "Amarilla"}
                },
                new Humano { Nombre = "Ana" , Descripcion = "Jamona4",
                Ojo = instanciaOjos[5],
                Pecho = "Pequeño",
                Culo = "Pequeño",
                Fisionomia = "Delgado",
                Pelo = new Cabello() { Tam = "Largo" , Color = "Castaño"},
                Prenda1 = new PrendaSuperior(){ Nombre = "@string/prenda_superior_hombre_5" , Color = "Verde"},
                Prenda2 = new PrendaInferior(){ Nombre = "@string/prenda_inferior_hombre_1" , Color = "Amarilla"}
                },
                new Humano { Nombre = "Sofia" , Descripcion = "Jamona5",
                Ojo = instanciaOjos[0],
                Pecho = "Grande",
                Culo = "Grande",
                Fisionomia = "Cuerpo Escombro",
                Pelo = new Cabello() { Tam = "Corto" , Color = "Rubio"},
                Prenda1 = new PrendaSuperior(){ Nombre = "@string/prenda_superior_hombre_6" , Color = "Blanca"},
                Prenda2 = new PrendaInferior(){ Nombre = "@string/prenda_inferior_hombre_2" , Color = "Amarilla"}
                },
                new Humano { Nombre = "Carmena" , Descripcion = "Jamona6",
                Ojo = instanciaOjos[5],
                Pecho = "Grande",
                Culo = "Grande",
                Fisionomia = "Raspa",
                Pelo = new Cabello() { Tam = "Largo" , Color = "Moreno"},
                Prenda1 = new PrendaSuperior(){ Nombre = "@string/prenda_superior_hombre_7" , Color = "Morada"},
                Prenda2 = new PrendaInferior(){ Nombre = "@string/prenda_inferior_hombre_1" , Color = "Amarilla"}
                },
            };

            foreach (var item in mockItems)
            {
                Items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Humano item)
        {
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Humano item)
        {
            var _item = Items.Where((Humano arg) => arg.Apodo == item.Apodo).FirstOrDefault();
            Items.Remove(_item);
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = Items.Where((Humano arg) => arg.Apodo == id).FirstOrDefault();
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