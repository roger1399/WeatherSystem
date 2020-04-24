using System.Linq;
using GlobalWeatherData.Models;
using GlobalWeatherData.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GlobalWeatherData.Controllers
{
    public class WeatherDataWebController : Controller
    {
        private IWeatherDataService _weatherDataService; 

        public WeatherDataWebController(IWeatherDataService weatherDataService)
        {
            _weatherDataService = weatherDataService;
        }
        // GET: WeatherDataWeb   this is already set in the startup routes this is not needed
         [HttpGet]
        public ActionResult Index()
        {
            WeatherDataViewModel model = new WeatherDataViewModel();

            model.Countries = _weatherDataService.GetCountryList().
                              Select(country => new SelectListItem() {Text = country , Value = country }).ToList();

            model.Cities = _weatherDataService.GetCityList(model.Countries[0].Value).
                            Select(City => new SelectListItem() { Text = City, Value = City }).ToList();


            model.Country = model.Countries[0].Value;
            model.City = model.Cities[0].Value;

            model.CityWeatherData = _weatherDataService.GetWeather(model.Countries[0].Value, model.Cities[0].Value);

            return View(model);
        }

    }
}