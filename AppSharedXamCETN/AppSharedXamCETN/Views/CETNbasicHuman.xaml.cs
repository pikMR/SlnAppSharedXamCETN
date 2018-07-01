using AppCETN.ViewModels;
using AppCETN.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCETN.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CETNbasicHuman : ContentPage
	{
        CETNbasicHumanViewModel viewModel;
        public CETNbasicHuman(CETNbasicHumanViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
        public CETNbasicHuman()
        {
            InitializeComponent();

            var human = new Humano
            {
                Apodo = "Apodo_",
                Descripcion = "Descripcion_"
            };

            viewModel = new CETNbasicHumanViewModel(human);
            BindingContext = viewModel;
        }
    }
}