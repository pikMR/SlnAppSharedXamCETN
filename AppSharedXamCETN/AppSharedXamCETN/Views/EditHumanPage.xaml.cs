using AppCETN.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCETN.Services;
using AppCETN.ViewModels;
using System.Linq;
using AppCETN.Shared;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace AppCETN.Views
{
    /// <summary>
    /// Vista para Creación y Edición de los items de la lista Singleton.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditHumanPage : ContentPage
    {
        /// <summary>
        /// Variable para controlar el cambio de sexo con un Humano seleccionado.
        /// </summary>
        private char _valorInicialSexo;
        /// <summary>
        /// Variable que permite determinar el focus en el botón hombre mujer
        /// y que permite tener un control de los cambios entre clase hombre mujer
        /// </summary>
        /// <remarks>
        /// ver <see cref="BtnHombre_Clicked"/> y <see cref="BtnMujer_Clicked"/>
        /// </remarks>
        private bool _esMujer = true;
        /// <summary>
        /// Variable que permite discernir si el elemento de la vista es un elemento creado de nuevo
        /// o un elemento seleccionado.
        /// </summary>
        private bool _esNuevo = false;
        /// <summary>
        /// Variable que permite controlar el cambio del elemento editable de tipo Entry <see cref="entryDesc"/>
        /// que podemos encontrar en el archivo xaml de la vista.
        /// </summary>
        /// <remarks>Ver <see cref="isBasicFill"/></remarks>
        private string _desc = "";
        /// <summary>
        /// Variable que permite controlar el cambio del elemento editable de tipo Entry <see cref="entryName"/>
        /// que podemos encontrar en el archivo xaml de la vista.
        /// </summary>
        /// <remarks> Ver <see cref="isBasicFill"/></remarks>
        private string _nombre = "";

        public Humano ItemHumano { get; set; }
        public PickerParaViewModel<Ojos> PickerOjos { get; set; }
        public PickerParaViewModel<Cabello> PickerCabello { get; set; }
        public PickerParaViewModel<string> PickerPecho { get; set; }
        public PickerParaViewModel<string> PickerNalgas { get; set; }
        public PickerParaViewModel<string> PickerFisionomia { get; set; }
        public PickerParaViewModel<PrendaSuperior> PickerPrendaSuperior { get; set; }
        public PickerParaViewModel<PrendaInferior> PickerPrendaInferior { get; set; }

        /// <summary>
        /// Rellena la vista con Humano seleccionado.
        /// </summary>
        /// <param name="item"> Objeto de tipo Humano, Mujer o Hombre.</param>
        /// <remarks>Ver Lista seleccionable en <see cref="LestaInicioView.OnItemTapped(object, ItemTappedEventArgs)"/></remarks>
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
            if (!String.IsNullOrEmpty(ItemHumano.Photo))
            {
                CambiarImagen(ItemHumano.Photo);
            }

            if (_esMujer)
                FocusOnOff(_btnMujer, _btnHombre, Color.FromRgb(217, 179, 255));
            else
                FocusOnOff(_btnHombre, _btnMujer, Color.FromRgb(153, 187, 255));
        }

        /// <summary>
        /// Constructor que utiliza la vista para visualizar un elemento creado desde 0
        /// </summary>
        /// <remarks>
        /// Ver botón de añadir en <see cref="MainPage.AddItem_Clicked(object, EventArgs)"/> 
        /// </remarks>
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

        /// <summary>
        /// Rellena el valor de los elementos Picker de la lista y
        /// determina el valor seleccionado por el usuario
        /// </summary>
        /// <remarks>
        /// Las funciones ObtenerValores... son funciones que usan el patrón Singleton,
        /// no es necesario la recarga de los elementos.
        /// </remarks>
        private void setPickers()
        {
            CETNDomainService.CambioPicker = false;
            PickerOjos = new PickerParaViewModel<Ojos> { ListaItem = CETNDomainService.ObtenerValoresOjos(), SelectedItem = ItemHumano.Ojos , humanoSeleccionado = ItemHumano};
            PickerCabello = new PickerParaViewModel<Cabello> { ListaItem = CETNDomainService.ObtenerValoresCabello(), SelectedItem = ItemHumano.Cabello, humanoSeleccionado = ItemHumano };
            PickerPecho = new PickerParaViewModel<string> { PickerName = nameof(ItemHumano.Pecho),ListaItem = CETNDomainService.ObtenerValoresPecho(), SelectedItem = ItemHumano.Pecho, humanoSeleccionado = ItemHumano };
            PickerNalgas = new PickerParaViewModel<string> { PickerName = nameof(ItemHumano.Culo),ListaItem = CETNDomainService.ObtenerValoresNalgas(), SelectedItem = ItemHumano.Culo, humanoSeleccionado = ItemHumano };
            PickerFisionomia = new PickerParaViewModel<string> { PickerName = nameof(ItemHumano.Fisionomia),ListaItem = CETNDomainService.ObtenerValoresFisionomia(), SelectedItem = ItemHumano.Fisionomia, humanoSeleccionado = ItemHumano };
            PickerPrendaSuperior = new PickerParaViewModel<PrendaSuperior> { ListaItem = CETNDomainService.ObtenerValoresPrendaSup(), SelectedItem = ItemHumano.PrendaSuperior, humanoSeleccionado = ItemHumano };
            PickerPrendaInferior = new PickerParaViewModel<PrendaInferior> { ListaItem = CETNDomainService.ObtenerValoresPrendaInf(), SelectedItem = ItemHumano.PrendaInferior, humanoSeleccionado = ItemHumano };
        }

        /// <summary>
        /// Comprueba si se ha agregado un Nombre o Descripción en el formulario.
        /// </summary>
        /// <returns> True existe una modificación por parte del usuario, false no existe modificación. </returns>
        private bool isBasicFill() => (!string.IsNullOrEmpty(entryName.Text) && entryName.Text!=_nombre) || (!string.IsNullOrEmpty(entryDesc.Text) && entryDesc.Text != _desc);

        #region Elementos interactivos
        /// <summary>
        /// Sobrecarga de la función que permite a Android volver a la pantalla anterior.
        /// La particularidad es que cuando volvemos hacia atrás guardamos los datos que se han rellenado
        /// en el caso de haber realizado algún cambio.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            try
            {
                if (CETNDomainService.CambioPicker ||
                    isBasicFill() ||
                    ItemHumano.Sexo != _valorInicialSexo ||
                    !String.IsNullOrEmpty(ItemHumano.Photo))
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
            }
            catch (UnauthorizedAccessException un)
            {
                DisplayAlert(LiteralesService.GetLiteral("ex_error"), un.InnerException.Message, LiteralesService.GetLiteral("ex_salida"));
                return false;
            }
            catch (Exception e)
            {
                DisplayAlert(LiteralesService.GetLiteral("ex_error"), e.InnerException.Message, LiteralesService.GetLiteral("ex_salida"));
                return false;
            }

            return base.OnBackButtonPressed();
        }

        /// <summary>
        /// Botón que cambia de sexo a hombre
        /// llama a <see cref="FocusOnOff"/> para hacer focus al botón.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BtnHombre_Clicked(object sender, EventArgs e)
        {
            // edit y cambio
            if (!_esNuevo && _esMujer)
                ItemHumano = new Hombre(ItemHumano);

            _esMujer = false;
            Button btn = (Button)sender;
            FocusOnOff(btn, _btnMujer, Color.FromRgb(153, 187, 255));
        }

        /// <summary>
        /// Botón que cambia de sexo a mujer
        /// llama a <see cref="FocusOnOff"/> para hacer focus al botón.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BtnMujer_Clicked(object sender, EventArgs e)
        {
            // edit y cambio
            if (!_esNuevo && !_esMujer)
                ItemHumano = new Mujer(ItemHumano);

            _esMujer = true;
            Button btn = (Button)sender;
            FocusOnOff(btn, _btnHombre, Color.FromRgb(217, 179, 255));
        }

        /// <summary>
        /// Botón que permite elegir una imagen del movil
        /// se está utilizando la libreria <see cref="CrossMedia"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void BtnCamara_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundColor = Color.FromHex("#aee"); // select
            btn.Opacity = 1;
            btn.BorderWidth = 1;

            // if you want to take a picture use TakePhotoAsync instead of PickPhotoAsync
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (storageStatus == PermissionStatus.Granted)
            {
                //! added using Plugin.Media;
                await CrossMedia.Current.Initialize();

                //// if you want to take a picture use this
                // if(!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
                /// if you want to select from the gallery use this
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert(LiteralesService.GetLiteral("lbl_not_sup"), LiteralesService.GetLiteral("lbl_device"), LiteralesService.GetLiteral("lbl_ok"));
                    return;
                }

                //! added using Plugin.Media.Abstractions;
                // if you want to take a picture use StoreCameraMediaOptions instead of PickMediaOptions
                var mediaOptions = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };

                var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                if (selectedImageFile == null)
                {
                    await DisplayAlert(LiteralesService.GetLiteral("ex_error"), LiteralesService.GetLiteral("lbl_no_image"), LiteralesService.GetLiteral("lbl_ok"));
                    return;
                }
                ItemHumano.Photo = selectedImageFile.Path;
                CambiarImagen(selectedImageFile.Path);
            }
            else
            {
                await DisplayAlert(LiteralesService.GetLiteral("ex_error"), LiteralesService.GetLiteral("ex_2"), LiteralesService.GetLiteral("ex_salida"));
            }
        }


        /// <summary>
        /// Oculta el botón en el caso de encontrar una imagen y establece la imagen seleccionada
        /// usado por la función <see cref="BtnCamara_Clicked"/>
        /// </summary>
        /// <param name="path"></param>
        private void CambiarImagen(string path)
        {
            try
            {
                ImageSource auximg = ImageSource.FromFile(path);
                if (auximg != null)
                {
                    _btnCamara.IsVisible = false;
                    _imgPhoto.Source = auximg;
                    _imgPhoto.IsVisible = true;
                }
            }
            catch (Exception)
            {
                DisplayAlert(LiteralesService.GetLiteral("ex_error"), LiteralesService.GetLiteral("lbl_no_image"), LiteralesService.GetLiteral("lbl_ok"));
            }
        }

        /// <summary>
        /// Activa y desactiva botón.
        /// </summary>
        /// <param name="btn_on">boton que se activa</param>
        /// <param name="btn_off">boton que se desactiva</param>
        /// <param name="color">color para activar</param>
        private void FocusOnOff(Button btn_on, Button btn_off, Color color)
        {
            btn_off.BackgroundColor = Color.FromHex("#ddd");
            btn_off.Opacity = 0.5;
            btn_on.BackgroundColor = Color.FromHex("#aee"); // select
            btn_on.Opacity = 1;
            btn_on.BorderWidth = 1;
            btn_on.BorderColor = color;
        }

        /// <summary>
        /// Botón que elimina a un elemento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(LiteralesService.GetLiteral("del_Eliminar"),
                LiteralesService.GetLiteral("del_seguro"),
                "del_Si",
                "del_No");
            if (answer)
            {
                Singleton.Instance.DeleteElement(ItemHumano.IdEntidad);
                await Navigation.PopModalAsync();
            }
        }
        #endregion

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