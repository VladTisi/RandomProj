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
        [HttpGet("GetPassword")]
        public List<Login> GetPassword(string email)
        {
            //return _context.Echipas.Include(x => x.Echipa)
            //    .Select(x => new Concediu() { Id=x.Id, TipConcediu=x.TipConcediu })
            //    .Where(x => x.TipConcediu.Id==1).ToList();

            return _context.Logins.
                Select(x => new Login() { Parola=x.Parola, Email=x.Email, AngajatId = x.AngajatId })
                .Where(x => x.Email==$"{email}").ToList();
        }

        [HttpPost("InsertLogin")]
        public void InsertLogin(string email,  string password)
        {
            _context.Logins.Add(new Login() { Parola = password, Email=email });
            _context.SaveChanges();
        }
        [HttpGet("GetIdFromEmail")]
        public List<Login> GetIdFromLogin(string email)
        {
           return _context.Logins
                .Select(x => new Login() { Id=x.Id, Email=x.Email })
                .Where(x =>x.Email==$"{email}").ToList();
        }

        [HttpGet("GetAngajatIdFromEmail")]
        public List<Login> GetAngajatId(string email)
        {
            return _context.Logins
                 .Select(x => new Login() { AngajatId=x.AngajatId, Email=x.Email })
                 .Where(x => x.Email==$"{email}").ToList();
        }

        [HttpPost("UpdatePassword")]
        public void UpdatePassword(string password,int angajatid)
        {
            _context.Logins.Where(x => x.AngajatId==angajatid).First().Parola=password;
            _context.SaveChanges();
        }








    }
}
