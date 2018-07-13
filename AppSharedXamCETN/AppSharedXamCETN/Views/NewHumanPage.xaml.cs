using AppCETN.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCETN.Services;

namespace AppSharedXamCETN.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewHumanPage : ContentPage
	{
        public Humano ItemHumano { get; set; }
        public NewHumanPage()
		{
			InitializeComponent();
            ItemHumano = new Humano
            {
                Nombre = LiteralesService.GetLiteral("lbl_nombre"),
                Descripcion = LiteralesService.GetLiteral("lbl_descripcion")
            };
            BindingContext = this;
        }

        public NewHumanPage(object item)
        {
            InitializeComponent();
            this.ItemHumano = (Humano)item;
            ItemHumano = (Humano)item;
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Agregar Humano", ItemHumano);
            await Navigation.PopModalAsync();
        }


        private void EnableDisableFocus(object sender, EventArgs e)
        {
            (sender as Entry).IsEnabled = true;
            //Navigation.PushAsync(new NewHumanPage());
            //(sender as Button).Text = "I was just clicked!";
        }
    }
}