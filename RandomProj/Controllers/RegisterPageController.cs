using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterPageController : ControllerBase
    {

        PrisonBreakContext _context;
        private readonly ILogger<RegisterPageController> _logger;

        public RegisterPageController(PrisonBreakContext context, ILogger<RegisterPageController> logger)
        {
            _context=context;
            _logger=logger;
        }

        [HttpGet("GetIdNumeFromEchipa")]
        public List<Echipa> GetIdNumeFromEchipa()
        {
            return _context.Echipas.Select(x => new Echipa() { Id=x.Id, Nume=x.Nume }).ToList();
        }
        [HttpGet("GetIdNumeFromFunctie")]
        public List<Functie> GetIdNumeFromFunctie()
        {
            return _context.Functies.Select(x => new Functie() { Id=x.Id, Nume=x.Nume }).ToList();
        }
        [HttpGet("GetAngajatIdFromNumePrenume")]
        public int GetAngajatIdFromNumePrenume(string nume,string prenume)
        {
            return _context.Angajats.Where(x => x.Nume==nume && x.Prenume==prenume).Select(x => x.Id).ToList().FirstOrDefault();
        }

        [HttpPost("InsertAccount")]
        public void InsertAccount(string nume, string prenume, int loginid, DateTime data_angajarii, DateTime data_nasterii, string CNP, string Serie, string NrBuletin, string NumarTelefon, bool esteAdmin, string Sex, int salariu, int overtime, int IdFunctie, int IdEchipa)
        {
            _context.Angajats.Add(new Angajat() { Nume = nume, Prenume = prenume, LoginId = loginid, DataAngajarii = data_angajarii, DataNasterii = data_nasterii, Cnp = CNP, SerieBuletin = Serie, NrBuletin = NrBuletin, NumarTelefon = NumarTelefon, EsteAdmin = esteAdmin, Sex = Sex, Salariu = salariu, Overtime = overtime, IdFunctie = IdFunctie, IdEchipa = IdEchipa, ZileConcediu=0, ZileConcediuRamase=0 }) ;
            _context.SaveChanges();
        }
        [HttpPost("InsertLogin")]
        public void InsertLogin(string email, string parola)
        {
            _context.Logins.Add(new Login() { Email = email, Parola = parola });
            _context.SaveChanges();
        }
        [HttpGet("GetIdLogin")]
        public List<Login> GetIdLogin(string email)
        {
            return _context.Logins.Select(x => new Login() { Id=x.Id, Email=x.Email }).Where(x => x.Email==email).ToList();
            
        }
        [HttpPost("UpdateAngajatId")]
        public void UpdateAngajatId(int id,int angajatid)
        {
            _context.Logins.Where(x => x.Id==id).FirstOrDefault().AngajatId=angajatid;
            _context.SaveChanges();

        }
        [HttpGet("GetAngajatIdFromLoginId")]
        public List<Angajat> GetAngajatIdFromLoginId(int loginid)
        {
            return _context.Angajats.Select(x => new Angajat() { Id=x.Id , LoginId=x.LoginId }).Where(x => x.LoginId==loginid).ToList();
        }





    }
}