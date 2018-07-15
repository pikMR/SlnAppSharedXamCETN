using AppCETN.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCETN.Services;
using AppCETN.ViewModels;

namespace AppSharedXamCETN.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewHumanPage : ContentPage
    {
        public Humano ItemHumano { get; set; }
        public PickerParaViewModel<Ojos> PickerOjos { get; set; }
        public PickerParaViewModel<Cabello> PickerCabello { get; set; }
        public PickerParaViewModel<string> PickerPecho { get; set; }
        public PickerParaViewModel<string> PickerNalgas { get; set; }
        public PickerParaViewModel<string> PickerFisionomia { get; set; }
        public PickerParaViewModel<PrendaSuperior> PickerPrendaSuperior { get; set; }
        public PickerParaViewModel<PrendaInferior> PickerPrendaInferior { get; set; }


        public NewHumanPage()
		{
            ItemHumano = new Humano();
            PickerOjos = new PickerParaViewModel<Ojos> { ListaItem = CETNDomainService.ObtenerValoresOjos(), SelectedItem = ItemHumano.Ojo };
            PickerCabello = new PickerParaViewModel<Cabello> { ListaItem = CETNDomainService.ObtenerValoresCabello(), SelectedItem = ItemHumano.Pelo };
            PickerPecho = new PickerParaViewModel<string> { ListaItem = CETNDomainService.ObtenerValoresPecho(), SelectedItem = ItemHumano.Pecho };
            PickerNalgas = new PickerParaViewModel<string> { ListaItem = CETNDomainService.ObtenerValoresNalgas(), SelectedItem = ItemHumano.Culo };
            PickerFisionomia = new PickerParaViewModel<string> { ListaItem = CETNDomainService.ObtenerValoresFisionomia(), SelectedItem = ItemHumano.Fisionomia };
            PickerPrendaSuperior = new PickerParaViewModel<PrendaSuperior> { ListaItem = CETNDomainService.ObtenerValoresPrendaSup(), SelectedItem = ItemHumano.Prenda1 };
            PickerPrendaInferior = new PickerParaViewModel<PrendaInferior> { ListaItem = CETNDomainService.ObtenerValoresPrendaInf(), SelectedItem = ItemHumano.Prenda2 };
            BindingContext = this;
            InitializeComponent();
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

        #region Labels de la vista
        public string LblDescripcion
        {
            get { return LiteralesService.GetLiteral("lbl_descripcion"); }
        }
        public string LblCaracteristicas
        {
            get { return LiteralesService.GetLiteral("lbl_caracteristicas"); }
        }
        public string LblOjos
        {
            get { return LiteralesService.GetLiteral("lbl_ojos"); }
        }
        public string LblPelo
        {
            get { return LiteralesService.GetLiteral("lbl_cabello"); }
        }
        public string LblPecho
        {
            get { return LiteralesService.GetLiteral("lbl_pecho"); }
        }

        public string LblNalgas
        {
            get { return LiteralesService.GetLiteral("lbl_nalgas"); }
        }
        public string LblVestir
        {
            get { return LiteralesService.GetLiteral("lbl_vestir"); }
        }
        public string LblFisionomía
        {
            get { return LiteralesService.GetLiteral("lbl_fisionomia"); }
        }
        public string LblPrendaSuperior
        {
            get { return LiteralesService.GetLiteral("lbl_prenda_sup"); }
        }
        public string LblPrendaInferior
        {
            get { return LiteralesService.GetLiteral("lbl_prenda_inf"); }
        }
        public string LblNuevaMujer
        {
            get { return LiteralesService.GetLiteral("lbl_nueva_mujer"); }
        }
        public string LblNombre
        {
            get { return LiteralesService.GetLiteral("lbl_nombre"); }
        }
        #endregion
    }
}