using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeniuNavigareController : ControllerBase
    {

        PrisonBreakContext _context;
        private readonly ILogger<MeniuNavigareController> _logger;

        public MeniuNavigareController(PrisonBreakContext context, ILogger<MeniuNavigareController> logger)
        {
            _context=context;
            _logger=logger;
        }

        [HttpGet("GetAdminFunctieFromAngajat")]
        public List<Angajat> GetAdminFunctieFromAngajat(int angajatid) {

            return _context.Angajats
                .Select(x => new Angajat() { EsteAdmin= x.EsteAdmin, IdFunctie= x.IdFunctie, Id=x.Id })
                .Where(x=>x.Id==angajatid).ToList();
        }

        [HttpGet("GetNumePrenumeFunctiaDataAngajarii")]
        public List<AngajatFunctie> GetNumePrenumeFunctiaDataAngajarii()
        {

            return _context.Angajats
                .Include(x => x.Functie)
                .Select(x => new AngajatFunctie() {IdFunctieFromAngajat=x.IdFunctie.HasValue ? x.IdFunctie.Value : 0 , IdFunctieFromFunctie = x.IdFunctie.HasValue ? x.IdFunctie.Value : 0, Nume=x.Nume, Prenume=x.Prenume,Functie = x.Functie.Nume }).ToList();
        }


    }
}