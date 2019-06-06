using System.Collections.Generic;

namespace GlobalWeatherData.Models
{
    public class WeatherRecord
    {

        public string Country { get; set; }

        public List<City> Cities { get; set; }

        public WeatherRecord()
        {
            this.Cities = new List<City>();
        }
    }
}
