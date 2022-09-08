using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchimbareParolaController : ControllerBase
    {
        PrisonBreakContext _context;
        private readonly ILogger<SchimbareParolaController> _logger;

        public SchimbareParolaController(PrisonBreakContext context, ILogger<SchimbareParolaController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("GetPassword")]
        public string GetPasswordFromId(int AngajatId)
        {
            return _context.Logins.Where(x => x.AngajatId == AngajatId).
            Select(x => x.Parola).ToList().FirstOrDefault();
                                                              
        }

        [HttpPost("UpdatePassword")]

        public void UpdatePassword(string password, int AngajatId)
        {
            _context.Logins.Where(x => x.AngajatId == AngajatId).First().Parola = password;
            _context.SaveChanges();
        }
    }
}
