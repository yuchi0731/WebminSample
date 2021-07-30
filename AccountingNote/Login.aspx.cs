using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccountingNote_DBSoure;

namespace _0728_1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserLoginInfo"] != null)
            {
                this.plcLogin.Visible = true;
                Response.Redirect("/SystemAdmin/UserInfo.aspx");
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            

            string inp_Account = this.txtAccount.Text;
            string inp_PWD = this.txtPWD.Text;

            //check empty
            if (string.IsNullOrWhiteSpace(inp_Account) || string.IsNullOrWhiteSpace(inp_PWD))
            {
                this.ltlMsg.Text = "Account / PWD is required.";
                return;
            }

            var dr = UserInfoManager.GetUserInfoByAccount(inp_Account);

            //check null
            if (dr == null)
            {
                this.ltlMsg.Text = "Account doesn't existi.";
                return;
            }


            //check account / pwd  Compare:比對前兩數值，第三參數為true不分大小寫，false表示區分大小寫
            if (string.Compare(dr["Account"].ToString(), inp_Account, true) == 0 && string.Compare(dr["PWD"].ToString(), inp_PWD, false) == 0)
            {
                this.Session["UserLoginInfo"] = dr["Account"].ToString();
                Response.Redirect("/SystemAdmin/UserInfo.aspx");
            }

            else
            {
                this.ltlMsg.Text = "Login fail. Please check Account / PWD.";
                return;
            }

        }
    }
}