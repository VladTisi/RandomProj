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

        [HttpGet("GetConcediuRefuzat")]

        public List<Concediuedt> GetConcediuRefuzat(int angajatId)
        {
            var lista = new List<Concediuedt>();
            var user = _context.Angajats.FirstOrDefault(x => x.Id == angajatId);
            return _context.Concedius
                   .Include(x => x.Angajat)
                   .Include(x => x.Angajat.Functie)
                   .Include(x => x.StareConcediu)
                   .Where(x => x.StareConcediuId == 3 && x.StareConcediu.Id == x.StareConcediuId)
                   .Select(x => new Concediuedt { Id = x.Id, Nume = x.Angajat.Nume, Prenume = x.Angajat.Prenume, Functie = x.Angajat.Functie.Nume, Status = x.StareConcediu.Nume, DataInceput = x.DataInceput, DataSfarsit = x.DataSfarsit }).ToList();
            return lista;
        }

        [HttpGet("GetConcedii")]
        public List<Concediuedt> GetConcedii(int angajatId)
        {
            var lista = new List<Concediuedt>();
            var user = _context.Angajats.FirstOrDefault(x => x.Id == angajatId);
            if (user.EsteAdmin == true)
            {
                return _context.Concedius
                    .Include(x => x.Angajat)
                    .Include(x => x.Angajat.Functie)
                    .Include(x => x.StareConcediu)
                    .Where(x => x.StareConcediuId == 1 && x.StareConcediu.Id == x.StareConcediuId)
                    .Select(x => new Concediuedt { Id = x.Id, Nume = x.Angajat.Nume, Prenume = x.Angajat.Prenume, Functie = x.Angajat.Functie.Nume, Status = x.StareConcediu.Nume, DataInceput = x.DataInceput, DataSfarsit = x.DataSfarsit }).ToList();
            }
            else if (user.IdFunctie == 3)
            {
                return _context.Concedius
                .Include(x => x.Angajat)
                .Include(x => x.Angajat.Functie)
                .Include(x => x.StareConcediu)
                .Where(x => x.StareConcediuId == 1 && x.Angajat.IdFunctie != 3 && x.StareConcediu.Id == x.StareConcediuId && x.Angajat.IdEchipa == user.IdEchipa)
                .Select(x => new Concediuedt { Id = x.Id, Nume = x.Angajat.Nume, Prenume = x.Angajat.Prenume, Functie = x.Angajat.Functie.Nume, Status = x.StareConcediu.Nume, DataInceput = x.DataInceput, DataSfarsit = x.DataSfarsit }).ToList();
            }
            return lista;
        }

        [HttpPut("AprobaConcediu")]
        public void AprobaConcediu(int concediuId)
        {
            _context.Concedius.Where(x => x.Id == concediuId).FirstOrDefault<Concediu>().StareConcediuId = 2;
            //.Select(x=>new Concediu() { Id=x.Id,TipConcediuId=x.TipConcediuId,DataInceput=x.DataInceput,DataSfarsit=x.DataSfarsit,InlocuitorId=x.InlocuitorId,Comentarii=x.Comentarii,StareConcediuId=x.StareConcediuId,AngajatId=x.AngajatId})
            _context.SaveChanges();
        }

        [HttpPut("RefuzaConcediu")]
        public void RefuzaConcediu(int concediuId)
        {
            _context.Concedius.Where(x => x.Id == concediuId).FirstOrDefault<Concediu>().StareConcediuId = 3;
            _context.SaveChanges();
        }

        [HttpGet("GetNumePrenume")]
        public List<Angajat> GetNumePrenume(int IdInlocuitor)
        {

            return _context.Angajats
                .Include(x => x.Concedius)
                .Select(x => new Angajat()
                {
                    Nume = x.Nume,
                    Prenume = x.Prenume,
                    Id = x.Id
                }
                ).Where(x => x.Id == IdInlocuitor).ToList();

        }
    }
}


