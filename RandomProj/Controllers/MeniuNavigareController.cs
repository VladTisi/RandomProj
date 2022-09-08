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
        public List<Member> GetNumePrenumeFunctiaDataAngajarii()
        {

            return _context.Angajats
                .Include(x => x.Functie)
                .Select(x => new Member() { Nume=x.Nume, Prenume=x.Prenume,Functia = x.Functie.Nume, DataAngajarii= (DateTime)x.DataAngajarii }).ToList();
        }




    }
}