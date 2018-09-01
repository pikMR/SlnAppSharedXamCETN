using Android.Content.PM;
using Android.OS;
using AppCETN;
using Plugin.Permissions;

namespace AppSharedXamCETN.Droid
{
    [Android.App.Activity(Label = "Alzeheimer Fuerte", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);

            // agrega literales
            AppCETN.Services.LiteralesService.AddLiterales(Resources.GetStringArray(Resource.Array.lista_lbl_literales),Resources.GetStringArray(Resource.Array.lista_literales));

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

