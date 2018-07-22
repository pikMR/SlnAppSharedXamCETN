using Xamarin.Forms;
using System;
using AppCETN.ViewModels;
using AppSharedXamCETN.Views;
using System.Runtime.CompilerServices;

namespace AppSharedXamCETN
{
	public partial class MainPage : ContentPage
	{
        public ViewModel1 vModelReference;

        public MainPage()
		{
            vModelReference = new ViewModel1();
            InitializeComponent();
            OnPropertyChanged("itemListViewModel");
            BindingContext = vModelReference;
            //var navigation = Navigation.NavigationStack.Count;
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
