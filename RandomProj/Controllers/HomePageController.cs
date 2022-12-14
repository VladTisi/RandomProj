using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HomePageController : ControllerBase
    {
        PrisonBreakContext _context;
        private readonly ILogger<HomePageController> _logger;

        public HomePageController(PrisonBreakContext context, ILogger<HomePageController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("UpdateZile")]

        public void UpdateZileCO(int Id)
        {
            _context.Angajats.Where(x => x.Id == Id).FirstOrDefault();
            int? ZileRamase = _context.Angajats.Where(x => x.Id == Id).Sum(x => EF.Functions.DateDiffMonth(x.DataAngajarii, DateTime.Now) * 2);
            _context.Angajats.Where(x => x.Id == Id).FirstOrDefault().ZileConcediu = (int)ZileRamase;
            _context.SaveChanges();


        }


        [HttpPost("UpdateZileCORamase")]

        public void UpdateZileCORamase(int Id)
        {
            _context.Angajats.Where(x => x.Id == Id).FirstOrDefault();

            int? ZileTotale = _context.Angajats.Where(x => x.Id == Id).Sum(x => EF.Functions.DateDiffMonth(x.DataAngajarii, DateTime.Now) * 2);
            int? ZileConcediu = _context.Concedius.Where(x => x.AngajatId == Id && x.StareConcediuId == 2).Sum(x => EF.Functions.DateDiffDay(x.DataInceput, x.DataSfarsit) - EF.Functions.DateDiffWeek(x.DataInceput, x.DataSfarsit) * 2);
            if (ZileConcediu >= ZileTotale)
            {
                _context.Angajats.Where(x => x.Id == Id).FirstOrDefault().ZileConcediuRamase = 0;
                _context.SaveChanges();
                return;

            }

            else
            {
                _context.Angajats.Where(x => x.Id == Id).FirstOrDefault().ZileConcediuRamase = ((int)ZileTotale - (int)ZileConcediu);
                _context.SaveChanges();
                return;
            }
        }

        [HttpPost("UpdateTelf")]

        public void UpdateDateDeUtilizator(string? numarTelefon, int Id)

        {
            var myObj = _context.Angajats.Where(x => x.Id == Id).FirstOrDefault();
            if (myObj == null)
            {
                return;
            }

            myObj.NumarTelefon = String.IsNullOrEmpty(numarTelefon) ? myObj.NumarTelefon : numarTelefon;
            // myObj.Poza = String.IsNullOrEmpty(poza) ? myObj.Poza : poza;

            _context.SaveChanges();
        }
        [HttpGet("GetUtilizatori")]
        public List<Angajat> GetAllDataAngajat()
        {

            return _context.Angajats.
            Select(x => new Angajat() { Id = x.Id, Nume = x.Nume + " " + x.Prenume })
            .ToList();


        }
        [HttpGet("GetMembriEchipa")]
        public List<Angajat> GetAllMembers(int angajatId)
        {
            var user = _context.Angajats.Where(x => x.Id == angajatId).FirstOrDefault();
            return _context.Angajats
                .Where(x => x.IdEchipa == user.IdEchipa)
                .Select(x => new Angajat() { Id = x.Id, Nume = x.Nume + " " + x.Prenume })
                .ToList();

        }
        [HttpPut("UpdatePoza")]

        public void UpdatePozaUtilizator([FromBody] Angajat obj)

        {
            var myObj = _context.Angajats.Where(x => x.Id == obj.Id).FirstOrDefault();
            //if (myObj == null)
            //{
            //    return;
            //}

            myObj.Poza = obj.Poza;
            _context.SaveChanges();
        }


        [HttpPost("UpdateEmail")]

        public void UpdateEmail(string email, int Id)
        {

            _context.Logins.Where(x => x.AngajatId == Id).FirstOrDefault().Email = email;
            _context.SaveChanges();

        }

        [HttpGet("GetDateAngajat")]

        public List<Angajat> GetAllDataAngajat(int Id)
        {
            return _context.Angajats.
                Select(x => new Angajat() { Id = x.Id, Nume = x.Nume, Prenume = x.Prenume, LoginId = x.LoginId, DataAngajarii = x.DataAngajarii, DataNasterii = x.DataNasterii, Cnp = x.Cnp, SerieBuletin = x.SerieBuletin, NrBuletin = x.NrBuletin, NumarTelefon = x.NumarTelefon, EsteAdmin = x.EsteAdmin, ManagerId = x.ManagerId, Sex = x.Sex, Salariu = x.Salariu, Overtime = x.Overtime, SexVizbil = x.SexVizbil, SalariuVizibil = x.SalariuVizibil, IdFunctie = x.IdFunctie, IdEchipa = x.IdEchipa, ZileConcediu = x.ZileConcediu, ZileConcediuRamase = x.ZileConcediuRamase, Poza = x.Poza }).
                Where(x => x.Id == Id).ToList();

        }
        [HttpGet("GetAngajat")]

        public Angajat GetAngajat(int Id)
        {
            var MyObj = _context.Angajats.Where(x => x.Id == Id).FirstOrDefault();
            return MyObj;

        }
        [HttpGet("GetFunctieFromId")]
        public List<Functie> GetFunctieFromId(int Id)
        {
            return _context.Functies.Select(x => new Functie() { Nume = x.Nume, Id = x.Id }).Where(x => x.Id == Id).ToList();

        }
        [HttpGet("GetEchipaFromId")]
        public List<Echipa> GetEchipaFromId(int Id)
        {
            return _context.Echipas.Select(x => new Echipa() { Nume = x.Nume, Id = x.Id }).Where(x => x.Id == Id).ToList();

        }

        [HttpGet("GetEmailFromId")]
        public List<Login> GetEmailFromId(int Id)
        {
            return _context.Logins.Where(x => x.AngajatId == Id).Select(x => new Login() { Email = x.Email, Id = x.Id }).ToList();

        }

        [HttpGet("GetAdminFunctieFromAngajat")]
        public List<Angajat> GetAdminFunctieFromAngajat(int angajatid)
        {

            return _context.Angajats
                .Select(x => new Angajat() { EsteAdmin = x.EsteAdmin, IdFunctie = x.IdFunctie, Id = x.Id })
                .Where(x => x.Id == angajatid).ToList();
        }

        [HttpGet("GetPoza")]

        public List<Angajat> GetPoza(int Id)

        {
            return _context.Angajats.
               Select(x => new Angajat() { Id = x.Id, Poza = x.Poza }).
               Where(x => x.Id == Id).ToList();

        }
        [HttpGet("GetId")]

        public int GetId(string nume, string prenume)
        {
            int angajatId = _context.Angajats.Where(x => x.Nume == nume && x.Prenume == prenume).FirstOrDefault().Id;
            return angajatId;
        }

        [HttpGet("GetFindByName")]

        public List<Angajat> findByNameOrSurname(string? textnume)
        {
            if (String.IsNullOrEmpty(textnume))

                return null;
            return _context.Angajats.Where(x => x.Nume.StartsWith(textnume) || x.Prenume.StartsWith(textnume)).
                Select(x => new Angajat
                {
                    Id = x.Id,
                    Nume = x.Nume + " " + x.Prenume
                }).Distinct().ToList();
        }
    [HttpGet("GetFindByNameForManager")]

    public List<Angajat> findByNameOrSurnameForManager(string? textnume, int IdEchipa)
    {
            if (String.IsNullOrEmpty(textnume))
            
                return null; 
        return _context.Angajats.Where(x => (x.Nume.StartsWith(textnume) || x.Prenume.StartsWith(textnume)) && x.IdEchipa == IdEchipa).
            Select(x => new Angajat
            {
                Id = x.Id,
                Nume = x.Nume + " "+ x.Prenume
            }).Distinct().ToList();
    } }

    

 


}

