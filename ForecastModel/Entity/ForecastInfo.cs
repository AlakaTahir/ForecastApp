using System;
using System.Collections.Generic;
using System.Text;

namespace Forecast.Model.Entity
{
    public class ForecastInfo
    {
        public Guid Id { get; set; }
        public double MinimumTemperature { get; set; }
        public double MaximumTemperature { get; set; }
        public double RelativeHumidity { get; set; }
        public double Wind { get; set; }
        public double Pressure { get; set; }
        public char DefaultTemperatureSymbol { get; set; }
        public double WetBulb { get; set; }
        public double DryBulb { get; set; }
        public string Email { get; set; }
        public DateTime ForecastDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
