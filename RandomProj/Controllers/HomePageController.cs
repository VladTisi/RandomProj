using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;
using System.Security.Cryptography.X509Certificates;

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

        [HttpPatch("UpdateZile")]

        public void UpdateZileCO(int Id)
        {
            _context.Angajats.Where(x => x.Id == Id).FirstOrDefault();
            int? ZileRamase = _context.Angajats.Where(x => x.Id == Id).Sum(x => EF.Functions.DateDiffMonth(x.DataAngajarii, DateTime.Now) * 2);
            _context.Angajats.Where(x => x.Id == Id).FirstOrDefault().ZileConcediu = (int)ZileRamase;
            _context.SaveChanges();


        }


        [HttpPatch("UpdateZileCORamase")]

        public void UpdateZileCORamase(int Id)
        {
            _context.Angajats.Where(x => x.Id == Id).FirstOrDefault();

            int? ZileTotale = _context.Angajats.Where(x => x.Id == Id).Sum(x => EF.Functions.DateDiffMonth(x.DataAngajarii, DateTime.Now) * 2);
            int? ZileConcediu = _context.Concedius.Where(x => x.AngajatId == Id && x.StareConcediuId == 2).Sum(x => EF.Functions.DateDiffDay(x.DataInceput, x.DataSfarsit) - EF.Functions.DateDiffWeek(x.DataInceput, x.DataSfarsit) * 2);
            if (ZileConcediu >= ZileTotale)
            {
                _context.Angajats.Where(x => x.Id == Id).FirstOrDefault().ZileConcediuRamase = 0;
                _context.SaveChanges();
                return;

            }

            else
            {
                _context.Angajats.Where(x => x.Id == Id).FirstOrDefault().ZileConcediuRamase = ((int)ZileTotale - (int)ZileConcediu);
                _context.SaveChanges();
                return;
            }
        }

            [HttpPatch("UpdateTelfPoza")]

            public void UpdateDateDeUtilizator(string? numarTelefon, string? email, string? poza, int Id)

            {
                var myObj = _context.Angajats.Where(x => x.Id == Id).FirstOrDefault();
                if (myObj == null)
                {
                    return;
                }
                              
                myObj.NumarTelefon = String.IsNullOrEmpty(numarTelefon) ? myObj.NumarTelefon : numarTelefon;
                myObj.Poza = String.IsNullOrEmpty(poza) ? myObj.Poza : poza;

                _context.SaveChanges();
            }


            [HttpPatch("UpdateEmail")]

            public void UpdateEmail(string email, int Id)
            {

            _context.Logins.Where(x => x.AngajatId == Id).FirstOrDefault().Email = email;
            _context.SaveChanges();

             }


        }



    }
