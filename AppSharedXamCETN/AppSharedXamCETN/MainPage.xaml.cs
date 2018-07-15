using Xamarin.Forms;
using System;
using AppCETN.Models;
using AppCETN.ViewModels;
using AppSharedXamCETN.Views;

namespace AppSharedXamCETN
{
	public partial class MainPage : ContentPage
	{
        //public Humano Item { get; set; }
        public HumansViewModel viewModel;

		public MainPage()
		{
			InitializeComponent();
            BindingContext = new HumansViewModel();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "Agregar Humano", Item);
            await Navigation.PopModalAsync();
        }
        public void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {

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

            //var strLabel = Android.Resource.
        }

        private void LestaInicioView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new EditHumanPage(e.SelectedItem));
        }

        /*private void PressAdd_Pressed(object sender, EventArgs e)
        {
            (sender as Button).Text = "You pressed me!";
        }*/

        private void PressAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewHumanPage());
            //(sender as Button).Text = "I was just clicked!";
        }
    }
}
