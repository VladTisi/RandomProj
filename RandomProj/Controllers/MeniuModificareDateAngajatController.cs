using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeniuModificareDateAngajatController : Controller
    {



        PrisonBreakContext _context;
        private readonly ILogger<MeniuModificareDateAngajatController> _logger;

        public MeniuModificareDateAngajatController(PrisonBreakContext context, ILogger<MeniuModificareDateAngajatController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet("CheckAdmin")]

        public List<Angajat> GetAdminChecks(int Id)
        {

            return _context.Angajats.
                Select(x => new Angajat() { EsteAdmin = x.EsteAdmin, Id = x.Id })
                .Where(x =>  x.Id == Id).ToList();

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
                Select( x=> new Angajat() { Nume = x.Nume, Prenume = x.Prenume, IdEchipa = x.IdEchipa})
                .Where(x=> x.IdEchipa == echipaId ).ToList();

        }

        [HttpGet("GetDateAngajat")]

        public List<Angajat> GetAllDataAngajat(int Id)
        {
            return _context.Angajats.
                Select(x => new Angajat() { Id = x.Id, Nume = x.Nume, Prenume = x.Prenume, LoginId = x.LoginId, DataAngajarii = x.DataAngajarii, DataNasterii = x.DataNasterii, Cnp = x.Cnp, SerieBuletin = x.SerieBuletin, NrBuletin = x.NrBuletin, NumarTelefon = x.NumarTelefon, EsteAdmin = x.EsteAdmin, ManagerId = x.ManagerId, Sex = x.Sex, Salariu = x.Salariu, Overtime = x.Overtime, SexVizbil = x.SexVizbil, SalariuVizibil = x.SalariuVizibil, IdFunctie = x.IdFunctie, IdEchipa = x.IdEchipa, ZileConcediu = x.ZileConcediu, ZileConcediuRamase = x.ZileConcediuRamase, Poza = x.Poza }).
                Where(x => x.Id == Id).ToList();

        }
    }

}
