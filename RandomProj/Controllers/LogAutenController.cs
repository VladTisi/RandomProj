using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomProj.Models;
using System.Security.Cryptography;
using System.Text;

namespace RandomProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogAutenController : ControllerBase
    {

        PrisonBreakContext _context;
        private readonly ILogger<LogAutenController> _logger;

        public LogAutenController(PrisonBreakContext context,ILogger<LogAutenController> logger)
        {
            _context=context;
            _logger=logger;
        }
        [HttpGet("GetPassword")]
        public List<Login> GetPassword(string email)
        {
            //return _context.Echipas.Include(x => x.Echipa)
            //    .Select(x => new Concediu() { Id=x.Id, TipConcediu=x.TipConcediu })
            //    .Where(x => x.TipConcediu.Id==1).ToList();

            return _context.Logins.
                Select(x => new Login() { Parola=x.Parola, Email=x.Email, AngajatId = x.AngajatId })
                .Where(x => x.Email==$"{email}").ToList();
        }

        [HttpPost("InsertLogin")]
        public void InsertLogin(string email,  string password)
        {
            _context.Logins.Add(new Login() { Parola = password, Email=email });
            _context.SaveChanges();
        }
        [HttpGet("GetIdFromEmail")]
        public List<Login> GetIdFromLogin(string email)
        {
           return _context.Logins
                .Select(x => new Login() { Id=x.Id, Email=x.Email })
                .Where(x =>x.Email==$"{email}").ToList();
        }

        [HttpGet("GetAngajatIdFromEmail")]
        public List<Login> GetAngajatId(string email)
        {
            return _context.Logins
                 .Select(x => new Login() { AngajatId=x.AngajatId, Email=x.Email })
                 .Where(x => x.Email==$"{email}").ToList();
        }

        [HttpPost("UpdatePassword")]
        public void UpdatePassword(string password,int angajatid)
        {
            _context.Logins.Where(x => x.AngajatId==angajatid).First().Parola=password;
            _context.SaveChanges();
        }
        public static string Encrypt(string encryptString)
        {
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement    
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }



        [HttpGet("GetParolaDecriptata")]
        public bool GetValid(string email, string parola)
        {
            var user = _context.Logins
                .FirstOrDefault(x => x.Email == email && x.Parola == Encrypt(parola));
            if (user == null)
                return false;
            else return true;
            
        }


        [HttpGet("GetUser")]
        public Angajat GetUser(string email)
        {
            var user= _context.Angajats
                .Include(x=> x.Login)
                .Where(x=> x.Login.Email == email)
                .Select(x=> new Angajat() { Id=x.Id, EsteAdmin=x.EsteAdmin, IdFunctie=x.IdFunctie,IdEchipa=x.IdEchipa,ManagerId=x.ManagerId}).FirstOrDefault();
            if (user == null)
                return null;
            else return user;
        }

    }
}
