using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _0803_ucControl
{
    public partial class Main : System.Web.UI.MasterPage //此處型別為Main繼承了MasterPage 
    {
        public string MyTitle { get; set; } = string.Empty; //順便做初始化


        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("MasterPage_Init <br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("MasterPage_Load <br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("MasterPage_PreRender <br/>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("MasterPage_Button1_Click <br/>");
            this.ltlMsg.Text = this.txtEmail.Text;
        }

        public void SetPageCaption(string title)
        {
            if(!string.IsNullOrWhiteSpace(title)) //假設title不是空值才設定title輸出
                this.ltlCaption.Text = title;

            
        }

 
    }
}