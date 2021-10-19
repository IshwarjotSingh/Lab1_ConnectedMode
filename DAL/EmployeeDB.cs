using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_ConnectedMode.BLL;
using Lab1_ConnectedMode.DAL;
using System.Data.SqlClient;

namespace Lab1_ConnectedMode.DAL
{
    public static class EmployeeDB // Tool class 
    {
        //Version 1: Working but not good
        //public static void SaveRecord(Employee emp)
        //{
        //    //step 1: Connect the DB
        //    SqlConnection connDB = UtilityDB.ConnectDB();
        //    //step 2: Perform INSERT operation 
        //    // SqlCommand : Create and customize the object of type SqlCommand
        //    SqlCommand cmdInsert = new SqlCommand();
        //    cmdInsert.CommandText = "INSERT INTO Employees " +
        //                            "VALUES(" + emp.EmployeeId + ",'" +
        //                                        emp.FirstName + "','" +
        //                                        emp.LastName + "','" +
        //                                        emp.JobTitle + "')";
        //    cmdInsert.Connection = connDB;
        //    cmdInsert.ExecuteNonQuery();
        //    //step 3: Close DB
        //    connDB.Close();      
        //}

        //Version 2: Better; easy to write; safer
        public static void SaveRecord(Employee emp)
        {
            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform INSERT operation 
            // SqlCommand : Create and customize the object of type SqlCommand
            SqlCommand cmdInsert = new SqlCommand();
            //parameterized query
            cmdInsert.CommandText = "INSERT INTO Employees (EmployeeId,FirstName,LastName,JobTitle) " +
                                    "VALUES (@EmployeeId,@FirstName,@LastName,@JobTitle)";

            cmdInsert.Parameters.AddWithValue("@EmployeeId",emp.EmployeeId);
            cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdInsert.Parameters.AddWithValue("@JobTitle", emp.JobTitle);
            cmdInsert.Connection = connDB;
            cmdInsert.ExecuteNonQuery();
            //step 3: Close DB
            connDB.Close();
        }

        public static Employee GetRecord(int empId)
        {

            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform SELECT operation 
            // SqlCommand : Create and customize the object of type SqlCommand
            SqlCommand cmdSelect = new SqlCommand();
           
            cmdSelect.CommandText = "SELECT * FROM Employees " +
                                    "WHERE EmployeeId = " + empId;
            cmdSelect.Connection = connDB;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader(); // applied to SELECT
            Employee emp = new Employee();
            if (sqlReader.Read())
            {
                emp.EmployeeId = Convert.ToInt32(sqlReader["EmployeeId"]);
                emp.FirstName = sqlReader["FirstName"].ToString();
                emp.LastName = sqlReader["LastName"].ToString();
                emp.JobTitle = sqlReader["JobTitle"].ToString();

            }
            else
            {
                emp = null;
            }

            return emp;
        }

        public static List<Employee> GetRecordList()
        {
            List<Employee> listEmp = new List<Employee>();
            //step 1: Connect the DB
            SqlConnection connDB = UtilityDB.ConnectDB();
            //step 2: Perform SELECT operation 
            // SqlCommand : Create and customize the object of type SqlCommand
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Employees",connDB);                       
            SqlDataReader sqlReader = cmdSelect.ExecuteReader(); // applied to SELECT
            Employee emp;
            while (sqlReader.Read())
            {
                //create the object here
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(sqlReader["EmployeeId"]);
                emp.FirstName = sqlReader["FirstName"].ToString();
                emp.LastName = sqlReader["LastName"].ToString();
                emp.JobTitle = sqlReader["JobTitle"].ToString();
                listEmp.Add(emp);

            }
            return listEmp;

        }

        public static void UpdateRecord(Employee emp)
        {


        }

        public static void DeleteRecord (int eId)
        {

        }


    }
}
