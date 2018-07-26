using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppCETN.ViewModels
{
    public class PickerParaViewModel<T> : INotifyPropertyChanged
    {
        public bool isChanged {get;set;}

        List<T> listaItem;
        public List<T> ListaItem
        {
            get { return listaItem; }
            set
            {
                if (listaItem != value)
                {
                    listaItem = value;
                    //OnPropertyChanged();
                }
            }
        }


        T selectedItem;
        public T SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if(selectedItem != null && !selectedItem.Equals(value))
                { 
                  isChanged = true;
                  selectedItem = value;
                  OnPropertyChanged();
                }
                else
                {
                    if (selectedItem == null)
                    {
                        if (typeof(T).IsEquivalentTo(typeof(string)))
                        {
                            selectedItem = (T)(object)string.Empty;
                        }
                        else
                        {
                            selectedItem = (T)Activator.CreateInstance(typeof(T));
                        }
                    }
                }
            }
        }

        private int seleccionado;
        public int SelectedIndex
        {
            get
            {
                seleccionado = listaItem.IndexOf(selectedItem);
                return seleccionado;
            }
            set
            {
                if (seleccionado != value)
                {
                    seleccionado = value;
                    OnPropertyChanged();
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
