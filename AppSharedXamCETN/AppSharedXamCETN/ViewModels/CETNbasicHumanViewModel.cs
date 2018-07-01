using AppCETN.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AppCETN.ViewModels
{
    public class CETNbasicHumanViewModel : BaseViewModel
    {
        public Humano Human { get; set; }
        public CETNbasicHumanViewModel(Humano human = null)
        {
            System.Diagnostics.Debug.WriteLine("CETNbasicHumanViewModel" + " -> " + human);
            Human = human;
        }

        /*public CETNbasicHumanViewModel()
        {
            Title = "Titulo - Humano";
            _mySource = new ObservableCollection<Humano>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadHumansCommand());
            MySource = new ObservableCollection<Humano>
            {
                
            };
        }

        public ObservableCollection<Humano> MySource
        {
            get
            {
                return _mySource;
            }
            set
            {
                _mySource = value;
                OnPropertyChanged();
            }
        }*/
    }
}
