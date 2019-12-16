using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramAPI.Infrastructure.Extensions
{
    public static class CommonExtensions
    {
        /// <summary>
        /// Check if the current string is Base64 encoded 
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns>True if it is Base64Encoded, false if not</returns>
        public static bool IsBase64(this string base64String)
        {
            if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }
    }
}
