using Microsoft.AspNetCore.Mvc;
using RandomProj.Models;
using Microsoft.EntityFrameworkCore;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcediiPersonaleController : ControllerBase
    {
        PrisonBreakContext _context;
        private readonly ILogger<ConcediiPersonaleController> _logger;

        public ConcediiPersonaleController(PrisonBreakContext context, ILogger<ConcediiPersonaleController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("ApprovedHolidays")]

        public List<AngajatConcediu> GetApprovedHolidays(int Id)
        {
            var a = _context.Concedius.
                Include(x => x.Angajat).
                Where(x => x.AngajatId == Id && x.StareConcediuId == 2).
                Select(x => new AngajatConcediu() { StareConcediuId = x.StareConcediuId.Value, IdAngajatFromAngajat = x.Angajat.Id, DataInceput = x.DataInceput.HasValue ? x.DataInceput.Value : DateTime.Now, DataSfarsit = x.DataSfarsit.HasValue ? x.DataSfarsit.Value : DateTime.Now }).ToList();


            return _context.Concedius.
                Include(x => x.Angajat).
                Where(x => x.AngajatId == Id && x.StareConcediuId == 2).
                Select(x => new AngajatConcediu() { StareConcediuId = x.StareConcediuId.Value, IdAngajatFromAngajat = x.Id, DataInceput = x.DataInceput.HasValue ? x.DataInceput.Value : DateTime.Now, DataSfarsit = x.DataSfarsit.HasValue ? x.DataSfarsit.Value : DateTime.Now }).ToList();
                                
        }

        [HttpGet("DisapprovedHolidays")]

        public List<AngajatConcediu> GetDisapprovedHolidays(int Id)
        {
            return _context.Concedius.
                Include(x => x.Angajat).
                Where(x => x.AngajatId == Id && x.StareConcediuId == 3).
                Select(x => new AngajatConcediu() { StareConcediuId = x.StareConcediuId.Value, IdAngajatFromAngajat = x.Id, DataInceput = x.DataInceput.HasValue ? x.DataInceput.Value : DateTime.Now, DataSfarsit = x.DataSfarsit.HasValue ? x.DataSfarsit.Value : DateTime.Now }).ToList();

        }

        [HttpGet("PendingHolidays")]

        public List<AngajatConcediu> GetPendingHolidays(int Id)
        {
            return _context.Concedius.
                Include(x => x.Angajat).
                Where(x => x.AngajatId == Id && x.StareConcediuId == 1).
                Select(x => new AngajatConcediu() { StareConcediuId = x.StareConcediuId.Value, IdAngajatFromAngajat = x.Id, DataInceput = x.DataInceput.HasValue ? x.DataInceput.Value : DateTime.Now, DataSfarsit = x.DataSfarsit.HasValue ? x.DataSfarsit.Value : DateTime.Now }).ToList();

        }

        [HttpGet("GetAdminFunctieFromAngajat")]
        public List<Angajat> GetAdminFunctieFromAngajat(int angajatid)
        {

            return _context.Angajats
                .Select(x => new Angajat() { EsteAdmin = x.EsteAdmin, IdFunctie = x.IdFunctie, Id = x.Id })
                .Where(x => x.Id == angajatid).ToList();
        }


    }

    }

