Developed by - Roger Perera
.net Framework - Net core 2.0  
Vs 2017 community

Endpoint urls

weburl - http://localhost:49739/WeatherDataWeb/index   or http://localhost:49739 Since default route is defined. 

WebAPI end points
http://localhost:49739/api/WeatherData/GetCountries/  - Get list of countries available
http://localhost:49739/api/WeatherData/Country/Australia/GetCities     - Get list of cities for a spfied country
http://localhost:49739/api/WeatherData/Country/Australia/City/Sydney/GetWeather   - Get weather infomation for a city in specific country 


 The web page communicates with the webapi through Ajax to desplay information. 


Test project -GlobalWeatherDataTest