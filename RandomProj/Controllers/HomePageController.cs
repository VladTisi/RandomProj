using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    public class HomePageController : Controller
    {
        PrisonBreakContext _context;
        private readonly ILogger<HomePageController> _logger;

        public HomePageController(PrisonBreakContext context, ILogger<HomePageController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPatch("UpdateZileCO")]

        public void UpdateZileCO(int Id)
        {
            _context.Angajats.Where(x => x.Id == Id).FirstOrDefault();
          
            int? ZileRamase = _context.Angajats.Where(x => x.Id == Id).Sum(x => EF.Functions.DateDiffMonth(x.DataAngajarii, DateTime.Now) * 2);
            int? ZileConcediu = _context.Concedius.Where(x => x.AngajatId == Id).Sum(x => EF.Functions.DateDiffDay(x.DataInceput, x.DataSfarsit) - EF.Functions.DateDiffWeek(x.DataInceput, x.DataSfarsit) * 2);
            if (ZileRamase <= ZileConcediu )
            {
                _context.Angajats.Where(x => x.Id == Id).FirstOrDefault().ZileConcediuRamase = 0;
                _context.SaveChanges();
                return;

            }

            else
            {
                _context.Angajats.Where(x => x.Id == Id).FirstOrDefault().ZileConcediuRamase = ((int)ZileRamase - (int)ZileConcediu);
                _context.SaveChanges();
                return;
            }
                                       
                   
           
        }



    }
}
