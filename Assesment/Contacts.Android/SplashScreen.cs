using Android.App;
using Android.Content.PM;
using Android.OS; 

namespace Contacts.Droid
{
    [Activity(Theme = "@style/MainTheme.Splash", Icon = "@mipmap/Icon", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, NoHistory = true)]
    public class SplashScreen : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            Finish();
        }
    }
}