using Arch.EntityFrameworkCore.UnitOfWork;
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
        private readonly IUnitOfWork _unitOfWork;
        public PredictionInformationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        //check if a record exist using email and date

        public BaseResponseViewModel CreateForecast(ForecastInformationRequestModel model)
        {
            var prediction = _unitOfWork.GetRepository<ForecastInfo>().GetFirstOrDefault(predicate: x=> x.Email == model.Email && x.ForecastDate.Year == model.ForecastDate.Year && x.ForecastDate.Month == model.ForecastDate.Month && x.ForecastDate.Day == model.ForecastDate.Day);
            if (prediction == null)
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

                _unitOfWork.GetRepository<ForecastInfo>().Insert(info);
                _unitOfWork.SaveChanges();

                return new BaseResponseViewModel
                {
                    Message = "Created Successfully",
                    Status = true
                };

            }
            else
            {
                prediction.MinimumTemperature = model.MinimumTemperature;
                prediction.MaximumTemperature = model.MaximumTemperature;
                prediction.WetBulb = model.WetBulb;
                prediction.DryBulb = model.DryBulb;
                prediction.Email = model.Email;
                prediction.UpdatedDate = DateTime.Now;
                _unitOfWork.GetRepository<ForecastInfo>().Update(prediction);
                _unitOfWork.SaveChanges();

                return new BaseResponseViewModel
                {
                    Message = "Forecast Updated Successfully",
                    Status = false
                };

            }

        }

        public ForecastInformationResponseViewModel GetForecastDateByEmail(DateTime date, string email)
        {
            var Forecast = _unitOfWork.GetRepository<ForecastInfo>().GetFirstOrDefault(predicate: x => x.ForecastDate.Year == date.Year && x.ForecastDate.Month == date.Month && x.ForecastDate.Day == date.Day && x.Email ==  email);
            if (Forecast != null)
            {
                return new ForecastInformationResponseViewModel
                {
                    DryBulb = Forecast.DryBulb,
                    MaximumTemperature = Forecast.MaximumTemperature,
                    MinimumTemperature = Forecast.MinimumTemperature,
                    Wetbulb = Forecast.WetBulb,
                    CreatedDate = Forecast.CreatedDate,
                    Email = Forecast.Email
                };
            }
            else
            {
                return null;
            }
        }

        public List<ForecastInformationResponseViewModel> GetForecastByDate(DateTime date) //4: 23: 37 PM, Satuday 24, February, 2022.
        {
            var forecasts = _unitOfWork.GetRepository<ForecastInfo>().GetAll().Where(x => x.ForecastDate.Year == date.Year && x.ForecastDate.Month == date.Month && x.ForecastDate.Day == date.Day).ToList();
            
            if (forecasts.Count != 0)
            {
                var response = new List<ForecastInformationResponseViewModel>();

                foreach (var forecast in forecasts)
                {
                    var singleModel = new ForecastInformationResponseViewModel();
                    singleModel.DryBulb = forecast.DryBulb;

                    singleModel.MaximumTemperature = forecast.MaximumTemperature;
                    singleModel.MinimumTemperature = forecast.MinimumTemperature;
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

        public ForecastInformationResponseViewModel GetForecastByMail(string emailAddress)
        {
            var Forecast = _unitOfWork.GetRepository<ForecastInfo>().GetFirstOrDefault(predicate: x => x.Email == emailAddress);
            if (Forecast != null)
            {
                return new ForecastInformationResponseViewModel
                {
                    DryBulb = Forecast.DryBulb,
                    Wetbulb = Forecast.WetBulb,
                    MaximumTemperature = Forecast.MaximumTemperature,
                    MinimumTemperature = Forecast.MinimumTemperature,
                    CreatedDate = Forecast.CreatedDate,
                    Email = Forecast.Email
                };
            }
            else
            {
                return null;
            }
        }

        public BaseResponseViewModel DeleteForecast(Guid id) 
        {
            var Forecast = _unitOfWork.GetRepository<ForecastInfo>().GetFirstOrDefault(predicate: x => x.Id == id);
            if (Forecast != null)
            {
                _unitOfWork.GetRepository<ForecastInfo>().Delete(Forecast);
                _unitOfWork.SaveChanges();

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
