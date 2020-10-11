using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TravelPlanner.Core
{
    [DataContract]
    public class WeatherForecast
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public double WindSpeed { get; set; }

        [DataMember]
        public double WindDirection { get; set; }

        [DataMember]
        public double Visibility { get; set; }

        [DataMember]
        public double Cloudiness { get; set; }

        [DataMember]
        public IEnumerable<WeatherProperties> Weather { get; set; }

        [DataMember]
        public double Temperature { get; set; }

        [DataMember]
        public double TemperatureFeels{ get; set; }

        [DataMember]
        public double MinimalTemperature { get; set; }

        [DataMember]
        public double MaximalTemperature { get; set; }

        [DataMember]
        public double Presurre { get; set; }

        [DataMember]
        public double Humidity { get; set; }

        public class WeatherProperties
        {
            [DataMember]
            public string WeatherName { get; set; }

            [DataMember]
            public string WeatherDescription { get; set; }

            [DataMember]
            public string WeatherIcon { get; set; }
        }
    }
}