using MeteoAppSkeleton.Controller;
using MeteoAppXF.Models;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;


namespace MeteoAppSkeleton.Models
{
    public class Place
    {
        public Guid uuid { get; set; }
        public Position position { get; set; }
        public Meteo meteo { get; set; }
        public String name { get; set; }
        public String image { get; set; }

        public Place(PlaceDBElement p)
        {
            this.uuid = p.uuid;
            this.name = p.name;
        }
        public Place(Guid uuid, Position position, String name, Meteo meteo)
        {
            this.uuid = uuid;
            this.position = position;
            this.name = name;
            this.meteo = meteo;

        }
      
        public Place(Guid uuid, String name)
        {
            this.uuid = uuid;
            this.name = name;
            GetLocation();
        }


        public void updateMeteo(String s)
        {
            this.meteo = MeteoController.getInstance().jsonToMeteo(s);
        }

        async void GetLocation()
        {
            var locator = CrossGeolocator.Current; // singleton
            this.position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            if (position != null)
            {
                meteo = MeteoController.getInstance().requestMeteoByCoordinates(position.Latitude, position.Longitude);
                this.name = meteo.name;
                this.image = "";
            }

        }
    }
}
