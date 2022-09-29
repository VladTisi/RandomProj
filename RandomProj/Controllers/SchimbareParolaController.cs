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
    public class SchimbareParolaController : ControllerBase
    {
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


        PrisonBreakContext _context;
        private readonly ILogger<SchimbareParolaController> _logger;

        public SchimbareParolaController(PrisonBreakContext context, ILogger<SchimbareParolaController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("GetPassword")]
        public string GetPasswordFromId(int AngajatId)
        {
            return _context.Logins.Where(x => x.AngajatId == AngajatId).
            Select(x => x.Parola).ToList().FirstOrDefault();
                                                              
        }

        [HttpPost("UpdatePassword")]

        public void UpdatePassword(string password, int AngajatId)
        {
            _context.Logins.Where(x => x.AngajatId == AngajatId).First().Parola = password;
            _context.SaveChanges();
        }

        [HttpPost("UpdatePasswordBun")]

        public void UpdatePasswordBun(string password, int AngajatId)
        {
            _context.Logins.Where(x => x.AngajatId == AngajatId).First().Parola = Encrypt(password);
            _context.SaveChanges();
        }
        [HttpGet("GetPasswordBun")]
        public bool GetPasswordBun(int AngajatId, string parola)
        {
            var pass = _context.Logins.Where(x => x.AngajatId == AngajatId).
            Select(x => x.Parola).FirstOrDefault();
            if (pass == Encrypt(parola))
                return true;
            else 
                return false;

        }
    }
}
