
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace loca_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStringLocalizer<SharedResources> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            return Ok(_localizer["hi"]);
        }
    }
}