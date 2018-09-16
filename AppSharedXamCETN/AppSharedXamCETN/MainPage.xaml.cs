using Xamarin.Forms;
using System;
using AppCETN.Views;
using AppCETN.Shared;
using AppCETN.Services;
using AppSharedXamCETN.Views;

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

        private async void VerBasesLegales(object sender, EventArgs e)
        {
            string _basesLegales = LiteralesService.GetLiteral("lbl_bases");
            string _acepto = LiteralesService.GetLiteral("lbl_acepto");
            string _noacepto = LiteralesService.GetLiteral("lbl_no_acepto");
            string _advertencia = LiteralesService.GetLiteral("lbl_adv");
            string _leer = LiteralesService.GetLiteral("lbl_leer");

            var action = await DisplayActionSheet(_basesLegales,_acepto,_noacepto,_advertencia,_leer);

            if (action.Equals(_noacepto))
            {
                Singleton.BasesLegales = false;
            }
            else if(action.Equals(_leer) || action.Equals(_advertencia))
            {
                await Navigation.PushModalAsync(new NavigationPage(new ScrollTextView()));
            }
        }

        protected override void OnAppearing()
        {
            if (ToolbarItems.Count == 0)
            {
                var legales = new ToolbarItem { Text = "Bases Legales", Icon = "legales.png"};
                legales.Clicked += new EventHandler(VerBasesLegales);
                ToolbarItems.Add(legales);
            } 
            base.OnAppearing();
        }
    }
}