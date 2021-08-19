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
    /// AccountingNoteList 的摘要描述
    /// </summary>
    public class AccountingNoteList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //取得使用者登入帳號
            string account = context.Request.QueryString["Account"];
            //若無輸入回傳404
            if(string.IsNullOrWhiteSpace(account))
            {
                context.Response.StatusCode = 404;
                context.Response.End();
                return;
            }
            //取得DB裡的使用者帳號資料
            var dr = UserInfoManager.GetUserInfoByAccount(account);
            //若帳號不存在回傳404
            if (dr == null)
            {
                context.Response.StatusCode = 404;
                context.Response.End();
                return;
            }


            //查使用者所有流水帳
            string userID = dr["ID"].ToString();
            DataTable dataTable = AccountingManager.GetAccountingList(userID);
            //拿來做序列化

            List<AccountingNoteViewModel> list = new List<AccountingNoteViewModel>();
            foreach(DataRow drAccounting in dataTable.Rows)
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}