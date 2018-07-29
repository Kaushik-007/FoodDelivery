using Ecommerce.Interface;
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
    public partial class CreateNewPage : ContentPage
    {
        UserDB userDB = new UserDB();
        public CreateNewPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void Create_Clicked(object sender, EventArgs e)
        {
            if (UserName.Text == null || Password.Text == null || FirstName.Text == null || LastName.Text == null || Email.Text == null)
            {
                Error.Text = "All fields are mandatory";
                return;
            }
            else
            {
                try
                {
                    Error.Text = "";

                    var db = SQLLiteType.GetDb();
                    db.CreateTable<UserDB>();

                    var rec = InsertData(UserName.Text, FirstName.Text, LastName.Text, Email.Text, Password.Text);
                    if (rec >= 1)
                    {
                        await DisplayAlert("Successfully", "Created", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Failed", "Created", "OK");

                    }
                }
                catch (Exception ex)
                {

                }


            }


        }
        private int InsertData(string UserName, string FirstName, string LastName, string Email, string Password)
        {
            userDB.FirstName = FirstName;
            userDB.UserName = UserName;
            userDB.LastName = LastName;
            userDB.Email = Email;
            userDB.Password = Password;
            UserQuery userQuery = new UserQuery();
            var res = userQuery.InsertDetails(userDB);
            return res;
        }
    }
}