using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Infrastructure.Extensions
{
    public static class AnagramExtensions
    {

        /// <summary>
        /// Check if two strings are anagrams
        /// </summary>
        /// <param name="a">First string</param>
        /// <param name="b">Second string</param>
        /// <returns>True if anagrams, false if not</returns>
        public static bool AreStringsAnagrams(string a, string b)
        {
            if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b) || a.Length != b.Length)
            {
                return false;
            }

            a = a.Trim().ToLower();
            b = b.Trim().ToLower();

            if (a.Equals(b))
                return false;

            char[] ac = a.ToCharArray();
            char[] bc = b.ToCharArray();
            Array.Sort(ac);
            Array.Sort(bc);
            for (int i = 0; i < ac.Length; i++)
            {
                if (ac[i] != bc[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
