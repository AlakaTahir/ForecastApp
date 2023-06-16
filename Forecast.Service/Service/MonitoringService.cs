using Arch.EntityFrameworkCore.UnitOfWork;
using Forecast.Model.Entity;
using Forecast.Model.ViewModel;
using Forecast.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Service.Service
{
    public class MonitoringService : IMonitoringService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MonitoringService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ForecastInformationResponseViewModel> GetListofForecast(DateTime date, double dryBulb, double wetBulb)
        {
            var forecasts = _unitOfWork.GetRepository<ForecastInfo>().GetAll().Where(x => x.ForecastDate.Year == date.Year && x.ForecastDate.Month == date.Month && x.ForecastDate.Day == date.Day && (x.WetBulb >= wetBulb -1 && x.WetBulb <= wetBulb + 1) && (x.DryBulb >= dryBulb - 1 && x.DryBulb <= dryBulb + 1)).ToList();
            
            if (forecasts.Count != 0) 
            {
                var response = new List<ForecastInformationResponseViewModel>();
                foreach (var forecast in forecasts)
                {
                    var singleModel = new ForecastInformationResponseViewModel();
                    singleModel.DryBulb = forecast.DryBulb;
                    singleModel.Wetbulb = forecast.WetBulb;
                    singleModel.CreatedDate = forecast.CreatedDate;
                    singleModel.Email = forecast.Email;

                    response.Add(singleModel);

                }
                return response;

            }

            else
            {
                return null;
            }
        }





    }
}
