using System;
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

            var userUnfo = UserInfoManager.GetUserInfoByAccount(account);


            if (userUnfo == null) //一旦發現是空的就要清除資料
            {
                HttpContext.Current.Session["UserLoginInfo"] = null;
                return null;
            }

            //因為dr設為取得使用者帳號的方法，所以可以取得對應的欄位
            UserInfoModel model = new UserInfoModel();
            model.ID = userUnfo.ID;
            model.Account = userUnfo.Account;
            model.Name = userUnfo.Name;
            model.Email = userUnfo.Email;
            model.Phone = userUnfo.Phone;


            return model;

        }
        /// <summary>
        /// 登出
        /// </summary>
        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null; //清除登入資料，導向登入頁
        }

        /// <summary>
        /// 嘗試登入
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool TryLogin(string account, string pwd, out string errorMsg)
        {
            //check empty
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(pwd))
            {
                errorMsg = "Account / PWD is required.";
                return false;
            }

            //read db and check
            var userInfo = UserInfoManager.GetUserInfoByAccount(account);

            //check null
            if (userInfo == null)
            {
                errorMsg = $"Account:{account} doesn't existi.";
                return false;
            }

            //check account / pwd  Compare:比對前兩數值，第三參數為true不分大小寫，false表示區分大小寫
            if (string.Compare(userInfo.Account, account, true) == 0 && string.Compare(userInfo.PWD, pwd, false) == 0)
            {
                HttpContext.Current.Session["UserLoginInfo"] = userInfo.Account;
                errorMsg = string.Empty;
                return true;
            }

            else
            {
                errorMsg = "Login fail. Please check Account / PWD.";
                return false;
            }

        }


    }
}
