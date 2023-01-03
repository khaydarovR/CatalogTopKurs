using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace CatalogTop.Helpers
{
    public static class HashHelper
    {
        static public string GetHashSaltString(string s)
        {
            var _inputString = s;

            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string HashString = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: _inputString!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return HashString;
        }
    }
}
