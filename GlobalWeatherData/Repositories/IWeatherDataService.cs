using GlobalWeatherData.Models;
using System;
using System.Collections.Generic;

namespace GlobalWeatherData.Repositories
{
    public interface IWeatherDataService
    {
        IEnumerable<string> GetCountryList();
        IEnumerable<string> GetCityList(string Country);
        CityWeatherData GetWeather(string Country, String City);
        bool CheckCountryExist(string Country);
        bool CheckCountryCityExist(string Country, string City);

    }
}
