using LenhASP.Controllers.Base;
using LenhASP.Domain.Entities;
using LenhASP.Domain.Services;
using LenhASP.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace LenhASP.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : GenericController<Guid, WeatherForecast, ApplicationDbContext>
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            //ISeedService service,
            IGenericService<WeatherForecast, ApplicationDbContext> genericService,
            ILogger<WeatherForecastController> logger
        ) : base(genericService)
        {
            //_service = service;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetSample()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}