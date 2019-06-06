using GlobalWeatherData.Models;
using GlobalWeatherData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalWeatherData.WeatherMockData
{

    public class MockWeatherDataService: IWeatherDataService
    {
        private List<WeatherRecord> WeatherRecords { get; set; }

        public  MockWeatherDataService()
        {
            WeatherRecord Aus_Data = new WeatherRecord();
            Aus_Data.Country = "Australia";
            Aus_Data.Cities.Add(new City { Name = "Sydney", CityWeatherData = new CityWeatherData { Wind = "Strong", Pressure = "1008 hpa", SkyCondition = "Clear", Temperature = 31.3, Time = DateTime.Now.ToString(), Visibility = "Good" } });
            Aus_Data.Cities.Add(new City { Name = "Melbourne", CityWeatherData = new CityWeatherData { Wind = "Strong", Pressure = "1008 hpa", SkyCondition = "Clear", Temperature = 10.3, Time = DateTime.Now.ToString(), Visibility = "Bad" } });
            Aus_Data.Cities.Add(new City { Name = "Perth", CityWeatherData = new CityWeatherData { Wind = "Strong", Pressure = "1008 hpa", SkyCondition = "Clear", Temperature = 31.3, Time = DateTime.Now.AddHours(-3).ToString(), Visibility = "Good" } });

            WeatherRecord NZ_Data = new WeatherRecord();
            NZ_Data.Country = "New Zealand";
            NZ_Data.Cities.Add(new City { Name = "Auckland", CityWeatherData = new CityWeatherData { Wind = "Strong", Pressure = "1008 hpa", SkyCondition = "Clear", Temperature = 31.3, Time = DateTime.Now.AddHours(+2).ToString(), Visibility = "Good" } });
            NZ_Data.Cities.Add(new City { Name = "Wellington", CityWeatherData = new CityWeatherData { Wind = "Strong", Pressure = "1008 hpa", SkyCondition = "Cloudy", Temperature = 31.3, Time = DateTime.Now.AddHours(+1).ToString(), Visibility = "Normal" } });

            this.WeatherRecords = new List<WeatherRecord>();
            WeatherRecords.Add(Aus_Data);
            WeatherRecords.Add(NZ_Data);
        }


        public IEnumerable<string> GetCountryList()
        {
            return this.WeatherRecords.Select(rec => rec.Country).ToList();
        }


        public IEnumerable<string> GetCityList(string Country)
        {
               return this.WeatherRecords.Where(rec => rec.Country.Equals(Country, StringComparison.CurrentCultureIgnoreCase))
                                            .Single().Cities.Select(city => city.Name).ToList();                                          
        }


        public CityWeatherData GetWeather(string Country , String City)
        {
            return this.WeatherRecords.Where(rec => rec.Country.Equals(Country, StringComparison.CurrentCultureIgnoreCase))
                                        .SingleOrDefault().Cities.Where(city => city.Name.Equals(City, StringComparison.CurrentCultureIgnoreCase))
                                        .Select(city => city.CityWeatherData).SingleOrDefault();
        }


        public bool CheckCountryExist(string Country)
        {
           return this.WeatherRecords.Where(rec => rec.Country.Equals(Country, StringComparison.CurrentCultureIgnoreCase))
                                           .Any();

        }

        public bool CheckCountryCityExist(string Country , string City)
        {
            return this.WeatherRecords.Where(rec => rec.Country.Equals(Country, StringComparison.CurrentCultureIgnoreCase))
                                            .Single().Cities.Where(city => city.Name.Equals(City,StringComparison.CurrentCultureIgnoreCase)).Any();

        }

    }

}