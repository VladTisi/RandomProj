using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        PrisonBreakContext _context;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, PrisonBreakContext context)
        {
            _logger = logger;
            _context=context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public List<Concediu> Get()
        {


            return _context.Concedius.Include(x => x.TipConcediu)
                .Select(x => new Concediu() { Id=x.Id, TipConcediu=x.TipConcediu})
                .Where(x => x.TipConcediu.Id==1).ToList();
        }

       
    }   

}     