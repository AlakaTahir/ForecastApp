using System;
using System.Collections.Generic;
using System.Text;

namespace Forecast.Model.ViewModel
{
    public class BaseResponseViewModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public double Forecast { get; set; }
    }
}

