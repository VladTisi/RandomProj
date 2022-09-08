using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeniuModificareDateAngajatController : ControllerBase
    {



        PrisonBreakContext _context;
        private readonly ILogger<MeniuModificareDateAngajatController> _logger;

        public MeniuModificareDateAngajatController(PrisonBreakContext context, ILogger<MeniuModificareDateAngajatController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet("CheckAdmin")]

        public bool CheckAdmin(int Id)
        {
            var user = _context.Angajats.FirstOrDefault(x => x.Id == Id);

            if (user.EsteAdmin == null)
                return false;
            else if (user.EsteAdmin == true)
                return true;
            else return false;


        }

        [HttpGet("GetAllAdmins")]

        public List<Angajat> GetAllAdmins()
        {
            return _context.Angajats.
                Select(x => new Angajat() { Nume = x.Nume, Prenume = x.Prenume, Id = x.Id, EsteAdmin = x.EsteAdmin }).
                Where(x => x.EsteAdmin == true).ToList();

        }

        [HttpGet("GetAllNames")]
        public List<Angajat> GetAllNames()
        {
            return _context.Angajats.
                Select(x => new Angajat() { Nume = x.Nume, Prenume = x.Prenume, Id = x.Id }).
                ToList();
        }

        [HttpGet("GetIdEchipa")]

        public int GetIdEchipa(int Id)
        {
            return (int)_context.Angajats.Where(x => x.Id == Id)
                .Select(x => x.IdEchipa).ToList().FirstOrDefault();


        }


        [HttpGet("GetMembriEchipa")]

        public List<Angajat> GetMembri(int echipaId)
        {
            return _context.Angajats.
                Select(x => new Angajat() { Nume = x.Nume, Prenume = x.Prenume, IdEchipa = x.IdEchipa })
                .Where(x => x.IdEchipa == echipaId).ToList();

        }

        [HttpGet("GetDateAngajat")]

        public List<Angajat> GetAllDataAngajat(int Id)
        {
            return _context.Angajats.
                Select(x => new Angajat() { Id = x.Id, Nume = x.Nume, Prenume = x.Prenume, LoginId = x.LoginId, DataAngajarii = x.DataAngajarii, DataNasterii = x.DataNasterii, Cnp = x.Cnp, SerieBuletin = x.SerieBuletin, NrBuletin = x.NrBuletin, NumarTelefon = x.NumarTelefon, EsteAdmin = x.EsteAdmin, ManagerId = x.ManagerId, Sex = x.Sex, Salariu = x.Salariu, Overtime = x.Overtime, SexVizbil = x.SexVizbil, SalariuVizibil = x.SalariuVizibil, IdFunctie = x.IdFunctie, IdEchipa = x.IdEchipa, ZileConcediu = x.ZileConcediu, ZileConcediuRamase = x.ZileConcediuRamase, Poza = x.Poza }).
                Where(x => x.Id == Id).ToList();

        }

        [HttpGet("GetDateleAngajat")]

        public Angajat GetAllDataAngajati(int Id)
        {
            return _context.Angajats.
                Select(x => new Angajat() { Id = x.Id, Nume = x.Nume, Prenume = x.Prenume, LoginId = x.LoginId, DataAngajarii = x.DataAngajarii, DataNasterii = x.DataNasterii, Cnp = x.Cnp, SerieBuletin = x.SerieBuletin, NrBuletin = x.NrBuletin, NumarTelefon = x.NumarTelefon, EsteAdmin = x.EsteAdmin, ManagerId = x.ManagerId, Sex = x.Sex, Salariu = x.Salariu, Overtime = x.Overtime, SexVizbil = x.SexVizbil, SalariuVizibil = x.SalariuVizibil, IdFunctie = x.IdFunctie, IdEchipa = x.IdEchipa, ZileConcediu = x.ZileConcediu, ZileConcediuRamase = x.ZileConcediuRamase, Poza = x.Poza }).
                Where(x => x.Id == Id).ToList().FirstOrDefault();

        }

        [HttpGet("GetPozaAngajat")]

        public List<Angajat> GetPoza(int Id)
        {
            return _context.Angajats.
                Select(x => new Angajat() { Poza = x.Poza, Id = x.Id }).
                Where(x => x.Id == Id).ToList();

        }


        [HttpGet("GetEchipe")]

        public List<Echipa> GetEchipe()
        {
            return _context.Echipas.
                Select(x => new Echipa() { Id = x.Id, Nume = x.Nume }).ToList();

        }

        [HttpGet("GetFunctii")]

        public List<Functie> GetFunctii()
        {
            return _context.Functies.
                Select(x => new Functie() { Id = x.Id, Nume = x.Nume }).ToList();

        }



        [HttpPost("UpdateDate")]

        public void UpdateDateFromAdmin([FromBody]Angajat ang)
            //string? nume, string? prenume, DateTime? dataAngajarii, string? numarTelefon, int? salariu, int? overtime, int? idEchipa, int? idFunctie, string? poza, int Id)
        {

            var myObj = _context.Angajats.Where(x => x.Id == ang.Id).FirstOrDefault();
            if (myObj == null)
            {
                return;
            }
            else 
            {
                             
                myObj.Nume = String.IsNullOrEmpty(ang.Nume) ? myObj.Nume : ang.Nume;
                myObj.Prenume = String.IsNullOrEmpty(ang.Prenume) ? myObj.Prenume : ang.Prenume;
                myObj.DataAngajarii = ang.DataAngajarii.HasValue ? ang.DataAngajarii.Value : myObj.DataAngajarii;
                myObj.NumarTelefon = String.IsNullOrEmpty(ang.NumarTelefon) ? myObj.NumarTelefon : ang.NumarTelefon;
                myObj.Salariu = (int)(ang.Salariu.HasValue ? ang.Salariu : myObj.Salariu);
                myObj.Overtime = (int)(ang.Overtime.HasValue ? ang.Overtime : myObj.Overtime);
                myObj.IdEchipa = (int)(ang.IdEchipa.HasValue ? ang.IdEchipa : myObj.IdEchipa);
                myObj.IdFunctie = (int)(ang.IdFunctie.HasValue ? ang.IdFunctie : myObj.IdFunctie);
                myObj.Poza = String.IsNullOrEmpty(ang.Poza) ? myObj.Poza : ang.Poza;

                _context.SaveChanges();
            }

        }

        //[HttpPost("UpdateEmail")]

        //public void UpdateEmail()

        //{
        //        _context.Logins.Where(x => x.AngajatId == Id).FirstOrDefault().Email = email;
        //        _context.SaveChanges();

            
        //}
    }
}
