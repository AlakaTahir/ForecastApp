using System;
using System.Collections.Generic;
using System.Text;

namespace Forecast.Model.ViewModel
{
    public class ForecastInformationRequestModel
    {
        public double WetBulb { get; set; }
        public double DryBulb { get; set; }
        public string Email { get; set; }
        public double MinimumTemperature { get; set; }
        public double MaximumTemperature { get; set; }
        public DateTime ForecastDate { get; set; }

    }
}
