﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


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



        public static DataRow GetAccounting(int id, string userID)//利用id查有沒有資料
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



        public static void CreateAccounting(string userID, string caption, int amount, int actType, string body)
        {
            //<<<<check input
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000.");
            if (actType < 0 || actType > 1)
                throw new ArgumentException("actType must");
            //check input>>>>>


            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                $@" INSERT INTO [dbo].[Accounting]
                (
                    UserID
                   ,Caption
                   ,Amount
                   ,ActType
                   ,CreateDate
                   ,Body
                )
                 VALUES
                (
                    @userID
                   ,@caption
                   ,@amount
                   ,@actType
                   ,@createDate
                   ,@body
                )
                ";


            //connect db & execute
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    comm.Parameters.AddWithValue("@userID", userID);
                    comm.Parameters.AddWithValue("@caption", caption);
                    comm.Parameters.AddWithValue("@amount", amount);
                    comm.Parameters.AddWithValue("@actType", actType);
                    comm.Parameters.AddWithValue("@createDate", DateTime.Now);
                    comm.Parameters.AddWithValue("@body", body);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();

                        //此方法不需要回傳結果
                    }

                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex);
                    }


                }


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


    }
}
