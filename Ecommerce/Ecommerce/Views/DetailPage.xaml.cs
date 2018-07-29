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
	public partial class DetailPage : ContentPage
	{
        MenuHead head = new MenuHead();
		public DetailPage ( MenuHead menu )
		{
			InitializeComponent ();
            BindingContext = menu;
            head = menu;
            Total.Text = "Total No of Orders= 1";

        }


        private void NoOfOrders_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Total.Text = "Total No of Orders= " + e.NewValue;
            TotalCost.Text = "Total Cost= "+(head.Cost * e.NewValue).ToString();
        }
     

        private async void Order_Clicked_1(object sender, EventArgs e)
        {
            var Name = (string)Application.Current.Properties["UserName"]; 

            await DisplayAlert("Successfull", "Your Order has been placed "+Name, "Ok");
         await Navigation.PopAsync();
        }
    }
}