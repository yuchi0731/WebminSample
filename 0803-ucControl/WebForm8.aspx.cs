using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _0803_ucControl
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ctl = this.ucDomSample.FindControl("Image1"); //利用FindControl找到ucDomSample的控制項

            if (ctl != null)
                ctl.Visible = false;

        }
    }
}