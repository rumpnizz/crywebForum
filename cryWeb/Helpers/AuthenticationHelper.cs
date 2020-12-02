using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

using cryWeb.Extensions;

namespace cryWeb.Helpers
{
    public class AuthenticationHelper
    {
        public string GenerateSalt()
        {
            var size = new Random().Next(140, 200);
            var crypto = new RNGCryptoServiceProvider();
            var bytes = new byte[size];
            crypto.GetBytes(bytes);
            return Convert.ToBase64String(bytes).ToMaxLength(size);
        }
        public string GenerateHash(string password, string salt)
        {
            const string methodSalt = "StkMEApTp6WsQhpjOWtPrn86Ix50RX39JT7gOTtCAIW2U4J6OLA4mO+O5BWKVEOUkie4Map+1sOb4DpWwXstWZY7px6qI9CQkYn5ApOQayzhsnNDvfPjpzNYEniVf7nIkS75o+cx0+PrkJ8RUQsList8456+V6E2xwcrw2vb9mPlakgcjflFp4CJJc1hNYFR/VGf7FndpEIobRvcMlXsHyfPQERRMVcexX/HzqYFf3LZjpWKUw==";

            var bytes = Encoding.Unicode.GetBytes(methodSalt + password + salt);
            var inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
        public string CreatePassword()
        {
            var upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var lower = "abcdefghijklmnopqrstuvwxyz";
            var numbers = "0123456789";
            var specials = "!#%&+-@?=()/";

            const int length = 6;
            var buffer = new char[length];
            var rnd = new Random();

            for (var i = 0; i < length; i++)
            {
                if (i == 0 || i == 1)
                    buffer[i] = upper[rnd.Next(upper.Length)];
                if (i == 2 || i == 3)
                    buffer[i] = lower[rnd.Next(lower.Length)];
                if (i == 4)
                    buffer[i] = numbers[rnd.Next(numbers.Length)];
                if (i > 4)
                    buffer[i] = specials[rnd.Next(specials.Length)];
            }

            var list = new SortedList<int, char>();
            foreach (var c in buffer)
            {
                list.Add(rnd.Next(), c);
            }

            return new string(list.Values.ToArray());
        }
    }
}