using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccountingNote_DBSoure;
using System.Data;
using System.Drawing;
using AccountingNote_Auth;
using AccountingNote_ORM.DBModel;

namespace _0728_1.SystemAdmin
{
    public partial class AccountingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check logined
            //if (this.Session["UserLoginInfo"] == null)>>錯誤性太高封裝成方法
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrentUser();

            if (currentUser == null) //如果帳號不存在，導向登入頁
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }


            //read accounting data
            //var dt = AccountingManager.GetAccountingList(currentUser.ID);
            var list = AccountingManager.GetAccountingList(currentUser.ID);//強型別清單
            //if (dt.Rows.Count > 0) //check is empty data (大於0就做資料繫結)
            //{

            //    var dtPaged = this.GetPagedDataTable(dt);

            //    this.ucPager2.TotalSize = dt.Rows.Count;
            //    this.ucPager2.Bind();


            //    this.gvAccountingList.DataSource = dtPaged;
            //    this.gvAccountingList.DataBind();


            //}
            //else
            //{
            //    this.gvAccountingList.Visible = false;
            //    this.plcNoData.Visible = true;
            //}

            //LINQ改寫
            if (list.Count > 0) //check is empty data (大於0就做資料繫結)
            {


                var pageList = this.GetPageDataTable(list);
                this.gvAccountingList.DataSource = pageList;
                this.gvAccountingList.DataBind();
                
                this.ucPager2.TotalSize = list.Count;
                this.ucPager2.Bind();


            }
            else
            {
                this.gvAccountingList.Visible = false;
                this.plcNoData.Visible = true;
            }


        }


       


        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;

            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;

            return intPage;
        }

        private List<Accounting> GetPageDataTable(List<Accounting> list)
        {
            int startIndex = (this.GetCurrentPage() - 1) * 10;
            return list.Skip(startIndex).Take(10).ToList();

        }

        private DataTable GetPagedDataTable(DataTable dt)
        {
            DataTable dtPaged = dt.Clone();
            int pageSize = this.ucPager2.PageSize;


            int startIndex = (this.GetCurrentPage() - 1) * 10;
            int endIndex = (this.GetCurrentPage()) * 10;

            if (endIndex > dt.Rows.Count)
                endIndex = dt.Rows.Count;

            for (var i = startIndex; i < endIndex; i++)
            {
                DataRow dr = dt.Rows[i];
                var drNew = dtPaged.NewRow();

                foreach (DataColumn dc in dt.Columns)
                {
                    drNew[dc.ColumnName] = dr[dc];
                }

                dtPaged.Rows.Add(drNew);
            }

            return dtPaged;
        }



        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/AccountingDetail.aspx");
        }

        protected void gvAccountingList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;

            if (row.RowType == DataControlRowType.DataRow)
            {
                //Literal ltl = row.FindControl("ltActType") as Literal;
                Label lbl = row.FindControl("lblActType") as Label;


                //var dr = row.DataItem as DataRowView; //DataItem本身是object要轉型別
                //int actType = dr.Row.Field<int>("ActType");

                //改強型別list取得資料
                var rowData = row.DataItem as Accounting;
                int actType = rowData.ActType;

                if (actType == 0)
                {
                    //ltl.Text = "支出";
                    lbl.Text = "支出";
                }
                else
                {
                    //ltl.Text = "收入";
                    lbl.Text = "收入";
                }

                if (rowData.Amount > 1500)
                {
                    lbl.ForeColor = Color.Red;

                }
            }
        }





    }
}