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
        public static IDataStore<Humano> DataStore => DependencyService.Get<IDataStore<Humano>>() ?? new MockDataStore();

        #region Elementos visuales
        private string btnAdd = string.Empty;
        public string Add
        {
            get { return btnAdd; }
            set { SetProperty(ref btnAdd, value); }
        }
        #endregion


        public System.Collections.Generic.List<Humano> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public HumansViewModel()
        {
            MessagingCenter.Subscribe<AppSharedXamCETN.Views.EditHumanPage, Humano>(this, "ActualizarHumano", (sender, item) => {
                //Items.RemoveAll(p => p.IdEntidad == item.IdEntidad);
                //Items.Add(item);
                DataStore.DeleteItemAsync(item.IdEntidad);
                DataStore.AddItemAsync(item);
                Task.Run(async () => await ExecuteLoadHumansCommand());
            });
            Title = LiteralesService.GetLiteral("lbl_titulo");
            Add = LiteralesService.GetLiteral("lbl_agregar");
            Items = new System.Collections.Generic.List<Humano>();
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
