using System;
using MeteoAppSkeleton.Controller;
using MeteoAppSkeleton.Models;
using MeteoAppSkeleton.ViewModels;
using Xamarin.Forms;

namespace MeteoAppSkeleton.Views
{
    public partial class MeteoListPage : ContentPage
    {
        public MeteoListPage()
        {
            InitializeComponent();
            BindingContext = MeteoListViewModel.getInstance();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void OnItemAdded(object sender, EventArgs e)
        {
          
            Navigation.PushAsync(new AddNewLocation());
        }

        void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Place place = (Place)e.SelectedItem;
             
            if (place != null && !place.name.Equals("Locale"))
            {
                if (place.meteo == null) {
                    Place newplace = MeteoController.getInstance().requestMeteoByPlace(place.name);
                    if (newplace != null)
                    {
                        place.meteo = newplace.meteo;
                        place.addIcon(newplace.meteo.weather[0].icon);
                    }
                }

                Console.WriteLine("IMAGE: "+place.image+"------------------------------------------------------------------");
                Navigation.PushAsync(new MeteoItemPage()
                {
                    //BindingContext = e.SelectedItem as Models.Place

                    
                    BindingContext = new MeteoItemViewModel(e.SelectedItem as Place)
                });
            }
        }
    }
}