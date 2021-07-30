using AccountingNote_Auth;
using AccountingNote_DBSoure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace _0728_1.SystemAdmin
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) //可能是按按鈕跳回本頁，所以要判斷Postback
            {
                if (!AuthManager.IsLogined())
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                //取得現在使用者是誰
                var currentUser = AuthManager.GetCurrentUser();

                if (currentUser == null) //如果帳號不存在，導向登入頁
                {                  
                    Response.Redirect("/Login.aspx");
                    return;
                }

                this.ltAccount.Text = currentUser.Account;
                this.ltName.Text = currentUser.Name;
                this.ltEmail.Text = currentUser.Email;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            AuthManager.Logout();//資訊清除，導向登入頁
            Response.Redirect("/Login.aspx");
        }
    }
}