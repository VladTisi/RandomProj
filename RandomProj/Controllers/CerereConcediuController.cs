using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CerereConcediuController : ControllerBase
    {
        PrisonBreakContext _context;
        private readonly ILogger<CerereConcediuController> _logger;
        public CerereConcediuController(ILogger<CerereConcediuController> logger, PrisonBreakContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet("GetZileRamase")]
        public int? GetZileRamase(int angajatId)
        {
            int? ZileTotale = _context.Angajats.Where(x => x.Id == angajatId).Sum(x => EF.Functions.DateDiffMonth(x.DataAngajarii, DateTime.Now) * 2);
            int? ZileConcediu = _context.Concedius.Where(x => x.AngajatId == angajatId && x.StareConcediuId==2).Sum(x => EF.Functions.DateDiffDay(x.DataInceput, x.DataSfarsit)+1 - EF.Functions.DateDiffWeek(x.DataInceput, x.DataSfarsit) * 2);
            if (ZileTotale - ZileConcediu == null)
                return 0;
            else
                return ZileTotale - ZileConcediu;
        }

        [HttpGet("GetZileConcediu")]
        public int GetZileConcediu(DateTime Inceput , DateTime Sfarsit)
        {
            int ZileConcediu = EF.Functions.DateDiffDay(Inceput, Sfarsit) + 1 - EF.Functions.DateDiffWeek(Inceput, Sfarsit) * 2;
            return ZileConcediu;
        }
        [HttpPost("InsertConcediu")]
        public void InsertConcediu(int TipConcediuId,DateTime Inceput,DateTime Sfarsit,int angajatId,int inlocuitorId)
        {
            _context.Concedius.Add(new Concediu { TipConcediuId = TipConcediuId, DataInceput = Inceput, DataSfarsit = Sfarsit, StareConcediuId = 1, AngajatId = angajatId, InlocuitorId=inlocuitorId });
            _context.SaveChanges();
        }
    }
}
