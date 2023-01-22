using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace CatalogTop.Helpers
{
    public static class MyHelpers
    {
        static public string GetHashSaltString(string s)
        {
            byte[] salt = Encoding.ASCII.GetBytes("secretkey");

            string HashString = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: s!,
                salt: salt!,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10,
                numBytesRequested: 256 / 8));

            return HashString;
        }
    }
}
