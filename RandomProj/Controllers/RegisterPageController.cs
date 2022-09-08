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

        [HttpPost("InsertAccount")]
        public void InsertLogin(string nume, string prenume, int loginid, DateTime data_angajarii, DateTime data_nasterii, string CNP, string Serie, string NrBuletin,string NumarTelefon,bool esteAdmin,string Sex,int salariu,int overtime,int IdFunctie,int IdEchipa)
        {
            _context.Angajats.Add(new Angajat() { Nume = nume, Prenume=prenume, LoginId=loginid, DataAngajarii = data_angajarii,DataNasterii=data_nasterii, Cnp=CNP, SerieBuletin=Serie, NrBuletin=NrBuletin, NumarTelefon=NumarTelefon, EsteAdmin=esteAdmin,Sex=Sex,Salariu=salariu,Overtime=overtime,IdFunctie=IdFunctie,IdEchipa=IdEchipa });
            _context.SaveChanges();
        }


    }
}