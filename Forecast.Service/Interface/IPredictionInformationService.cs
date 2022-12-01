using Forecast.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forecast.Service.Interface
{
    public interface IPredictionInformationService
    {
        BaseResponseViewModel CreateForecast(ForecastInformationRequestModel model);

        ForecastInformationResponseViewModel GetForecastByDate(DateTime date);
        ForecastInformationResponseViewModel GetForecastByMail(string emailAddress);
        BaseResponseViewModel DeleteForecast(Guid id);

    }
}
