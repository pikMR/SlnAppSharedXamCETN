using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using AppCETN.Models;
using Xamarin.Forms;
using AppCETN.Services;

namespace AppCETN.ViewModels
{
    public class HumansViewModel : BaseViewModel
    {
        public IDataStore<Humano> DataStore => DependencyService.Get<IDataStore<Humano>>() ?? new MockDataStore();

        #region Elementos visuales
        private string btnAdd = string.Empty;
        public string Add
        {
            get { return btnAdd; }
            set { SetProperty(ref btnAdd, value); }
        }
        #endregion


        public ObservableCollection<Humano> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

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
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
