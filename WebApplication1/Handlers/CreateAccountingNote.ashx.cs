using AccountingNote_DBSoure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Handlers
{
    /// <summary>
    /// CreateAccountingNote 的摘要描述
    /// </summary>
    public class CreateAccountingNote : IHttpHandler
    {
        
        public void ProcessRequest(HttpContext context)
        {
            //取得POST內容

            if(context.Request.HttpMethod!="POST")
            {
                this.ProcessError(context, "POST Only.");
                return;
            }

            //取得所有輸入值
            string caption = context.Request.Form["Caption"];
            string amountText = context.Request.Form["Amount"];
            string actTypeText = context.Request.Form["ActType"];
            string body = context.Request.Form["Body"];

            //ID of 使用者
            string id = "67e458c2-3f11-4e7b-a946-220a0bf3bc02";

            //必填輸入值檢查
            if (string.IsNullOrWhiteSpace(caption)||
                string.IsNullOrWhiteSpace(amountText)||
                string.IsNullOrWhiteSpace(actTypeText))
            {

                this.ProcessError(context, "caption, amount, actType is required.");
                return;
            }

            //試著將欄位做轉型
            int tempAmount, tempActType;
            if (!int.TryParse(amountText, out tempAmount)|| 
                !int.TryParse(actTypeText, out tempActType))
            {

                this.ProcessError(context, "Amount, ActType should be a integer.");
                return;
            }

            //建立流水帳
            AccountingManager.CreateAccounting(id, caption, tempAmount, tempActType, body);


            context.Response.ContentType = "text/plain";
            context.Response.Write("ok");
        }

        private void ProcessError(HttpContext context, string msg)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "text/plain";
            context.Response.Write(msg);
            context.Response.End();
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