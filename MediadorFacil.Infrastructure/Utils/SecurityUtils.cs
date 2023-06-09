﻿using MediadorFacil.Domain.SeedWorks;
using System.Security.Cryptography;

namespace MediadorFacil.Infrastructure.Utils
{
    public class SecurityUtils : ISecurityUtils
    {
        public string HashSHA1(string plainText)
        {
            return GetSHA1HashData(plainText);
        }

        private string GetSHA1HashData(string data)
        {
            SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider();
            byte[] byteV = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] byteH = SHA1.ComputeHash(byteV);

            SHA1.Clear();

            return Convert.ToBase64String(byteH);
        }
    }
}
