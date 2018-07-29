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
	public partial class HomePage : ContentPage
	{
        int SlidePosition = 0;
        public HomePage ()
		{
			InitializeComponent ();
            var images = new List<string>
            {
                 "cv_pic1.png",
                 "cv_pic2.jpg",
                 "cv_pic3.jpg"
            };
            MainCarouselView.ItemsSource = images;
            //Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            //{
            //    SlidePosition++;
            //    if (SlidePosition == images.Count) SlidePosition = 0;
            //    MainCarouselView.Position = SlidePosition;
            //    return true;
            //});

            var menuheads = new List<MenuHead>
            {
                new MenuHead
                {
                    Image = "mh_sandwich.jpg",
                    Name = "Sandwich",
                    Description="Sandwich......",
                    Cost=75
                    
                },
                new MenuHead
                {
                    Image = "mh_juice.jpg",
                    Name = "Fresh Juice",
                    Description="Fresh Juice......",
                    Cost=60

                },
                new MenuHead
                {
                    Image="veggie_focaccia.jpg",
                    Name="Juice....",
                    Description="Fresh Juice....",
                    Cost=70
                },
                 new MenuHead
                {
                    Image="watermelon_and_mint_juice.jpg",
                    Name="Juice....",
                    Description="Fresh Juice....",
                    Cost=70
                },
            };
            MenuHeadListView.ItemsSource = menuheads;

        }

        private void SignOut_Activated(object sender, EventArgs e)
        {

            Application.Current.Properties["UserName"] = null;
            Application.Current.Properties["FirstName"] = null;
            Navigation.PopToRootAsync();
            Navigation.PushModalAsync(new Login());
        }

        private void Cart_Activated(object sender, EventArgs e)
        {

        }

        private void MenuHeadListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           var Food=  e.Item as MenuHead;
           // var Food = e.SelectedItem as MenuHead;

            Navigation.PushAsync(new Views.DetailPage(Food));
        }

        private void MenuHeadListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
           MenuHeadListView.SelectedItem = null;

        }
        protected override void OnDisappearing()
        {
          
            base.OnDisappearing();
        }
        protected   override bool OnBackButtonPressed()
        {

            var closer = DependencyService.Get<ICloseApplication>();
            closer?.closeApplication();

            return true;
        }
    }
}