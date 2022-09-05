using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogAuten : ControllerBase
    {

        PrisonBreakContext _context;

        public LogAuten(PrisonBreakContext context)
        {
            _context=context;
        }
       




    }
}
