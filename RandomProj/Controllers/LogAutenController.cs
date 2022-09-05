using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogAutenController : ControllerBase
    {

        PrisonBreakContext _context;
        private readonly ILogger<LogAutenController> _logger;

        public LogAutenController(PrisonBreakContext context,ILogger<LogAutenController> logger)
        {
            _context=context;
            _logger=logger;
        }
        [HttpGet(Name = "LogAuten")]
        public List<Login> GetPassword(string email)
        {
            //return _context.Logins.Include(x => x.TipConcediu)
            //    .Select(x => new Concediu() { Id=x.Id, TipConcediu=x.TipConcediu })
            //    .Where(x => x.TipConcediu.Id==1).ToList();
            return _context.Logins.
                Select(x => new Login() { Parola=x.Parola, Email=x.Email })
                .Where(x => x.Email==$"{email}").ToList();
        }






    }
}
