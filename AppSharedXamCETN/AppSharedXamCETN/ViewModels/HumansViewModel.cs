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

        public ObservableCollection<Humano> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        //public Hombre AtributosHombre{ get; set; }
        //public Mujer AtributosMujer { get; set; }

        public HumansViewModel()
        {
            Title = LiteralesService.GetLiteral("lbl_titulo");
            Add = LiteralesService.GetLiteral("lbl_agregar");
            Items = new ObservableCollection<Humano>();
            Task.Run(async () => await ExecuteLoadHumansCommand());
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

        #region Elementos visuales
        private string btnAdd = string.Empty;
        public string Add
        {
            get { return btnAdd; }
            set { SetProperty(ref btnAdd, value); }
        }

        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        #endregion
    }
}
