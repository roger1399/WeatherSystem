using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GlobalWeatherData.Models
{
    public class WeatherDataViewModel
    {  
        public string Country { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public string City { get; set; }
        public List<SelectListItem> Cities { get; set; } 
        public CityWeatherData CityWeatherData { get; set; }

    }
}
