using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace WebApplication2
{
    public partial class Default : System.Web.UI.Page
    {
        public int ForJSInt { get; set; } = 500;

        public bool ForJSBool { get; set; } = true;

        public string ForJSString { get; set; } = "JSString";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.hf2.Value = "Test Message hf2";
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //伺服器端的警告訊息//一般是要用瀏覽器警告來做互動
            //MessageBox.Show("btn Msg");

            //this.lblName.Text = this.txt1.Text;
            this.lblName.Text = this.hf1.Value;

        }
    }
}