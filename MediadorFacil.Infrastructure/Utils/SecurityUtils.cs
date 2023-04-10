using MediadorFacil.Domain.SeedWorks;
using System.Security.Cryptography;
using System.Text;

namespace MediadorFacil.Infrastructure.Utils
{
    public class SecurityUtils : ISecurityUtils
    {
        public string Hash(string data)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                var bytes = Encoding.UTF8.GetBytes(data);
                var hash = sha1.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
