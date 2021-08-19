using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AccountingNote_ORM.DBModel;


namespace AccountingNote_DBSoure
{
    public class AccountingManager
    {
        //public static string GetConnectionString()
        //{
        //    //string val = ConfigurationManager.AppSettings["ConnectionString"];
        //    string val = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    return val;
        //}

        /// <summary>
        /// 查詢流水帳清單
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataTable GetAccountingList(string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT
                    ID,
                    UserID,
                    Caption,
                    Amount,
                    ActType,
                    CreateDate,
                    Body
                FROM Accounting
                WHERE UserID = @userID
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userID));

            try
            {
                return DBHelper.ReadDataTable(connStr, dbcommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 查詢流水帳清單//強型別清單
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Accounting> GetAccountingList(Guid userID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Accountings
                         where item.UserID == userID
                         select item);

                    var list = query.ToList();
                    return list;
                }
            }
            catch(Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 查詢流水帳//利用id查有沒有資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static Accounting GetAccounting(int id, Guid userID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Accountings
                         where item.ID == id && item.UserID == userID
                         select item);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }



        /// <summary>
        /// 查詢流水帳//利用id查有沒有資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataRow GetAccounting(int id, string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@"SELECT
                    ID,
                    UserID,
                    Caption,
                    Amount,
                    ActType,
                    CreateDate,
                    Body
                FROM Accounting
                WHERE id = @id AND UserID = @userID
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            list.Add(new SqlParameter("@userID", userID));

            try
            {
                return DBHelper.ReadDataRow(connStr, dbcommand, list);
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }


        }

        /// <summary>
        /// 建立流水帳
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        public static void CreateAccounting(string userID, string caption, int amount, int actType, string body)
        {
            //<<<<check input
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (actType < 0 || actType > 1)
                throw new ArgumentException("actType must");
            //check input>>>>>

            string bodyColumnSQL = "";
            string bodyValueSQL = "";
            if(!string.IsNullOrWhiteSpace(body))
            {
                bodyColumnSQL = ", Body";
                bodyValueSQL = ", @Body";
            }


            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" INSERT INTO [dbo].[Accounting]
                (
                    UserID
                   ,Caption
                   ,Amount
                   ,ActType
                   ,CreateDate
                   {bodyColumnSQL}
                )
                 VALUES
                (
                    @userID
                   ,@caption
                   ,@amount
                   ,@actType
                   ,@createDate
                   {bodyValueSQL}
                )
                ";

            List<SqlParameter> createlist = new List<SqlParameter>();
            createlist.Add(new SqlParameter("@userID", userID));
            createlist.Add(new SqlParameter("@caption", caption));
            createlist.Add(new SqlParameter("@amount", amount));
            createlist.Add(new SqlParameter("@actType", actType));
            createlist.Add(new SqlParameter("@createDate", DateTime.Now));
            
            if (!string.IsNullOrWhiteSpace(body))
            {
            createlist.Add(new SqlParameter("@body", body));
            }

            try
            {
               DBHelper.CreatData(connStr, dbcommand, createlist);
                
                //此方法不需要回傳結果
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                
            }

            

        }

        /// <summary>
        /// 建立流水帳
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        public static void CreateAccounting(Accounting accounting)
        {

            //<<<<check input
            if (accounting.Amount < 0 || accounting.Amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (accounting.ActType < 0 || accounting.ActType > 1)
                throw new ArgumentException("actType must");
            //check input>>>>>

       

            try
            {
                using (ContextModel context = new ContextModel())
                {
                    accounting.CreateDate = DateTime.Now;
                    context.Accountings.Add(accounting);
                    context.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }


        }
        /// <summary>
        /// LINQ修改流水帳
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool UpdateAccounting(Accounting accounting)
        {
            //<<<<check input
            if (accounting.Amount < 0 || accounting.Amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (accounting.ActType < 0 || accounting.ActType > 1)
                throw new ArgumentException("actType must");
            //check input>>>>>

            try
            {
                using (ContextModel context = new ContextModel())
                {
                    //連結DB查出資料
                    var dbObject =
                        context.Accountings.Where(obj => obj.ID == accounting.ID).FirstOrDefault();

                    if(dbObject != null)//如果DB有資料的話
                    {
                        dbObject.Caption = accounting.Caption;
                        dbObject.Body = accounting.Body;
                        dbObject.Amount = accounting.Amount;
                        dbObject.ActType = accounting.ActType;
                        dbObject.CreateDate = DateTime.Now;

                        context.SaveChanges();
                      
                    }                
                }

                return true;
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }


        
        public static bool UpdateAccounting(int ID, string userID, string caption, int amount, int actType, string body)
        {
            //<<<<check input
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (actType < 0 || actType > 1)
                throw new ArgumentException("actType must");
            //check input>>>>>


            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" UPDATE [Accounting]
                    SET
                    UserID = @userID
                   ,Caption = @caption
                   ,Amount = @amount
                   ,ActType = @actType
                   ,CreateDate = @createDate
                   ,Body = @body              
                 WHERE
                    ID = @id
                
                 ";

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@id", ID));
            paramlist.Add(new SqlParameter("@userID", userID));
            paramlist.Add(new SqlParameter("@caption", caption));
            paramlist.Add(new SqlParameter("@amount", amount));
            paramlist.Add(new SqlParameter("@actType", actType));
            paramlist.Add(new SqlParameter("@createDate", DateTime.Now));
            paramlist.Add(new SqlParameter("@body", body));

   
                    try
                    {                       
                        int effectRows = DBHelper.ModifyData(connStr, dbcommand, paramlist);

                        if (effectRows == 1)
                            return true;
                        else
                            return false;
                    }

                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex);
                        return false;
                    }




        }

        public static void DeleteAccounting(int ID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" DELETE [dbo].[Accounting]
                WHERE ID = @id
                ";

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@id", ID));



            try
            {
                DBHelper.ModifyData(connStr, dbcommand, paramlist);

            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }

           
        }

        public static void DeleteAccountingforAjax(int ID, string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" DELETE [dbo].[Accounting]
                WHERE ID = @id
                ";

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@id", ID));
            paramlist.Add(new SqlParameter("@userID", userID));


            try
            {
                DBHelper.ModifyData(connStr, dbcommand, paramlist);

            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }


        }

        public static void DeleteAccounting_ORM(int ID)
        {

            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbObject =
                        context.Accountings.Where(obj => obj.ID == ID).FirstOrDefault();

                    context.Accountings.Remove(dbObject);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }

        }

    }
}
