﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AccountingNote_DBSoure;

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

            if (HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;
            else
                return true;           
        }

        /// <summary>
        /// 取得使用者資料
        /// </summary>
        /// <returns></returns>
        public static UserInfoModel GetCurrentUser()
        {
            string account = HttpContext.Current.Session["UserLoginInfo"] as string;

            if (account == null)
                return null;

            DataRow dr = UserInfoManager.GetUserInfoByAccount(account);
            

            if (dr == null) //一旦發現是空的就要清除資料
            {
                HttpContext.Current.Session["UserLoginInfo"] = null;
                return null;
            }
                
            //因為dr設為取得使用者帳號的方法，所以可以取得對應的欄位
            UserInfoModel model = new UserInfoModel();
            model.ID = dr["ID"].ToString();
            model.Account = dr["Account"].ToString();
            model.Name = dr["Name"].ToString();
            model.Email = dr["Email"].ToString();


            return model;

        }
        /// <summary>
        /// 清除登入
        /// </summary>
        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null; //清除登入資料，導向登入頁
        }



    }
}
