using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;



namespace AccountingNote_DBSoure
{
    public class UserInfoManager
    {
        //public static string GetConnectionString()
        //{
        //    //string val = ConfigurationManager.AppSettings["ConnectionString"];
        //    string val = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    return val;
        //}


        public static DataRow GetUserInfoByAccount(string account)
        {
            string connectionString = DBHelper.GetConnectionString();

            string dbCommandString =
                 @"SELECT [ID], [Account], [PWD], [Name], [Email]
                   FROM UserInfo
                   WHERE [Account] = @account
                 ";



            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand command = new SqlCommand(daCommandString, connection))
            //    {
            //        command.Parameters.AddWithValue("@account", account); //因為有增加參數，所以要參數化查詢
            //        try
            //        {
            //            connection.Open();
            //            SqlDataReader reader = command.ExecuteReader();

            //            DataTable dt = new DataTable();
            //            dt.Load(reader);
            //            reader.Close();

            //            if (dt.Rows.Count == 0)
            //                return null;

            //            DataRow dr = dt.Rows[0]; //假設不是0筆就回傳
            //            return dr;



            //        }
            //        catch (Exception ex)
            //        {
            //            Logger.WriteLog(ex);
            //            Console.WriteLine(ex.ToString());
            //            return null;
            //        }
            //    }
            //}
        }



    }
}
