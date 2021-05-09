using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoAppSkeleton.Models
{
    public class Weather
    {
        [JsonProperty("id")]
        public long id { get; set; }
        [JsonProperty("main")]
        public String main { get; set; }
        [JsonProperty("description")]
        public String description { get; set; }
        [JsonProperty("icon")]
        public String icon { get; set; }

        
        override public String ToString()
        {
            return "Weather: " + main;
        }

        public Weather()
        {
        }

        public Weather(long id, String main, String description, String icon)
        {
            this.id = id;
            this.main = main;
            this.description = description;
            this.icon = icon;
        }


    }
}
