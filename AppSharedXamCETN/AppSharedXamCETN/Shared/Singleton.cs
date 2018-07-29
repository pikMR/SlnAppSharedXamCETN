using AppCETN.Models;
using AppCETN.Services;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace AppSharedXamCETN.Shared
{
    public class Singleton : INotifyPropertyChanged
    {
        public static IDataStore<Humano> DataStore => DependencyService.Get<IDataStore<Humano>>() ?? new MockDataStore();
        private static Singleton instance = null;
        
        private ObservableCollection<Humano> _lista = new ObservableCollection<Humano>();

        public ObservableCollection<Humano> Lista
        {
            get {
                return _lista; 
            }
            set { _lista = value; OnPropertyChanged(); }
        }

        private Singleton() {
            Task.Run(async () => await ExecuteLoadHumansCommand());
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                    //Task.Run(async () => await ExecuteLoadHumansCommand());
                }
                return instance;
            }
        }

        public bool IsBusy { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            
        }

        async Task ExecuteLoadHumansCommand()
        {
            if (IsBusy)
                return;
            
            IsBusy = true;

            try
            {
                _lista.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Lista.Add(item);
                }

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
                throw new Exception(LiteralesService.GetLiteral("ex_2"));
            }
            finally
            {
                IsBusy = false;
            }
        }

        internal async void Update()
        {
            try
            {
                if (_lista != null && _lista.Count > 0)
                    await CETNDomainService.InsertarHumanoJSON(_lista);
            }
            catch (Exception)
            {
                IsBusy = true;
            }
        }

        internal Humano NewHumano()
        {
            Humano nuevo = new Humano { IdEntidad = Instance.getId(), Fecha = DateTime.Now.ToLocalTime().ToString() };
            _lista.Add(nuevo);
            return nuevo;
        }

        private int getId() => (_lista.Count > 0) ?
             _lista.OrderBy(x => x.IdEntidad).Select(x => x.IdEntidad).Last() + 1 : 0;

        internal async Task<Humano> NewMujerAsync(Humano itemHumano)
        {
            Mujer nuevo = new Mujer { IdEntidad = Instance.getId() };
            nuevo.Ojo = itemHumano.Ojo;
            nuevo.Pelo = itemHumano.Pelo;
            nuevo.Pecho = itemHumano.Pecho;
            nuevo.Culo = itemHumano.Culo;
            nuevo.Fisionomia = itemHumano.Fisionomia;
            nuevo.Prenda1 = itemHumano.Prenda1;
            nuevo.Prenda2 = itemHumano.Prenda2;
            nuevo.Nombre = itemHumano.Nombre;
            nuevo.Descripcion = itemHumano.Descripcion;
            if (string.IsNullOrEmpty(itemHumano.Fecha))
                nuevo.Fecha = DateTime.Now.ToLocalTime().ToString();

            _lista.Add(nuevo);
            await CETNDomainService.InsertarMujerJSON(_lista);
            return nuevo;
        }

        internal async Task<Humano> NewHombreAsync(Humano itemHumano)
        {
            Hombre nuevo = new Hombre { IdEntidad = Instance.getId() };
            nuevo.Ojo = itemHumano.Ojo;
            nuevo.Pelo = itemHumano.Pelo;
            nuevo.Pecho = itemHumano.Pecho;
            nuevo.Culo = itemHumano.Culo;
            nuevo.Fisionomia = itemHumano.Fisionomia;
            nuevo.Prenda1 = itemHumano.Prenda1;
            nuevo.Prenda2 = itemHumano.Prenda2;
            nuevo.Nombre = itemHumano.Nombre;
            nuevo.Descripcion = itemHumano.Descripcion;
            if (string.IsNullOrEmpty(itemHumano.Fecha))
                nuevo.Fecha = DateTime.Now.ToLocalTime().ToString();
            _lista.Add(nuevo);
            await CETNDomainService.InsertarHombreJSON(_lista);
            return nuevo;
        }
    }
}
