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
        [HttpGet("GetAdminManager")]
        public  List<Angajat> GetAdminManager(int angajatId)
        {
            return _context.Angajats
                .Select(x => new Angajat() { Id=x.Id,EsteAdmin = x.EsteAdmin,IdFunctie=x.IdFunctie  })
                .Where(x => x.Id == angajatId).ToList();
        }
        [HttpGet("GetAdmin")]
        public bool GetAdmin(int angajatId)
        {
            var user = _context.Angajats.FirstOrDefault(x => x.Id == angajatId);

            if (user.EsteAdmin == null)
                return false;
            else if (user.EsteAdmin == true)
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
        [HttpPut("AprobaConcediu")]
        public void AprobaConcediu(int concediuId)
        {
            _context.Concedius.Where(x => x.Id == concediuId).First().StareConcediuId = 2;
            _context.SaveChanges();
        }
        [HttpPut("RefuzaConcediu")]
        public void RefuzaConcediu(int concediuId)
        {
            _context.Concedius.Where(x => x.Id == concediuId).First().StareConcediuId = 3;
            _context.SaveChanges();
        }
           
    }
}

