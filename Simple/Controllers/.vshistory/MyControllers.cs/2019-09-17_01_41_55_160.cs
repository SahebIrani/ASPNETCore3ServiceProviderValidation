using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

namespace Simple.Controllers
{
    [ApiController, Route("[controller]")]
    public class MyControllers : ControllerBase
    {
        private readonly WeatherForecastService _service;
        public MyControllers(WeatherForecastService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _service.GetForecasts();
        }
    }
}
