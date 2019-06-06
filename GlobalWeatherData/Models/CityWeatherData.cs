using System;
using System.ComponentModel;

namespace GlobalWeatherData.Models
{
    public class CityWeatherData
    {
        public String Time { get; set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }
        public string SkyCondition { get; set; }
        [DisplayName("Temperature Celcius")]
        public double Temperature { get; set; }
        public string Pressure { get; set; }

        public override bool Equals(object obj)
        {
            CityWeatherData compairObj = (CityWeatherData)obj;

            if (this.Time.Equals(compairObj.Time) && this.Wind.Equals(compairObj.Wind)
                && this.Visibility.Equals(compairObj.Visibility) && this.SkyCondition.Equals(compairObj.SkyCondition)
                && this.Temperature.Equals(compairObj.Temperature) && this.Pressure.Equals(compairObj.Pressure))

                return true;
            else
            {
                return false;
            }

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    } 
  
}
