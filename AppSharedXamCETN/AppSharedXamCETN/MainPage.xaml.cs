using Xamarin.Forms;
using System;
using AppCETN.ViewModels;
using AppSharedXamCETN.Views;
using System.Runtime.CompilerServices;

namespace AppSharedXamCETN
{
	public partial class MainPage : ContentPage
	{
        public ViewModel1 vModelReference;

        public MainPage()
		{
         vModelReference = new ViewModel1();
         InitializeComponent();
         OnPropertyChanged("itemListViewModel");
         BindingContext = vModelReference;
         //disabledBtn();
         //var navigation = Navigation.NavigationStack.Count;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new EditHumanPage()));
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}


/*  void BtnOjo_Clicked(object sender, EventArgs e)
  {
      disabledBtn();
      Button btn = (Button)sender;
      activeSingularBtn(btn);
      vModelReference.ReloadOjo();
  }

  void BtnPr_Clicked(object sender, EventArgs e)
  {
      disabledBtn();
      Button btn = (Button)sender;
      activeSingularBtn(btn);
      vModelReference.ReloadPrenda();
  }


  private void disabledBtn()
  {
      disabledSingularBtn(_btnOjos);
      disabledSingularBtn(_btnPrenda);
  }

  private void disabledSingularBtn(Button btn)
  {
      btn.BackgroundColor = Color.FromHex("#ddd"); // select
      btn.BorderWidth = 0;
  }

  private void activeSingularBtn(Button btn)
  {
      btn.BackgroundColor = Color.FromHex("#aee"); // select
      btn.BorderWidth = 1;
      btn.BorderColor = Color.FromHex("#ddd");
  }
  */

