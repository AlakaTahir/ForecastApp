using System;
using System.Collections.Generic;
using System.Text;

namespace Forecast.Model.ViewModel
{
     public class ForecastInformationResponseViewModel
    {
        public double Wetbulb { get; set; }
        public double DryBulb { get; set; }
       
        public DateTime ForecastDate { get; set; }
        public double MinimumTemperature { get; set; }
        public double MaximumTemperature { get; set; }
        public double RelativeHumidity { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }

 }
