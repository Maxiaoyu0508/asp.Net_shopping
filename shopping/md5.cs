using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace shopping
{
    public class md5
    {
        internal string Result;
        public void jiami(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(password.ToCharArray());
            byte[] result = md5.ComputeHash(data);
            Result = Convert.ToBase64String(result);
        }
    }
}