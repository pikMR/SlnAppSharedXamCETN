using AppCETN.Shared;
using AppCETN.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCETN.ViewModels
{
    /// <summary>
    /// Lista de tipo ListView que se utilizará en la vista inicial.
    /// Contendrá todos los elementos obtenidos mediante el json de tipo Entidad.
    /// </summary>
    public class LestaInicioView : ListView
    {
        public static BindableProperty ItemClickCommandProperty =
            BindableProperty.Create(
                nameof(ItemClickCommand),
                typeof(ICommand),
                typeof(LestaInicioView),
                null
                );

        /// <summary>
        /// Permite establecer en tiempo de ejecución el color de la celda de la lista según el tipo de objeto de la lista.
        /// También establece la fecha actual del elemento como propiedad Detail.
        /// </summary>
        /// <param name="item">Cada objeto de la lista del Singleton.</param>
        /// <returns>Celda de lista</returns>
        protected override Cell CreateDefault(object item)
        {
            Cell nueva = base.CreateDefault(item);
            nueva.SetBinding(TextCell.TextColorProperty, new Binding("Sexo",converter:new ColorConverter()) );
            nueva.SetValue(TextCell.DetailProperty, ((Models.Humano)item).Fecha);
            return nueva;
        }

        public ICommand ItemClickCommand
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("ItemClickCommand");
                return (ICommand)this.GetValue(ItemClickCommandProperty);
            }
            set
            {
                this.SetValue(ItemClickCommandProperty, value);
            }
        }

        public LestaInicioView()
        {            
            this.ItemTapped += OnItemTapped;
        }

        async private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var mainPage = new EditHumanPage(e.Item);
            var rootPage = new NavigationPage(mainPage);
            await Navigation.PushModalAsync(rootPage);
        }

        async  private void LestaOnItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            //SelectedItem = e.SelectedItem;
            var mainPage = new EditHumanPage(e.SelectedItem);
            var rootPage = new NavigationPage(mainPage);
            await Navigation.PushModalAsync(rootPage);
        }
    }
}
