using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public class Temp
        {
            public int ForJSBase { get; set; } = 4;

            public int ForJSCoffecion { get; set; } = 3;

            public int ForJSInt { get; set; } = 500;

            public bool ForJSBool { get; set; } = true;

            public string ForJSString { get; set; } = "JS String";
          
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public string StringObject { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Temp temp = new Temp()
            {
                Name = "Tim",
                Age = 38
            };

            string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(temp);
            this.StringObject = jsonText;


        }
    }
}