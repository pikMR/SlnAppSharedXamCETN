using Xamarin.Forms;
using System;
using AppCETN.Models;
using AppCETN.Views;
using AppCETN.ViewModels;
using AppSharedXamCETN.Views;
using System.Windows.Input;

namespace AppSharedXamCETN
{
	public partial class MainPage : ContentPage
	{
        public Humano Item { get; set; }
        public HumansViewModel viewModel;

		public MainPage()
		{
			InitializeComponent();
            BindingContext = new HumansViewModel();
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Agregar Humano", Item);
            await Navigation.PopModalAsync();
        }
        public void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            //System.Diagnostics.Debug.WriteLine("OnItemSelected()");
            //var item = args.SelectedItem as Humano;
            //if (item == null)
            //    return;

            //BindingContext = new NavigationPage(new NewHumanPage());
            //await Navigation.PushAsync(new NavigationPage(new NewHumanPage()));
            //PushAsync(new NewHumanPage());
            //if (this.SelectedItem == null) return;
            //Navigation.PushAsync(new NewHumanPage());
            // Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewHumanPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel!=null && viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void LestaInicioView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new NewHumanPage(e.SelectedItem));
        }
        
    }
}
