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

        public List<Angajat> GetIdEchipa(int Id)
        {
            return _context.Angajats.
                Select(x => new Angajat() { IdEchipa = x.IdEchipa, Id = x.Id }).
                Where(x => x.Id == Id).ToList();

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

        public void UpdateDateFromAdmin(string? nume, string? prenume, DateTime? dataAngajarii, string? numarTelefon, int? salariu, int? overtime, int? idEchipa, int? idFunctie, string? poza, int Id)
        {

            var myObj = _context.Angajats.Where(x => x.Id == Id).FirstOrDefault();
            if (myObj == null)
            {
                return;
            }
            //[FromBody] Angajat ang)
            {
                //_context.Angajats.Where(x => x.Id == ang.Id).FirstOrDefault().Poza = ang.pozaN




                myObj.Nume = String.IsNullOrEmpty(nume) ? myObj.Nume : nume;
                myObj.Prenume = String.IsNullOrEmpty(prenume) ? myObj.Prenume : prenume;
                myObj.DataAngajarii = dataAngajarii.HasValue ? dataAngajarii.Value : myObj.DataAngajarii;
                myObj.NumarTelefon = String.IsNullOrEmpty(numarTelefon) ? myObj.NumarTelefon : numarTelefon;
                myObj.Salariu = (int)(salariu.HasValue ? salariu : myObj.Salariu);
                myObj.Overtime = (int)(overtime.HasValue ? overtime : myObj.Overtime);
                myObj.IdEchipa = (int)(idEchipa.HasValue ? idEchipa : myObj.IdEchipa);
                myObj.IdFunctie = (int)(idFunctie.HasValue ? idFunctie : myObj.IdFunctie);
                myObj.Poza = String.IsNullOrEmpty(poza) ? myObj.Poza : poza;

                _context.SaveChanges();
            }




        }


    }
}
