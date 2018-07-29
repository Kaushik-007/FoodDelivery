using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Ecommerce
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            if(Current.Properties.ContainsKey("UserName"))
            {
                if(Current.Properties["UserName"]==null)
                {
                    MainPage = new NavigationPage(new Views.Login());
                }
                else
                {
                    MainPage = new NavigationPage(new Views.Login());
                }
            }
            else
                {
                MainPage = new NavigationPage(new Views.Login());

            }
            
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
