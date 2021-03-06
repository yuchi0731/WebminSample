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
    class DBHelper
    {
        public static string GetConnectionString()
        {
            //string val = ConfigurationManager.AppSettings["ConnectionString"];
            string val = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return val;
        }

        public static DataTable ReadDataTable(string connStr, string dbcommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    comm.Parameters.AddRange(list.ToArray());

                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    return dt;
                }
            }
        }


        public static DataRow ReadDataRow(string connStr, string dbcommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    comm.Parameters.AddRange(list.ToArray());


                    conn.Open();
                        var reader = comm.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        if (dt.Rows.Count == 0)
                            return null;

                        return dt.Rows[0];
             

                }
            }
        }


        public static int ModifyData(string connStr, string dbcommand, List<SqlParameter> paramlist)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                    comm.Parameters.AddRange(paramlist.ToArray());
                    conn.Open();
                    int effectRowsCount = comm.ExecuteNonQuery();
                    return effectRowsCount;
                }
            }
        }



        public static void CreatData(string connStr, string dbcommand, List<SqlParameter> createlist)
        {

            //connect db & execute
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))
                {
                   
                    comm.Parameters.AddRange(createlist.ToArray());
                    conn.Open();
                    comm.ExecuteNonQuery();

                }


            }
        }
    }
}
