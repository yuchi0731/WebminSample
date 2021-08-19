using AccountingNote_DBSoure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Handlers.Models;

namespace WebApplication1.Handlers
{
    /// <summary>
    /// AccountingNoteHandler 的摘要描述
    /// </summary>
    public class AccountingNoteHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //actionName決定今天是用來做Create，Update，delete
            string actionName = context.Request
                .QueryString["ActionName"];


            if(string.IsNullOrEmpty(actionName))
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "text/plain";
                context.Response.Write("ActionName is required.");
                context.Response.End();
            }



            if(actionName == "create" || actionName == "Create")
            {

                //取得所有輸入值
                string caption = context.Request.Form["Caption"];
                string amountText = context.Request.Form["Amount"];
                string actTypeText = context.Request.Form["ActType"];
                string body = context.Request.Form["Body"];

                //ID of 使用者
                string id = "67e458c2-3f11-4e7b-a946-220a0bf3bc02";

                //必填輸入值檢查
                if (string.IsNullOrWhiteSpace(caption) ||
                    string.IsNullOrWhiteSpace(amountText) ||
                    string.IsNullOrWhiteSpace(actTypeText))
                {

                    this.ProcessError(context, "caption, amount, actType is required.");
                    return;
                }

                //試著將欄位做轉型
                int tempAmount, tempActType;
                if (!int.TryParse(amountText, out tempAmount) ||
                    !int.TryParse(actTypeText, out tempActType))
                {

                    this.ProcessError(context, "Amount, ActType should be a integer.");
                    return;
                }

                try
                {

               
                //建立流水帳
                AccountingManager.CreateAccounting(id, caption, tempAmount, tempActType, body);

                context.Response.ContentType = "text/plain";
                context.Response.Write("create ok");
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = 503;
                    context.Response.ContentType = "text/plain";
                    context.Response.End();
                }


            }


            else if (actionName == "update" || actionName == "Update")
            {
                //取得所有輸入值
                string accountingID = context.Request.Form["ID"];
                string caption = context.Request.Form["Caption"];
                string amountText = context.Request.Form["Amount"];
                string actTypeText = context.Request.Form["ActType"];
                string body = context.Request.Form["Body"];

                //ID of 使用者
                string id = "67e458c2-3f11-4e7b-a946-220a0bf3bc02";

                
                //必填輸入值檢查
                if (string.IsNullOrWhiteSpace(accountingID)||
                    string.IsNullOrWhiteSpace(caption) ||
                    string.IsNullOrWhiteSpace(amountText) ||
                    string.IsNullOrWhiteSpace(actTypeText))
                {

                    this.ProcessError(context, "ID, caption, amount, actType is required.");
                    return;
                }

                GetUserAccountingList(context, id);

                //試著將欄位做轉型
                int tempAccountingID,tempAmount, tempActType;
                if (!int.TryParse(accountingID, out tempAccountingID) ||
                    !int.TryParse(amountText, out tempAmount) ||
                    !int.TryParse(actTypeText, out tempActType))
                {

                    this.ProcessError(context, "Amount, ActType should be a integer.");
                    return;
                }

                //建立流水帳
                AccountingManager.UpdateAccounting(tempAccountingID, id, caption, tempAmount, tempActType, body);

                context.Response.ContentType = "text/plain";
                context.Response.Write("update ok");
            }

            else if (actionName == "delete" || actionName == "Delete")
            {
                //取得所有輸入值
                string IDText = context.Request.Form["ID"];
                string caption = context.Request.Form["Caption"];
                string amountText = context.Request.Form["Amount"];
                string actTypeText = context.Request.Form["ActType"];
                string body = context.Request.Form["Body"];

                //ID of 使用者
                string userID = "67e458c2-3f11-4e7b-a946-220a0bf3bc02";



                //必填輸入值檢查
                if (string.IsNullOrWhiteSpace(IDText))
                {

                    this.ProcessError(context, "ID is required.");
                    return;
                }

                //試著將欄位做轉型
                int tempAccountingID;
                if (!int.TryParse(IDText, out tempAccountingID))
                {
                    this.ProcessError(context, "ID should be a integer.");
                    return;
                }

                //建立流水帳
                AccountingManager.DeleteAccountingforAjax(tempAccountingID, userID);


                context.Response.ContentType = "text/plain";
                context.Response.Write("delete ok");
            }


            else if (actionName == "query"|| actionName == "Query")//查詢單筆
            {
                string idText = context.Request.Form["ID"];
                int id;
                int.TryParse(idText, out id);
                string userID = "67e458c2-3f11-4e7b-a946-220a0bf3bc02";

                var drAccounting = AccountingManager.GetAccounting(id, userID);

                if (drAccounting == null)
                {
                    context.Response.StatusCode = 404;
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("No data: " + idText);
                    context.Response.End();
                    return;
                }


                AccountingNoteViewModel model = new AccountingNoteViewModel()
                {
                    ID = drAccounting["ID"].ToString(),
                    Caption = drAccounting["Caption"].ToString(),
                    Body = drAccounting["Body"].ToString(),
                    CreateDate = drAccounting.Field<DateTime>("CreateDate").ToString("yyyy-MM-dd"),
                    ActType = drAccounting.Field<int>("ActType").ToString(),
                    Amount = drAccounting.Field<int>("Amount")

                };

                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);

            }


            else if (actionName == "list"|| actionName == "List")//查詢清單
            {
                string userID = "67e458c2-3f11-4e7b-a946-220a0bf3bc02";

                DataTable dataTable = AccountingManager.GetAccountingList(userID);
                //拿來做序列化

                List<AccountingNoteViewModel> list = new List<AccountingNoteViewModel>();
                foreach (DataRow drAccounting in dataTable.Rows)
                {
                    AccountingNoteViewModel model = new AccountingNoteViewModel()
                    {
                        ID = drAccounting["ID"].ToString(),
                        Caption = drAccounting["Caption"].ToString(),
                        Amount = drAccounting.Field<int>("Amount"),
                        ActType = (drAccounting.Field<int>("ActType") == 0) ? "支出" : "收入",
                        CreateDate = drAccounting.Field<DateTime>("CreateDate").ToString("yyyy-MM-dd")

                    };
                    list.Add(model);
                }


                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(list);

                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);

            }

        }




        private void GetUserAccountingList(HttpContext context, string id)
        {
            

            //查使用者所有流水帳
            string userID = id;
            DataTable dataTable = AccountingManager.GetAccountingList(userID);
            //拿來做序列化

            List<AccountingNoteViewModel> list = new List<AccountingNoteViewModel>();
            foreach (DataRow drAccounting in dataTable.Rows)
            {
                AccountingNoteViewModel model = new AccountingNoteViewModel()
                {
                    ID = drAccounting["ID"].ToString(),
                    Caption = drAccounting["Caption"].ToString(),
                    Amount = drAccounting.Field<int>("Amount"),
                    ActType = (drAccounting.Field<int>("ActType") == 0) ? "支出" : "收入",
                    CreateDate = drAccounting.Field<DateTime>("CreateDate").ToString("yyyy-MM-dd")

                };
                list.Add(model);
            }


            string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(list);

            context.Response.ContentType = "application/json";
            context.Response.Write(jsonText);
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