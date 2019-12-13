using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Extensions
{
    public static class CommonExtensions
    {
        public static bool IsNull(this object item)
        {
            return item == null;
        }

        public static bool IsNullOrZero(this object item)
        {
            return item == null || (int)item == 0;
        }
    }
}
