﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace Loja
{
    public class Settings
    {
        public static string Secret = "dfDF43$fdf_23FDfdf$D#d43";

        public static string ApiKeyName = "api_key";
        public static string ApiKey = "skd90_jewloj465=sdjfo435";

        public static string GenerateHash(string password)
        {
            byte[] salt = Encoding.ASCII.GetBytes("16584646873641");

            string hashed = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 32));

            return hashed;
        }
    }
}
