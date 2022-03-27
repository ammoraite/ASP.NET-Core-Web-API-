using First_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace First_API
{
    public class WetherForCastHolder
    {
        public List<WeatherForecast> Values { get; internal set; }

        public void Add(WeatherForecast input)
        {
            if( Values == null)
            {
                Values=new List<WeatherForecast>(){input};
            }
            else { Values.Add(input);}
        }

        internal List<WeatherForecast> Get()
        {

            if (Values == null)
            {
               return Values = new List<WeatherForecast>();
            }
            else { return Values; }
        }
    }
}