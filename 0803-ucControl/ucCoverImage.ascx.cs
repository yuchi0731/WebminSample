using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _0803_ucControl
{
    public partial class ucCoverImage : System.Web.UI.UserControl
    {
        //為ucCoevrImage新創一個property；可被加入於html標籤中
        public string MyTitle { get; set; }
        
        public enum BColor  //背景色，來當屬性使用
        {
            Blue,
            Red,
            Green
        }
        public BColor BackColor { get; set; } = BColor.Green; //依照BackColor，給予預設顏色



        protected void Page_Init(object sender, EventArgs e)
        {
            //Response.Write("ucCoverImage_Init <br/>");
            //因在Default頁面中加入多個ucCoverImage可利用寫出ID識別是哪一個
            Response.Write($"{this.ID}ucCoverImage_Init <br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write($"{this.ID}ucCoverImage_Load <br/>");
            if (!string.IsNullOrWhiteSpace(this.MyTitle))
            {
                this.ltlTitle.Text = this.MyTitle;
                this.imgConver.Alt = this.MyTitle;
            }

            this.divMain.Style.Add("background-color", this.BackColor.ToString()); //將BackColor設定的顏色加入div標籤中

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write($"{this.ID}ucCoverImage_PreRender <br/>");
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write($"{this.ID}ucCoverImage_Button1_Click <br/>");
            this.ltlTitle.Text = "ucControlImage_Click";
            this.imgConver.Alt = "ucControlImage_Click";
        }

        public void SetText(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                this.ltlTitle.Text = title;
                this.imgConver.Alt = title;
            }

        }
    }
}