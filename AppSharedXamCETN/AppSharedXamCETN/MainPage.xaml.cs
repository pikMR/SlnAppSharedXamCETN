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
            if (((Singleton)BindingContext).Lista == null || 
                ((Singleton)BindingContext).Lista != null && ((Singleton)BindingContext).Lista.Count==0)
            {
                var res = DisplayAlert("Tienes la opción compartir tus datos si aceptas los terminos legales, si no tus datos no serán almacenados en una base de datos estadistica.", "Terminos", "Acepto los Terminos Legales","No acepto");

                if (res.IsCompleted)
                    Singleton.BasesLegales = true;
            }
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