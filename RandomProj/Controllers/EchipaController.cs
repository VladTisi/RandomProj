using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchipaController : Controller
    {
        PrisonBreakContext _context;
        private readonly ILogger<EchipaController> _logger;
        public EchipaController(ILogger<EchipaController> logger, PrisonBreakContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet("GetConcediiEchipa")]
        public List<Dto> GetConcediiEchipa(int angajatId)
        {
            
        }
        [HttpGet("GetEchipa")]
        public List<Member> GetEchipa(int angajatId)
        {
            var user = _context.Angajats.FirstOrDefault(x => x.Id == angajatId);
            return _context.Angajats.Include(x => x.Functie)
                .Where(x => x.IdEchipa == user.IdEchipa && x.IdFunctie==x.Functie.Id)
                .Select(x => new Member { Nume = x.Nume, Prenume = x.Prenume, Functia = x.Functie.Nume }).ToList();
         
        }
    }
}
