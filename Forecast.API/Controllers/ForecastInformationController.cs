using Forecast.Model.ViewModel;
using Forecast.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Forecast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastInformationController : ControllerBase
    {
        private readonly IPredictionInformationService _predictionInformationService;
        public ForecastInformationController(IPredictionInformationService predictionInformationService)
        {
            _predictionInformationService = predictionInformationService;
        }


        [HttpPost("CreateForecast")]
        public IActionResult CreateForecast(ForecastInformationRequestModel model) 
        {
         var response = _predictionInformationService.CreateForecast(model);
            return Ok(response);
        } 
        [HttpGet("GetForecastByDate")]
        public IActionResult GetForecastByDate(DateTime date)
        {
            var response =_predictionInformationService.GetForecastByDate(date);
            return Ok(response);
        }
        [HttpGet("GetForecastByMail")]
        public IActionResult GetForecastByMail(string emailAddress)
        {
            var response = _predictionInformationService.GetForecastByMail(emailAddress);
            return Ok(response);
        }
        [HttpDelete("DeleteForecast")]
        public IActionResult DeleteForecast(Guid id) 
        {
         var response = _predictionInformationService.DeleteForecast(id);
            return Ok(response);
        }
    }
}
