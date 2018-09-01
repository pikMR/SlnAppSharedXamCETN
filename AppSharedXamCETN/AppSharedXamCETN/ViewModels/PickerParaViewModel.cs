using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AppCETN.ViewModels
{
    public class PickerParaViewModel<T> : INotifyPropertyChanged
    {
        public string PickerName { get; set; }
        public Models.Humano humanoSeleccionado;

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
                            if (value == null)
                                selectedItem = (T)Activator.CreateInstance(typeof(T));
                            else
                                selectedItem = value;
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
            Services.CETNDomainService.CambioPicker = true;
            var tipo = humanoSeleccionado.GetType();
            var nombre = String.IsNullOrEmpty(PickerName) ? SelectedItem.GetType().Name : PickerName;
            tipo.GetProperty(nombre, BindingFlags.Instance | BindingFlags.Public).SetValue(humanoSeleccionado, selectedItem, null);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
