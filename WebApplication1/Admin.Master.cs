using AccountingNote_Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Admin : System.Web.UI.MasterPage
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

            }
        }
    }
}