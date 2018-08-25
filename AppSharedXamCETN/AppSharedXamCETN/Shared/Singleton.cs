using AppCETN.Models;
using AppCETN.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace AppCETN.Shared
{
    /// <summary>
    /// Lista Singleton observable que permite utilizar en diferentes vistas los datos de la aplicación.
    /// </summary>
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

        /// <summary>
        /// Borra la lista actual, y agrega los datos actualizados
        /// lo que permite que se visualizen en la vista inicial de la aplicación
        /// los datos refrescados, posible mejora obtener los datos directamente con 
        /// el binding de observables - problematica el tipo de lista creada (ViewModels.LestaInicioView.cs)
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Actualiza el contenido del json con los valores actualizados de la lista Singleton.
        /// </summary>
        internal async void Update(Humano h)
        {
            try
            {
                var elem = Lista.Single(x => x.IdEntidad == h.IdEntidad);
                Lista[Lista.IndexOf(elem)] = h;

                if (_lista != null && _lista.Count > 0)
                    await CETNDomainService.ActualizarHumanoJSON(_lista);
            }
            catch (Exception)
            {
                IsBusy = true;
            }
        }

        /// <summary>
        /// Crea un objeto humano para ser rellenado,
        /// solo hay creados los atributos Id, y Fecha
        /// </summary>
        /// <returns></returns>
        internal Humano NewHumano()
        {
            Humano nuevo = new Humano { IdEntidad = Instance.getId(), Fecha = DateTime.Now.ToLocalTime().ToString() };
            _lista.Add(nuevo);
            return nuevo;
        }

        /// <summary>
        /// Obtiene el id+1 del último elemento, si no hay elementos devuelve 0.
        /// </summary>
        /// <returns>Id entero</returns>
        private int getId() => (_lista.Count > 0) ?
             _lista.OrderBy(x => x.IdEntidad).Select(x => x.IdEntidad).Last() + 1 : 0;

        /// <summary>
        /// Crea un objeto de tipo mujer pasandole por parametro un item Humano,
        /// si se quiere rellenar los atributos especificos del objeto mujer se realizaría mas adelante.
        /// </summary>
        /// <param name="itemHumano"></param>
        /// <returns></returns>
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
            nuevo.Photo = itemHumano.Photo;
            if (string.IsNullOrEmpty(itemHumano.Fecha))
                nuevo.Fecha = DateTime.Now.ToLocalTime().ToString();
            _lista.Add(nuevo);
            await CETNDomainService.ActualizarHumanoJSON(_lista);
            return nuevo;
        }

        /// <summary>
        /// Crea un objeto de tipo hombre pasandole por parametro un item Humano,
        /// si se quiere rellenar los atributos especificos del objeto hombre se realizaría mas adelante.
        /// </summary>
        /// <param name="itemHumano"></param>
        /// <returns></returns>
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
            nuevo.Photo = itemHumano.Photo;
            if (string.IsNullOrEmpty(itemHumano.Fecha))
                nuevo.Fecha = DateTime.Now.ToLocalTime().ToString();
            _lista.Add(nuevo);
            await CETNDomainService.ActualizarHumanoJSON(_lista);
            return nuevo;
        }

        internal async void DeleteElement(int idEntidad)
        {
            var elem = Lista.Single(x => x.IdEntidad == idEntidad);
            Lista.Remove(elem);
            await CETNDomainService.ActualizarHumanoJSON(_lista);
        }
    }
}
