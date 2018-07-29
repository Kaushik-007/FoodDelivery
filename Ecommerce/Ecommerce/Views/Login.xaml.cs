using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ecommerce.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

       
        private void Button_Clicked(object sender, EventArgs e)
        {
            if(UserName.Text==null||Password.Text==null)
            {
                Error.Text = "All Fields are Mandaory";
                return;
            }
            else
            {
                Error.Text = null;
                UserDB userDB = new UserDB();
                UserQuery userQuery = new UserQuery();
                try
                { userDB = userQuery.GetCustName(UserName.Text);

                    if(userDB!=null)
                    {
                        if(Password.Text==userDB.Password)
                        {
                            Application.Current.Properties["UserName"] = userDB.UserName;
                            Application.Current.Properties["FirstName"] = userDB.FirstName;

                            Application.Current.SavePropertiesAsync();

                            Navigation.PushModalAsync(new NavigationPage(new Views.HomePage()));
                        }
                        else
                        {
                            DisplayAlert("Failed", "", "Ok");
                        }

                    }
                }
                catch(Exception ex)
                {
                    DisplayAlert("Failed", ex.Message, "Ok");
                }
            }
        }

        private void CreateNew_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateNewPage());
        }
    }
}