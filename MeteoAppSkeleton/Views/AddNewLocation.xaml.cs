
using MeteoAppSkeleton.Controller;
using MeteoAppSkeleton.Models;
using MeteoAppSkeleton.ViewModels;
using Plugin.Toast;
using System;
using Xamarin.Forms;

namespace MeteoAppSkeleton.Views
{
    partial class AddNewLocation : ContentPage
    {
        public string EntryText { get; set; } = "My Label Text";
        public AddNewLocation() { 
            InitializeComponent(); 
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {

            string t = EntryLocation.Text;

            if (t != null)
            {

                MeteoController meteoController = MeteoController.getInstance();


                Place place = meteoController.requestMeteoByPlace(t);
                if (place == null)
                     await DisplayAlert("Location " + t + " not found", "", "OK");
                else
                {
                    await DisplayAlert("Location " + t + " added", "", "OK");
                    MeteoListViewModel.getInstance().add(place);
                    place.addIcon(place.meteo.weather[0].icon);


                }

            }
            EntryLocation.Text = "";




        }
    }
}
