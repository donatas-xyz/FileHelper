using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHelperTest
{
    public class RandomStringGenerator
    {
        /// <summary>
        /// Taken from http://stackoverflow.com/a/1344242/1380473
        /// </summary>
        /// <returns>Random alphanumeric string</returns>
        public string RandomString() 
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}
