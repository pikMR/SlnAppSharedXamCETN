using AppCETN.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                Apodo = "Juan Grabiel",
                Descripcion = "esto es la descripcion."
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


    }
}