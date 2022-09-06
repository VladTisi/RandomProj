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
            var user = _context.Angajats.FirstOrDefault(x => x.Id == angajatId);
            return _context.Angajats.Include(x => x.Concediu).Include(x => x.Functie)
                .Select(x => new Dto { Nume = x.Nume, Prenume = x.Prenume, Functie = x.Functie.Nume, DataInceput = x.Concediu.DataInceput, DataSfarsit = x.Concediu.DataSfarsit }).ToList();
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
