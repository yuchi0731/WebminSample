using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Extensions
{
    public static class StringExtension
    {

        //加上static宣告成靜態
        public static Guid ToGuid(this string guidText)
        {
            if (Guid.TryParse(guidText, out Guid tempGuid))
            {
                return tempGuid;
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
}