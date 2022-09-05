using Microsoft.AspNetCore.Mvc;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeniuModificareDateAngajat : Controller
    {
        
      

            PrisonBreakContext _context;

            public MeniuModificareDateAngajat(PrisonBreakContext context)
            {
                _context = context;
            }
         
     }
    
}
