using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    /// <summary>
    /// WeatherDataHandler 的摘要描述
    /// </summary>
    public class WeatherDataHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            

            //取得帳號密碼
            string acc = context.Request.QueryString["account"];

            string pwd = context.Request.Form["Password"];

            if (acc == "yuchi" && pwd == "12345678")
            {
                //改成"application/json"
                context.Response.ContentType = "application/json";
                //context.Response.Write(
                //  @"{
                //       ""name"" : ""太魯閣國家公園太魯閣遊客中心"",
                //       ""T"" : 28,
                //       ""Pop"" : 20
                //    }"
                //    );

                WeatherDataModel model = WeatherDataReader.ReadData();
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(model); //等於真實從氣象局拿到的資料，變成JSON字串坐回傳
                context.Response.Write(jsonText);
            }


            else
            {
                context.Response.StatusCode = 401;
                context.Response.End();
            }



        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}