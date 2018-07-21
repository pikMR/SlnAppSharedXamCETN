using AppSharedXamCETN.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCETN.ViewModels
{
    public class LestaInicioView : ListView
    {
        public static BindableProperty ItemClickCommandProperty =
            BindableProperty.Create(
                nameof(ItemClickCommand),
                typeof(ICommand),
                typeof(LestaInicioView),
                null
                );
        public ICommand ItemClickCommand
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("ItemClickCommand");
                return (ICommand)this.GetValue(ItemClickCommandProperty);
            }
            set
            {
                this.SetValue(ItemClickCommandProperty, value);
            }
        }

        public LestaInicioView()
        {
            this.ItemTapped += OnItemTapped;
            //this.ItemSelected += LestaOnItemSelectedAsync;
        }

        async private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnItemTapped" + e.Item);
           /* if(e.Item != null && this.ItemClickCommand != null && this.ItemClickCommand.CanExecute(e))
            {
                ItemClickCommand.Execute(e.Item);*/
                //SelectedItem = e.Item;
                var mainPage = new EditHumanPage(e.Item);//this could be content page
                var rootPage = new NavigationPage(mainPage);
                await Navigation.PushAsync(rootPage);
        }

        async  private void LestaOnItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            System.Console.WriteLine("LestaOnItemSelected()");
            //SelectedItem = e.SelectedItem;
            var mainPage = new EditHumanPage(e.SelectedItem);//this could be content page
            var rootPage = new NavigationPage(mainPage);
            await Navigation.PushAsync(rootPage);
        }
    }
}
