using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherMvc.Models
{
    public class WeatherData
    {
        public DateTime Date { get; set; }
        public string Summary { get; set; }
        public int TemperatureF { get; set; }
        public int TemperatrueC { get; set; }
    }
}
