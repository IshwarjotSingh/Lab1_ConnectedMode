using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_ConnectedMode.DAL;

namespace Lab1_ConnectedMode.BLL
{
   public class Employee // starts with a capital letter; singular noun
    {
        //private class variables
        // private : to implement the concept Encapsulation
        private int employeeId;
        private string firstName;
        private string lastName;
        private string jobTitle;

        //default constructor
        public Employee()
        {
            employeeId = 0;
            firstName = "";
            lastName = "";
            jobTitle = "";

        }

        //parameterized constructor

        //public Employee(int empId, string fname,string lname,string job)
        //{
        //    employeeId = empId;
        //    firstName = fname;
        //    lastName = lname;
        //    jobTitle = job;

        //}

        public Employee(int employeeId, string firstName, string lastName, string jobTitle)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.jobTitle = jobTitle;

        }

        //properties
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; } 
      
        //custom methods
        public void SaveEmployee(Employee emp)
        {
            EmployeeDB.SaveRecord(emp);      
        }

        public Employee GetEmployee(int eId)
        {
            return EmployeeDB.GetRecord(eId);
        }
        public List<Employee> GetEmployeeList()
        {
            return EmployeeDB.GetRecordList();
        }

        public void UpdateEmployee(Employee emp)
        {
            EmployeeDB.UpdateRecord(emp);
        }

        public void DeleteEmployee (int empId)
        {
            EmployeeDB.DeleteRecord(empId);
        }
    }
}
