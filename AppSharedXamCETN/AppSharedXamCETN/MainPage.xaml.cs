using Xamarin.Forms;
using System;
using AppCETN.Views;
using AppCETN.Shared;

namespace AppCETN
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
		{
         InitializeComponent();
         OnPropertyChanged("itemListViewModel");
         BindingContext = Singleton.Instance;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new EditHumanPage()));
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}