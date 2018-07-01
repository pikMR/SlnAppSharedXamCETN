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
            Items = new List<Humano>();
            var mockItems = new List<Humano>
            {
                new Humano { Nombre = "Manuela" , Descripcion = "Jamona1" },
                new Humano { Nombre = "Maria" , Descripcion = "Jamona2" },
                new Humano { Nombre = "Jacinta" , Descripcion = "Jamona3" },
                new Humano { Nombre = "Ana" , Descripcion = "Jamona4" },
                new Humano { Nombre = "Sofia" , Descripcion = "Jamona5" },
                new Humano { Nombre = "Carmena" , Descripcion = "Jamona6" },
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