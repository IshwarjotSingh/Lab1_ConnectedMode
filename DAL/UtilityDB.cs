using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // required for Sql Server Database
                             // required for ADO.net (SqlConnection, SqlCommand, SqlDataReader)
using System.Configuration; // to use ConfigurationManager class

namespace Lab1_ConnectedMode.DAL
{
    //static : You cannot create a class from this class
    public static class UtilityDB // tool class
    {
       /// <summary>
       /// Version 1: Working but not good. Why?
       /// This method return an active database connection
       /// </summary>
       /// <returns> an object of type SqlConnection</returns>
        //public static SqlConnection ConnectDB()
        //{
        //    SqlConnection conn = new SqlConnection();
        //    //conn.ConnectionString = "server =TITANCAO-PC\\MSSQLSERVER2017; database=EmployeeDB ; user=sa; password=lasalle";
        //    conn.ConnectionString = @"server =TITANCAO-PC\MSSQLSERVER2017; database=EmployeeDB ; user=sa; password=lasalle";
        //    conn.Open();  
        //    return conn;

        //}

        //Version 2: Better
        public static SqlConnection ConnectDB()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["EmployeeDB_Connection"].ConnectionString;
            conn.Open();
            return conn;

        }
    }
}
