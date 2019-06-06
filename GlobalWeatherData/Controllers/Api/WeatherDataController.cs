using GlobalWeatherData.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GlobalWeatherData.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/WeatherData")]
    public class WeatherDataController : Controller
    {
        private IWeatherDataService _weatherDataService;

        public WeatherDataController(IWeatherDataService weatherDataService)
        {
            _weatherDataService = weatherDataService;
        }

        [HttpGet]
        [Route("GetCountries")]
        public IActionResult GetCountries()
        {
            try
            {
                return Ok(_weatherDataService.GetCountryList());
            }
            catch
            {
                //log error
                return StatusCode((int)HttpStatusCode.InternalServerError, "Server offline please try again later");
            }
            
        }

        [HttpGet]
        [Route("Country/{country}/GetCities")]
        public IActionResult GetCities(string Country)
        {
            try
            {
                Country = Country.Trim();
                if (_weatherDataService.CheckCountryExist(Country))
                { return Ok(_weatherDataService.GetCityList(Country)); }
                else
                {
                    return NotFound(string.Format("{0} not found", Country));
                }
            }
            catch
            {
                //log error
                return StatusCode((int)HttpStatusCode.InternalServerError, "Server offline please try again later");
            }
        }

        [HttpGet]
        [Route("Country/{country}/City/{city}/GetWeather")]
        public IActionResult GetWeather(string Country , string City)
        {
            try
            {
                Country = Country.Trim();
                City = City.Trim();
                if (_weatherDataService.CheckCountryCityExist(Country, City))
                { return Ok(_weatherDataService.GetWeather(Country, City)); }
                else
                {
                    return NotFound(string.Format("{0} City does not exist in {1}", City, Country));
                }
            }
            catch
            {
                //log error
                return StatusCode((int)HttpStatusCode.InternalServerError, "Server offline please try again later");
            }
        }


    }
}