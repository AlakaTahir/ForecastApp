using Forecast.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forecast.Service.Interface
{
    public interface IMonitoringService
    {
        List<ForecastInformationResponseViewModel> GetListofForecast(DateTime date, double dryBulb, double wetBulb);

    }
}
