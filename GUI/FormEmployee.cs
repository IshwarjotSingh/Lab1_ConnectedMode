using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1_ConnectedMode.BLL; //for Employee class
using Lab1_ConnectedMode.VALIDATION;

// Horizontally
// Vertically

namespace Lab1_ConnectedMode.GUI
{
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //validate the input data, not valid, enter again
            string tempId = textBoxEmployeeId.Text.Trim();
            if (!Validator.IsValidId(tempId, 4))
            {
                MessageBox.Show("Invalid Employee Id", "Error");
                textBoxEmployeeId.Clear();
                textBoxEmployeeId.Focus();
                return;
            }
            //Check duplicate EmployeeId
            Employee emp = new Employee();
            emp = emp.GetEmployee(Convert.ToInt32(tempId));
            if (emp !=null)
            {
                MessageBox.Show("This EmployeeId already exists!", "Duplicate Employee ID");
                textBoxEmployeeId.Clear();
                textBoxEmployeeId.Focus();
                return;
            }

            string tempFname = textBoxFirstName.Text.Trim();
            if (!Validator.IsValidName(tempFname))
            {
                MessageBox.Show("Invalid First Name", "Error");
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;
            }

            string tempLname = textBoxLastName.Text.Trim();
            if (!Validator.IsValidName(tempLname))
            {
                MessageBox.Show("Invalid Last Name", "Error");
                textBoxLastName.Clear();
                textBoxLastName.Focus();
                return;
            }

            string tempJob = textBoxJobTitle.Text;
            if (Validator.IsEmpty(tempJob))
            {
                MessageBox.Show("Jobtitle cannot be empty ", "Error");
                textBoxJobTitle.Focus();
                return;
            }
            Employee emp1 = new Employee();
            //Valid data
            emp1.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text);
            emp1.FirstName = textBoxFirstName.Text.Trim();
            emp1.LastName = textBoxLastName.Text.Trim();
            emp1.JobTitle = textBoxJobTitle.Text;
            emp1.SaveEmployee(emp1);
            MessageBox.Show("Employee Info saved successfully", "Confirmation");

        }

        private void buttonListAll_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            List<Employee> listEmp = new List<Employee>();
            listEmp = emp.GetEmployeeList();
            listViewEmployee.Items.Clear();
            if (listEmp !=null)
            {
                foreach (Employee anEmp in listEmp)
                {
                    ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                    item.SubItems.Add(anEmp.FirstName);
                    item.SubItems.Add(anEmp.LastName);
                    item.SubItems.Add(anEmp.JobTitle);
                    listViewEmployee.Items.Add(item);
                }

            }
            else
            {

            }

        }

        private void comboBoxOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = comboBoxOption.SelectedIndex;

            switch (indexSelected)
            {
                case 0: labelDisplay.Text = "Please enter Employee ID";
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;
                case 1:
                    labelDisplay.Text = "Please enter First Name";
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;

                case 2:
                    labelDisplay.Text = "Please enter Last Name";
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;

                default:
                    break;
            }


        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //data validation
            //validate the input data, not valid, enter again
            string tempId = textBoxInput.Text.Trim();
            if (!Validator.IsValidId(tempId, 4))
            {
                MessageBox.Show("Invalid Employee Id", "Error");
                textBoxInput.Clear();
                textBoxInput.Focus();
                return;
            }

            // perform search operation by Employee ID
            Employee emp = new Employee();
            emp = emp.GetEmployee(Convert.ToInt32(textBoxInput.Text.Trim()));
            if (emp !=null)
            {
                textBoxEmployeeId.Text = emp.EmployeeId.ToString();
                textBoxFirstName.Text = emp.FirstName;
                textBoxLastName.Text = emp.LastName;
                textBoxJobTitle.Text = emp.JobTitle;

            }
            else
            {
                MessageBox.Show("Employee not found !","Invalid Employee ID");
                textBoxInput.Clear();
                textBoxInput.Focus();
            }

        }
    }
}
