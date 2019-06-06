using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlobalWeatherData.Controllers.Api;
using GlobalWeatherData.WeatherMockData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GlobalWeatherData.Models;
using System;
using GlobalWeatherData.Controllers;
using System.Linq;

namespace GlobalWeatherDataTest
{
    [TestClass]
    public class WeatherDataTest
    {
        [TestMethod]
        public void TestGetCountriesAPI()
        {  //Arrange
            MockWeatherDataService mockService = new MockWeatherDataService();
            WeatherDataController service = new WeatherDataController(mockService);

            //Act 
            var result = service.GetCountries() as OkObjectResult;
            var countrylist = result.Value as List<string>;
            //Asset  
            Assert.AreEqual(2 , countrylist.Count);

        }

        [TestMethod]
        public void TestGetCitiesForAustraliaAPI()
        {  //Arrange
            MockWeatherDataService mockService = new MockWeatherDataService();
            WeatherDataController service = new WeatherDataController(mockService);

            //Act 
            var result = service.GetCities("Australia") as OkObjectResult;
            var citylist = result.Value as List<string>;
            //Asset   
            var count = citylist.Where(city => new string[] { "Sydney", "Melbourne", "Perth" }.Contains(city)).ToList().Count();
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void TestGetCitiesForInvalidCountryAPI()
        {  //Arrange
            MockWeatherDataService mockService = new MockWeatherDataService();
            WeatherDataController service = new WeatherDataController(mockService);

            //Act 
            var result = service.GetCities("Japan") as NotFoundObjectResult;
            var response = result.Value as string;
            //Asset  
            Assert.AreEqual("Japan not found", response);
        }

        [TestMethod]
        public void TestGetWeatherAPI()
        {  //Arrange
            MockWeatherDataService mockService = new MockWeatherDataService();
            WeatherDataController service = new WeatherDataController(mockService);
            CityWeatherData sydneyData = new CityWeatherData { Wind = "Strong", Pressure = "1008 hpa", SkyCondition = "Clear", Temperature = 31.3, Time = DateTime.Now.ToString(), Visibility = "Good" };

            //Act 
            var result = service.GetWeather("Australia","Sydney") as OkObjectResult;
            var response = result.Value as CityWeatherData;
            //Asset  
            Assert.AreEqual(sydneyData, response);
        }

        [TestMethod]
        public void TestGetWeatherForInValidCityAPI()
        {  //Arrange
            MockWeatherDataService mockService = new MockWeatherDataService();
            WeatherDataController service = new WeatherDataController(mockService);

            //Act 
            var result = service.GetWeather("Australia", "Tokyo") as NotFoundObjectResult;
            var response = result.Value as string;
            //Asset  
            Assert.AreEqual("Tokyo City does not exist in Australia", response);
        }

        [TestMethod]
        public void WebIndexAction()
        {  //Arrange
            MockWeatherDataService mockService = new MockWeatherDataService();
            WeatherDataWebController Contoller = new WeatherDataWebController(mockService);

            //Act 
            var result = Contoller.Index() as ViewResult;
            
            //Asset  
            Assert.AreEqual(2, (result.Model as WeatherDataViewModel).Countries.Count);
        }
    }
}
