using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _0803_ucControl
{
    public partial class ucDomSample : System.Web.UI.UserControl
    {
        //如果想直接讓控制項能夠對外就寫property，但太多控制項也不好用//相較起來還是FindControl較好
        public Image MyImage { get { return this.Image1; } }

        public Image GetImage1()
        {
            return this.Image1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Button1.Visible = false;
            //this.Label1.Text = "Mihotaijyou!";

            //Control ctl = this.FindControl("PlaceHolder1");

            //if (ctl != null)
            //{
            //    //ctl.Visible = false;

            //    var firstSubControl = ctl.Controls[0]; //尋找ctl(PlaceHolder1)第一個控制項，此為Literal

            //    if(firstSubControl !=null)
            //    {
            //        firstSubControl.Visible = false;
            //    }
            //}


            //var ltl = this.FindControl("Literal1");
            //if (ltl != null)
            //    ltl.Visible = false;
            //this.Controls[0].Controls[1].Controls[0].Visible = false; //寫法固定容易跑掉，透過FindControl較好
            //PlaceHolder1的子控制項PlaceHolder2的子控制項Button


            var ltl = this.FindControl("Literal1") as Literal;

            if(ltl != null)
            {
                ltl.Text = "Changed By Page_Load";
            }    

            this.WriteControlID(this); //this=這個uc，所以這邊會所有控制項都跑一次
            //this.WriteControlID(this.PlaceHolder2); //只跑PlaceHolder2




        }


        private void WriteControlID(Control ctl) //寫出所有控制項
        {
            if (ctl == null)
                return;
            //遞迴一定要寫停止條件

            Response.Write(ctl.ID + "<br/>");

            if (ctl.Controls.Count == 0) //假設裡面沒有控制項就不跑迴圈，立即停止
                return;


            foreach(Control item in ctl.Controls)
            {
                this.WriteControlID(item);
            }

           
        }
    }
}