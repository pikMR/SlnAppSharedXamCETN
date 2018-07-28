using AppCETN.Models;
using AppCETN.Services;
using AppSharedXamCETN.Shared;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Linq;
using System;

namespace AppSharedXamCETN
{
    public class ViewModel1 : INotifyPropertyChanged
    {
        private ObservableCollection<Humano> _listaPantalla1;

        public ObservableCollection<Humano> ListaPantalla1
        {
            get
            {
                return Singleton.Instance.Lista;
            }
            set { _listaPantalla1 = value;OnPropertyChanged(); }
        }

        public ViewModel1()
        {
            MessagingCenter.Subscribe<Views.EditHumanPage,Humano>(this, "update", (sender,arg) => {
                //ListaPantalla1 = Singleton.Instance.Lista;3
                var elem = ListaPantalla1.Single(x => x.IdEntidad == arg.IdEntidad);
                ListaPantalla1.Remove(elem);
                ListaPantalla1.Add(arg);
            });
            //Add = LiteralesService.GetLiteral("lbl_agregar");
         }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

/*internal void ReloadOjo()
{
    ObservableCollection<Humano> nueva_list = new ObservableCollection<Humano>();
    ListaPantalla1.ToList().ForEach(p => { p.AtribSeleccionado = " -> " + p.Ojo; nueva_list.Add(p); });
    ListaPantalla1.Clear();
    nueva_list.ToList().ForEach(p => { ListaPantalla1.Add(p); });
}
internal void ReloadPrenda() {
    ObservableCollection<Humano> nueva_list = new ObservableCollection<Humano>();
    ListaPantalla1.ToList().ForEach(p => { p.AtribSeleccionado = " -> " + p.Prenda1; nueva_list.Add(p); });
    ListaPantalla1.Clear();
    nueva_list.ToList().ForEach(p => { ListaPantalla1.Add(p); });
}

#region Elementos visuales
private string btnAdd = string.Empty;
public string Add 
{
    get { return btnAdd; }
    set { btnAdd = value; }
}
#endregion*/

