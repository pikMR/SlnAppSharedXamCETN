using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSharedXamCETN.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScrollTextView : ContentPage
	{
		public ScrollTextView ()
		{
            InitializeComponent();
            var stack = new StackLayout();
            stack.Children.Add(new Editor { Text = AppCETN.Services.LiteralesService.GetLiteral("texto_bases_legales"), IsEnabled=false});
            Button btnAcept = new Button { Text = AppCETN.Services.LiteralesService.GetLiteral("lbl_acepto") };
            btnAcept.Clicked += new System.EventHandler(Aceptar);
            Button btnCancelar = new Button { Text = AppCETN.Services.LiteralesService.GetLiteral("lbl_no_acepto") };
            btnCancelar.Clicked += new System.EventHandler(Cancelar);
            stack.Children.Add(btnAcept);
            stack.Children.Add(btnCancelar);
            Content = new ScrollView { Content = stack};
        }

        private async void Aceptar(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
            //base.OnBackButtonPressed();
        }

        private async void Cancelar(object sender, System.EventArgs e)
        {
            AppCETN.Shared.Singleton.BasesLegales = false;
            await Navigation.PopModalAsync();
            //base.OnBackButtonPressed();
        }
    }
}