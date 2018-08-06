using AppCETN.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCETN.Services;
using AppCETN.ViewModels;
using System.Linq;
using AppCETN.Shared;
using System.Diagnostics;

namespace AppCETN.Views
{
    /// <summary>
    /// Vista para Creación y Edición de los items de la lista Singleton.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditHumanPage : ContentPage
    {
        private char _valorInicialSexo;
        private bool _esMujer = true;
        private bool _esNuevo = false;
        public Humano ItemHumano { get; set; }
        public PickerParaViewModel<Ojos> PickerOjos { get; set; }
        public PickerParaViewModel<Cabello> PickerCabello { get; set; }
        public PickerParaViewModel<string> PickerPecho { get; set; }
        public PickerParaViewModel<string> PickerNalgas { get; set; }
        public PickerParaViewModel<string> PickerFisionomia { get; set; }
        public PickerParaViewModel<PrendaSuperior> PickerPrendaSuperior { get; set; }
        public PickerParaViewModel<PrendaInferior> PickerPrendaInferior { get; set; }
        private string _desc = "";
        private string _nombre = "";

        public EditHumanPage(object item)
        {
            _valorInicialSexo = ((Humano)item).Sexo;
            ItemHumano = Singleton.Instance.Lista.SingleOrDefault(x=>x.IdEntidad == ((Humano)item).IdEntidad) ?? Singleton.Instance.NewHumano();//(Humano)item;
            _desc = ItemHumano.Descripcion;
            _nombre = ItemHumano.Nombre;
            _esMujer = (ItemHumano.GetType() == typeof(Mujer));
            setPickers();
            BindingContext = this;
            InitializeComponent();

            if (_esMujer)
                FocusOnOff(_btnMujer, _btnHombre, Color.FromRgb(217, 179, 255));
            else
                FocusOnOff(_btnHombre, _btnMujer, Color.FromRgb(153, 187, 255));
        }

        private void setPickers()
        {
            PickerOjos = new PickerParaViewModel<Ojos> { ListaItem = CETNDomainService.ObtenerValoresOjos(), SelectedItem = ItemHumano.Ojo };
            PickerCabello = new PickerParaViewModel<Cabello> { ListaItem = CETNDomainService.ObtenerValoresCabello(), SelectedItem = ItemHumano.Pelo };
            PickerPecho = new PickerParaViewModel<string> { ListaItem = CETNDomainService.ObtenerValoresPecho(), SelectedItem = ItemHumano.Pecho };
            PickerNalgas = new PickerParaViewModel<string> { ListaItem = CETNDomainService.ObtenerValoresNalgas(), SelectedItem = ItemHumano.Culo };
            PickerFisionomia = new PickerParaViewModel<string> { ListaItem = CETNDomainService.ObtenerValoresFisionomia(), SelectedItem = ItemHumano.Fisionomia };
            PickerPrendaSuperior = new PickerParaViewModel<PrendaSuperior> { ListaItem = CETNDomainService.ObtenerValoresPrendaSup(), SelectedItem = ItemHumano.Prenda1 };
            PickerPrendaInferior = new PickerParaViewModel<PrendaInferior> { ListaItem = CETNDomainService.ObtenerValoresPrendaInf(), SelectedItem = ItemHumano.Prenda2 };
        }

        private bool isBasicFill() => (!string.IsNullOrEmpty(entryName.Text) && entryName.Text!=_nombre) || (!string.IsNullOrEmpty(entryDesc.Text) && entryDesc.Text != _desc);

        public EditHumanPage()
        {
            _esNuevo = true;
            ItemHumano = new Humano();
            setPickers();
            BindingContext = this;
            InitializeComponent();
            FocusOnOff(_btnMujer, _btnHombre, Color.FromRgb(153, 187, 255));
            PressDelete.IsVisible = false;
        }
        
        void BtnHombre_Clicked(object sender, EventArgs e)
        {
            // edit y cambio
            if (!_esNuevo && _esMujer)
                ItemHumano = new Hombre(ItemHumano);

            _esMujer = false;
            Button btn = (Button)sender;
            FocusOnOff(btn, _btnMujer, Color.FromRgb(153, 187, 255));
        }

        void BtnMujer_Clicked(object sender, EventArgs e)
        {
            // edit y cambio
            if(!_esNuevo && !_esMujer)
                ItemHumano = new Mujer(ItemHumano);

            _esMujer = true;
            Button btn = (Button)sender;
            FocusOnOff(btn,_btnHombre, Color.FromRgb(217, 179, 255));
        }

        private void FocusOnOff(Button btn_on,Button btn_off,Color color)
        {
            btn_off.BackgroundColor = Color.FromHex("#ddd");
            btn_off.Opacity = 0.5;
            btn_on.BackgroundColor = Color.FromHex("#aee"); // select
            btn_on.Opacity = 1;
            btn_on.BorderWidth = 1;
            btn_on.BorderColor = color;
        }

        async void Save_Clicked(object sender, EventArgs e) => await Navigation.PopModalAsync();


        private void EnableDisableFocus(object sender, EventArgs e) => (sender as Entry).IsEnabled = true;

        protected override bool OnBackButtonPressed()
        {
            try
            {
                if (IsChangedPickers() || isBasicFill() || ItemHumano.Sexo != _valorInicialSexo)
                {
                    if (_esNuevo)
                    {
                        ItemHumano = _esMujer ? Singleton.Instance.NewMujerAsync(ItemHumano) :
                            Singleton.Instance.NewHombreAsync(ItemHumano);
                    }
                    else
                    {
                        Singleton.Instance.Update(ItemHumano);
                        if (Singleton.Instance.IsBusy)
                        {
                            DisplayAlert(LiteralesService.GetLiteral("ex_error"), LiteralesService.GetLiteral("ex_1"), LiteralesService.GetLiteral("ex_salida"));
                            return false;
                        }
                    }
                }
            } catch (UnauthorizedAccessException un)
            {
                DisplayAlert(LiteralesService.GetLiteral("ex_error"), un.InnerException.Message, LiteralesService.GetLiteral("ex_salida"));
                return false;
            }
            catch (Exception e) {
                DisplayAlert(LiteralesService.GetLiteral("ex_error"), e.InnerException.Message, LiteralesService.GetLiteral("ex_salida"));
                return false;
            }

            return base.OnBackButtonPressed();
        }

        /// <summary>
        ///  Función que nos asegura que se ha resaltado algún picker.
        ///  no ponemos ningún condionante de selección en los pickers
        ///  si quisieramos agregar condicionante desseleccionar.
        /// </summary>
        /// <returns></returns>
        private bool IsChangedPickers()
        {
            bool resultado = false;
            if (PickerOjos.isChanged)
            {
                ItemHumano.Ojo = PickerOjos.SelectedItem;
                resultado = true;
                PickerOjos.isChanged = false;
                //Singleton.Instance.OnPropertyChanged("Ojo");
            }
            if (PickerCabello.isChanged)
            {
                ItemHumano.Pelo = PickerCabello.SelectedItem;
                resultado = true;
                PickerCabello.isChanged = false;
            }
            if (PickerPecho.isChanged)
            {
                ItemHumano.Pecho = PickerPecho.SelectedItem;
                resultado = true;
                PickerPecho.isChanged = false;
            }
            if (PickerNalgas.isChanged)
            {
                ItemHumano.Culo = PickerNalgas.SelectedItem;
                resultado = true;
                PickerNalgas.isChanged = false;
            }
            if (PickerFisionomia.isChanged)
            {
                ItemHumano.Fisionomia = PickerFisionomia.SelectedItem;
                resultado = true;
                PickerFisionomia.isChanged = false;
            }
            if (PickerPrendaSuperior.isChanged)
            {
                ItemHumano.Prenda1 = PickerPrendaSuperior.SelectedItem;
                resultado = true;
                PickerPrendaSuperior.isChanged = false;
            }
            if (PickerPrendaInferior.isChanged)
            {
                ItemHumano.Prenda2 = PickerPrendaInferior.SelectedItem;
                resultado = true;
                PickerPrendaInferior.isChanged = false;
            }
            return resultado;
        }

        async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Eliminar", "Borraras esta persona ¿seguro?", "Si", "No");
            if (answer)
            {
                Singleton.Instance.DeleteElement(ItemHumano.IdEntidad);
                await Navigation.PopModalAsync();
            }
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

        public string Lblplaceh_name
        {
            get { return LiteralesService.GetLiteral("placeh_name"); }
        }

        public string LblTitulo
        {
            get { return LiteralesService.GetLiteral("titulo"); }
        }
        #endregion
    }
}