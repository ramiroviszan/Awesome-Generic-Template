using AGT.Contracts.Application.Users;
using AGT.Contracts.CrossCutting;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AGT.CrossCutting
{
    public class HashGenerator : IHashGenerator
    {
        public byte[] GetRandomSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public string GetHash(string input, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: "secreto",
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 5000,
                numBytesRequested: 256 / 8));

            string superHashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: input,
                salt: Encoding.ASCII.GetBytes(hashed),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return superHashed;
        }
    }
}
