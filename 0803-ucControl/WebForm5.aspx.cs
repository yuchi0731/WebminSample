using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _0803_ucControl
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        //生命週期，執行順序
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("WebForm5_Init <br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("WebForm5_Load <br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("WebForm5_PreRender <br/>");
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Write("WebForm5_Button1_Click <br/>");
        }
    }
}