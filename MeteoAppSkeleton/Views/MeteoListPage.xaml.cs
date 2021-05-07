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
            if (place != null)
            {
                if (place.meteo == null) {
                    Place newplace = MeteoController.getInstance().requestMeteoByPlace(place.name);
                    place.meteo = newplace.meteo;
                }
                Navigation.PushAsync(new MeteoItemPage()
                {
                    //BindingContext = e.SelectedItem as Models.Place
                    BindingContext = new MeteoItemViewModel(e.SelectedItem as Place)
                });
            }
        }
    }
}