using Forecast.Migrations;
using Forecast.Model.Entity;
using Forecast.Model.ViewModel;
using Forecast.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forecast.Service.Service
{
    public class PredictionInformationService : IPredictionInformationService
    {
        private readonly ForecastInformationDataBaseContext _context;
        public PredictionInformationService(ForecastInformationDataBaseContext context)
        {
            _context = context;
        }

        public BaseResponseViewModel CreateForecast(ForecastInformationRequestModel model)
        {
            var Prediction = _context.ForecastInfos.FirstOrDefault(x => x.ForecastDate == model.ForecastDate);
            if (Prediction == null)
            {
                var info = new ForecastInfo();
                info.Id = Guid.NewGuid();
                info.MinimumTemperature = model.MinimumTemperature;
                info.MaximumTemperature = model.MaximumTemperature;
                info.WetBulb = model.WetBulb;
                info.DryBulb = model.DryBulb;
                info.Email = model.Email;
                info.CreatedDate = DateTime.Now;
                info.ForecastDate = model.ForecastDate;

                return new BaseResponseViewModel
                {
                    Message = "Created Successfully",
                    Status = true
                };

            }
            else
            {
                Prediction.MinimumTemperature = model.MinimumTemperature;
                Prediction.MaximumTemperature = model.MaximumTemperature;
                Prediction.WetBulb = model.WetBulb;
                Prediction.DryBulb = model.DryBulb;
                Prediction.Email = model.Email;
                Prediction.UpdatedDate = DateTime.Now;
                _context.ForecastInfos.Update(Prediction);
                _context.SaveChanges();

                return new BaseResponseViewModel
                {
                    Message = "Forecast Updated Successfully",
                    Status = false
                };

            }

        }

        public ForecastInformationResponseViewModel GetForecastByDate(DateTime date)
        {
            var Forecast = _context.ForecastInfos.FirstOrDefault(x => x.ForecastDate.Year == date.Year && x.ForecastDate.Month == date.Month && x.ForecastDate.Day == date.Day);
            if (Forecast != null)
            {
                return new ForecastInformationResponseViewModel
                {
                    DryBulb = Forecast.DryBulb,
                    MaximumTemperature = Forecast.MaximumTemperature,
                    MinimumTemperature = Forecast.MinimumTemperature,
                    Wetbulb = Forecast.WetBulb,
                    CreatedDate = Forecast.CreatedDate

                };
            }
            else
            {
                return null;
            }
        }

        public ForecastInformationResponseViewModel GetForecastByMail(string emailAddress)
        {
            var Forecast = _context.ForecastInfos.FirstOrDefault(x => x.Email == emailAddress);
            if (Forecast != null)
            {
                return new ForecastInformationResponseViewModel
                {
                    DryBulb = Forecast.DryBulb,
                    Wetbulb = Forecast.WetBulb,
                    MaximumTemperature = Forecast.MaximumTemperature,
                    MinimumTemperature = Forecast.MinimumTemperature,
                    CreatedDate = Forecast.CreatedDate,
                };
            }
            else
            {
                return null;
            }
        }
        public BaseResponseViewModel DeleteForecast(Guid id) 
        {
            var Forecast = _context.ForecastInfos.FirstOrDefault(x => x.Id == id);
            if (Forecast != null)
            {
                _context.ForecastInfos.Remove(Forecast);
                _context.SaveChanges();

                return new BaseResponseViewModel 
                {
                    Message = "Successful",
                    Status = true
                };
            }
            else
            {
                return new BaseResponseViewModel
                {
                    Message = "Parameter does not exist",
                    Status = false
                };
            }



        }
    }
}
