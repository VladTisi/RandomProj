using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchipaController : ControllerBase
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
            //var user = _context.Angajats.FirstOrDefault(x => x.Id == angajatId);
            var user = _context.Angajats.FirstOrDefault(x => x.Id == angajatId);
            return _context.Concedius
                .Include(x => x.Angajat)
                .Include(x => x.Angajat.Functie)
                .Where(x=>x.Angajat.IdEchipa==user.IdEchipa && x.StareConcediuId==2 && (x.DataInceput>=DateTime.Now || x.DataSfarsit>=DateTime.Now) )
                .Select(x => new Dto {Nume = x.Angajat.Nume, Prenume = x.Angajat.Prenume, Functie = x.Angajat.Functie.Nume, DataInceput = x.DataInceput, DataSfarsit = x.DataSfarsit }).ToList();
        }
        [HttpGet("GetEchipa")]
        public List<Member> GetEchipa(int angajatId)
        {
            var user = _context.Angajats.FirstOrDefault(x => x.Id == angajatId);
            return _context.Angajats.Include(x => x.Functie)
                .Where(x => x.IdEchipa == user.IdEchipa && x.IdFunctie==x.Functie.Id)
                .Select(x => new Member {
                    Id= x.Id, 
                    Nume = x.Nume, 
                    Prenume = x.Prenume, 
                    Functia = x.Functie.Nume, 
                    DataAngajarii=x.DataAngajarii 
                }).ToList();
        }

        [HttpGet("GetGot")]
        public List<Member> GetGot()
        {
            return _context.Angajats
                .Include(x => x.Functie)
                .Where(x => x.IdEchipa ==2)
                .Select(x => new Member
                {
                    Id = x.Id,
                    Nume = x.Nume,
                    Prenume = x.Prenume,
                    Poza = x.Poza,
                    Functia = x.Functie.Nume,
                    DataAngajarii = x.DataAngajarii
                }).ToList();
        }


        [HttpGet("GetStranger")]
        public List<Member> GetStranger()
        {
            return _context.Angajats
                .Include(x => x.Functie)
                .Where(x => x.IdEchipa == 1)
                .Select(x => new Member
                {
                    Id = x.Id,
                    Nume = x.Nume,
                    Prenume = x.Prenume,
                    Poza = x.Poza,
                    Functia = x.Functie.Nume,
                    DataAngajarii = x.DataAngajarii
                }).ToList();
        }


        [HttpGet("GetBB")]
        public List<Member> GetBB()
        {
            return _context.Angajats
                .Include(x => x.Functie)
                .Where(x => x.IdEchipa == 3)
                .Select(x => new Member
                {
                    Id = x.Id,
                    Nume = x.Nume,
                    Poza = x.Poza,
                    Prenume = x.Prenume,
                    Functia = x.Functie.Nume,
                    DataAngajarii = x.DataAngajarii
                }).ToList();
        }

    }
}
