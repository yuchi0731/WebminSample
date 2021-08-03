using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _0803_ucControl
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            Main mainMaster = this.Master as Main; //取得自己的Master屬性轉型成Main

            //因上面有設Main屬性，可呼叫Main裡的方法
            mainMaster.MyTitle = "預設頁"; //因為Main裡面為Main屬性，MyTitle也為Main屬性，所以要轉Main
            mainMaster.SetPageCaption("預設頁");//利用SetPageCaption方法，根據每一頁Title改變文字

            //this.ucCoverImage.SetText("第一個 uc");//測試ucCoevrImage Load中加入的property，已加入Default.aspx裡面(html標籤上)，故不呼叫
            this.ucCoverImage1.SetText("第二個 uc");
            this.ucCoverImage2.SetText("第二個 uc");
        }
    }
}