﻿using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MVC.Authentication
{
    public class PassCryptor : ICryptor
    {
        public string Encrypt(string text)
        {
            using (HashAlgorithm md5 = new SHA1CryptoServiceProvider())
            {
                var data = Encoding.ASCII.GetBytes(text);
                var result = md5.ComputeHash(data, 0, data.Count());
                return Convert.ToBase64String(result);
            }
        }
    }
}