﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote_Auth
{
    public class AuthManager
    {
        /// <summary>
        /// check logined
        /// </summary>
        /// <returns></returns>
        public static bool IsLogined()
        {

            if (System.Web.HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;
            else
                return true;
            


        }
    }
}
