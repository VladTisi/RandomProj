using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionareConcediiController : ControllerBase
    {

        PrisonBreakContext _context;
        private readonly ILogger<GestionareConcediiController> _logger;
        public GestionareConcediiController(ILogger<GestionareConcediiController> logger, PrisonBreakContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet("GetAdmin")]
        public bool GetAdmin(int angajatId)
        {
            var user = _context.Angajats.FirstOrDefault(x => x.Id == angajatId);

            if (user.EsteAdmin == true)
                return true;
            else return false;
        }

        [HttpGet("GetManager")]
        public bool GetManager(int angajatId)
        {
            var user = _context.Angajats.FirstOrDefault(x => x.Id == angajatId);
 
            if (user.IdFunctie == 3)
                return true;
            else 
                return false;
        }

        [HttpGet("GetConcedii")]
        public List<Dto> GetConcedii(int angajatId)
        {
            var lista = new List<Dto>();
            var user = _context.Angajats.FirstOrDefault(x => x.Id == angajatId);
            if (user.EsteAdmin==true)
            { 
            return _context.Concedius
                .Include(x => x.Angajat)
                .Include(x => x.Angajat.Functie)
                .Select(x => new Dto {Id=x.Id,Nume=x.Angajat.Nume,Prenume=x.Angajat.Prenume,Functie=x.Angajat.Functie.Nume,DataInceput=x.DataInceput,DataSfarsit=x.DataSfarsit }).ToList();
            }
            else if(user.IdFunctie==3)
            {
                return _context.Concedius
                .Include(x => x.Angajat)
                .Include(x => x.Angajat.Functie)
                .Where(x => x.StareConcediuId == 1 && x.Angajat.IdFunctie!=3 && x.Angajat.IdEchipa==user.IdEchipa)
                .Select(x => new Dto { Id = x.Id, Nume = x.Angajat.Nume, Prenume = x.Angajat.Prenume, Functie = x.Angajat.Functie.Nume, DataInceput = x.DataInceput, DataSfarsit = x.DataSfarsit }).ToList();
            }
            return lista;
        }

        [HttpPut("AprobaConcediu")]
        public void AprobaConcediu(int concediuId)
        {
            //_context.Concedius.Where(x => x.Id == concediuId).FirstOrDefault().StareConcediuId = 2;
            _context.Concedius.Where(x => x.Id == concediuId).FirstOrDefault().StareConcediuId = 2;
            _context.SaveChanges();
        }

        [HttpPut("RefuzaConcediu")]
        public void RefuzaConcediu(int concediuId)
        {
            _context.Concedius.Where(x => x.Id == concediuId).FirstOrDefault().StareConcediuId = 3;
            _context.SaveChanges();
        }
           
    }
}


