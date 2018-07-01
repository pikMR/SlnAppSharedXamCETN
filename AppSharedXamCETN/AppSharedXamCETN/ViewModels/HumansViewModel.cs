using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using AppCETN.Models;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AppCETN.Services;

namespace AppCETN.ViewModels
{
    public class HumansViewModel : INotifyPropertyChanged
    {
        public IDataStore<Humano> DataStore => DependencyService.Get<IDataStore<Humano>>() ?? new MockDataStore();
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public ObservableCollection<Humano> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public HumansViewModel()
        {
            Title = "Title - Humanos";
            Items = new ObservableCollection<Humano>();
            Task.Run(async () => await ExecuteLoadHumansCommand());
            /*Items = new ObservableCollection<Humano>()
            {
                new Humano { Nombre = "Manuela" , Descripcion = "Jamona1" },
                new Humano { Nombre = "Maria" , Descripcion = "Jamona2" },
                new Humano { Nombre = "Jacinta" , Descripcion = "Jamona3" },
                new Humano { Nombre = "Ana" , Descripcion = "Jamona4" },
                new Humano { Nombre = "Sofia" , Descripcion = "Jamona5" },
                new Humano { Nombre = "Carmena" , Descripcion = "Jamona6" }
            };
            LoadItemsCommand = new Command(async () => await ExecuteLoadHumansCommand());
            MessagingCenter.Subscribe<CETNbasicHuman,Humano>(this, "Agregar Humano", async (obj, item) =>
            {
                var _item = item as Humano;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });*/
        }

        async Task ExecuteLoadHumansCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private string _alertMessage;
        public string AlertMessage
        {
            get
            {
                return _alertMessage;
            }
            set
            {
                _alertMessage = value;
                OnPropertyChanged();
            }
        }
        public ICommand ItemClickCommand
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("ItemClickCommand");
                return new Command(
                    (item) =>
                    {
                        AlertMessage = ((Humano)item).Apodo;
                    }
                    );
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            System.Diagnostics.Debug.WriteLine("SetProperty");
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            System.Diagnostics.Debug.WriteLine("PropertyChanged");
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
