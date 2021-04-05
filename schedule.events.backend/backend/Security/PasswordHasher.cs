using backend.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace backend.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private IConfiguration _configuration { get; }

        public PasswordHasher(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public byte[] Hash(byte[] salt, string password)
        {
            using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(_configuration["Authentication:PasswordHashPrivateKey"])))
            {
                //Convert password to bytes
                var passwordBytes = Encoding.UTF8.GetBytes(password);

                //Combine bytes
                var combinedBytes = new byte[passwordBytes.Length + salt.Length];

                Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
                Buffer.BlockCopy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

                return hmac.ComputeHash(combinedBytes);

            }
        }
    }
}
