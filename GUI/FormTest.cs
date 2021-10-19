using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Text.RegularExpressions;
using Lab1_ConnectedMode.BLL;
using Lab1_ConnectedMode.VALIDATION;
using Lab1_ConnectedMode.DAL;
using System.Data.SqlClient; // just for testing

namespace Lab1_ConnectedMode.GUI
{
    public partial class FormTest : Form
    {
        Employee emp = new Employee();
        List<Employee> listEmp = new List<Employee>();
        //Employee anEmp = new Employee(7777, "Mary", "Green", "Programmer Analyst");
        public FormTest()
        {
            InitializeComponent();
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            emp.EmployeeId = 8787;
            emp.FirstName = "Quang Hoang";
            emp.LastName = "Cao";
            emp.JobTitle = "System Analyst";

        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            string msg = emp.EmployeeId + "\n" +
                         emp.FirstName + "\n" +
                         emp.LastName + "\n" +
                         emp.JobTitle;
            MessageBox.Show(msg, "My Name", MessageBoxButtons.OK,MessageBoxIcon.Information) ;

        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            string id = (textBoxEmployeeId.Text).Trim();
            //if (!(Validator.IsValidId(id)))
            //{
            //    MessageBox.Show("Invalid EmployeeId","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //    textBoxEmployeeId.Clear();
            //    textBoxEmployeeId.Focus();
            //    return;

            //}
            if (!(Validator.IsValidId(id,4)))
            {
                MessageBox.Show("Invalid EmployeeId", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeId.Clear();
                textBoxEmployeeId.Focus();
                return;

            }


        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Employee emp1 = new Employee();
            emp1.EmployeeId = 1111;
            emp1.FirstName = "Mary";
            emp1.LastName = "Green";
            emp1.JobTitle = "Programmer";
            listEmp.Add(emp1);

            Employee emp2 = new Employee();
            emp2.EmployeeId = 1112;
            emp2.FirstName = "Mary";
            emp2.LastName = "Brown";
            emp2.JobTitle = "Programmer Analyst";
            listEmp.Add(emp2);

            Employee emp3 = new Employee();
            emp3.EmployeeId = 1113;
            emp3.FirstName = "John";
            emp3.LastName = "Abbot";
            emp3.JobTitle = "Programmer Analyst";
            listEmp.Add(emp3);
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            //string show = "";
            //foreach (var anEmp in listEmp)
            //{
            //    show +=  anEmp.EmployeeId + "," + anEmp.FirstName + "," + anEmp.LastName + "," + anEmp.JobTitle + "\n";  
            //}

            //MessageBox.Show(show,"Employee List");

            //Clear the listView
            listViewEmployee.Items.Clear();
            foreach (Employee emp in listEmp)
            {
                ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                item.SubItems.Add(emp.FirstName);
                item.SubItems.Add(emp.LastName);
                item.SubItems.Add(emp.JobTitle);
                listViewEmployee.Items.Add(item);
            }

        }

        private void buttonConnectDB_Click(object sender, EventArgs e)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            MessageBox.Show(connDB.State.ToString(),"Database Connection");

        }
    }
}
