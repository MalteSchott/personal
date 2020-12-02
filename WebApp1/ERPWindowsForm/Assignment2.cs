using ERPWindowsForm.ERPService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPWindowsForm
{
    public partial class Assignment2 : Form
    {
        ERPService.WebServiceERPAssignmentSoapClient service = new ERPService.WebServiceERPAssignmentSoapClient();

        public Assignment2()
        {
            InitializeComponent();
        }

        //Returns user to the main page
        private void BackButton_Click(object sender, EventArgs e)
        {
            var MainWindow = (MainWindow)Tag;
            MainWindow.Show();
            Close();
        }

        //Displays all tables from database solution1
        private void Table1Button_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();

            try
            {

                ArrayOfString[] twoDimension = service.Tables1();
                ArrayOfString columnCheck = twoDimension[0];

                listView.View = View.Details;

                for (int j = 0; j < columnCheck.Count; j++)
                {
                    int y = j + 1;
                    listView.Columns.Add("Column " + y.ToString(), 120, HorizontalAlignment.Left);
                }

                for (int i = 0; i < twoDimension.Length; i++)
                {
                    ArrayOfString oneDimension = twoDimension[i];

                    ListViewItem item = new ListViewItem(oneDimension[0]);


                    for (int j = 0; j < oneDimension.Count; j++)
                    {
                        if (j > 0)
                        {
                            item.SubItems.Add(oneDimension[j]);
                        }
                    }
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ResponseLbl1.Text = ErrorHandling.HandleException(ex);
            }
        }

        //Displays all tables from database solution1
        private void Table2Button_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();

            try
            {
                ArrayOfString[] twoDimension = service.Tables2();
                ArrayOfString columnCheck = twoDimension[0];

                listView.View = View.Details;

                for (int j = 0; j < columnCheck.Count; j++)
                {
                    int y = j + 1;
                    listView.Columns.Add("Column " + y.ToString(), 120, HorizontalAlignment.Left);
                }

                for (int i = 0; i < twoDimension.Length; i++)
                {
                    ArrayOfString oneDimension = twoDimension[i];

                    ListViewItem item = new ListViewItem(oneDimension[0]);


                    for (int j = 0; j < oneDimension.Count; j++)
                    {
                        if (j > 0)
                        {
                            item.SubItems.Add(oneDimension[j]);
                        }
                    }
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ResponseLbl1.Text = ErrorHandling.HandleException(ex);
            }
        }

        //Displays all indexes from database
        private void IndexButton_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();

            try
            {
                ArrayOfString[] twoDimension = service.GetAllIndex();
                ArrayOfString columnCheck = twoDimension[0];

                listView.View = View.Details;

                for (int j = 0; j < columnCheck.Count; j++)
                {
                    int y = j + 1;
                    listView.Columns.Add("Column " + y.ToString(), 120, HorizontalAlignment.Left);
                }

                for (int i = 0; i < twoDimension.Length; i++)
                {
                    ArrayOfString oneDimension = twoDimension[i];

                    ListViewItem item = new ListViewItem(oneDimension[0]);


                    for (int j = 0; j < oneDimension.Count; j++)
                    {
                        if (j > 0)
                        {
                            item.SubItems.Add(oneDimension[j]);
                        }
                    }
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ResponseLbl1.Text = ErrorHandling.HandleException(ex);
            }
        }

        //Displays all relatives for a given employee from database
        private void RelativesButton_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();
            string empID = empIDTxt.Text;

            if (empID == "")
            {
                ResponseLbl2.Text = "Please specify Employee ID";
            }
            else
            {
                try
                {
                    ArrayOfString[] twoDimension = service.GetRelatives(empID);
                    ArrayOfString columnCheck = twoDimension[0];

                    listView.View = View.Details;

                    for (int j = 0; j < columnCheck.Count; j++)
                    {
                        int y = j + 1;
                        listView.Columns.Add("Column " + y.ToString(), 120, HorizontalAlignment.Left);
                    }

                    for (int i = 0; i < twoDimension.Length; i++)
                    {
                        ArrayOfString oneDimension = twoDimension[i];

                        ListViewItem item = new ListViewItem(oneDimension[0]);


                        for (int j = 0; j < oneDimension.Count; j++)
                        {
                            if (j > 0)
                            {
                                item.SubItems.Add(oneDimension[j]);
                            }
                        }
                        listView.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    ResponseLbl2.Text = ErrorHandling.HandleException(ex);
                }
            }
        }

        //Displays all columns for the employee table from database solution1
        private void EmployeeColumns1Button_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();

            try
            {
                ArrayOfString oneDimension = service.GetEmployeeColumns1();
                listView.View = View.Details;
                listView.Columns.Add("Name ", 120, HorizontalAlignment.Left);

                for (int i = 0; i < oneDimension.Count; i++)
                {
                    ListViewItem item = new ListViewItem(oneDimension[i]);
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ResponseLbl2.Text = ErrorHandling.HandleException(ex);
            }
        }

        //Displays all columns for the employee table from database solution2
        private void EmployeeColumns2Button_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();

            try
            {
                ArrayOfString[] twoDimension = service.GetEmployeeColumns2();
                ArrayOfString columnCheck = twoDimension[0];

                listView.View = View.Details;

                for (int j = 0; j < columnCheck.Count; j++)
                {
                    int y = j + 1;
                    listView.Columns.Add("Column " + y.ToString(), 120, HorizontalAlignment.Left);
                }

                for (int i = 0; i < twoDimension.Length; i++)
                {
                    ArrayOfString oneDimension = twoDimension[i];

                    ListViewItem item = new ListViewItem(oneDimension[0]);


                    for (int j = 0; j < oneDimension.Count; j++)
                    {
                        if (j > 0)
                        {
                            item.SubItems.Add(oneDimension[j]);
                        }
                    }
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ResponseLbl2.Text = ErrorHandling.HandleException(ex);
            }
        }

        //Displays all key constraints from database
        private void KeysButton_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();

            try
            {
                ArrayOfString[] twoDimension = service.GetAllKeys();
                ArrayOfString columnCheck = twoDimension[0];

                listView.View = View.Details;

                for (int j = 0; j < columnCheck.Count; j++)
                {
                    int y = j + 1;
                    listView.Columns.Add("Column " + y.ToString(), 120, HorizontalAlignment.Left);
                }

                for (int i = 0; i < twoDimension.Length; i++)
                {
                    ArrayOfString oneDimension = twoDimension[i];

                    ListViewItem item = new ListViewItem(oneDimension[0]);


                    for (int j = 0; j < oneDimension.Count; j++)
                    {
                        if (j > 0)
                        {
                            item.SubItems.Add(oneDimension[j]);
                        }
                    }
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ResponseLbl1.Text = ErrorHandling.HandleException(ex);
            }
        }

        //Displays all table constraints from database
        private void ConstraintsButton_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();

            try
            {
                ArrayOfString[] twoDimension = service.GetAllConstraints();
                ArrayOfString columnCheck = twoDimension[0];

                listView.View = View.Details;

                for (int j = 0; j < columnCheck.Count; j++)
                {
                    int y = j + 1;
                    listView.Columns.Add("Column " + y.ToString(), 120, HorizontalAlignment.Left);
                }

                for (int i = 0; i < twoDimension.Length; i++)
                {
                    ArrayOfString oneDimension = twoDimension[i];

                    ListViewItem item = new ListViewItem(oneDimension[0]);


                    for (int j = 0; j < oneDimension.Count; j++)
                    {
                        if (j > 0)
                        {
                            item.SubItems.Add(oneDimension[j]);
                        }
                    }
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ResponseLbl1.Text = ErrorHandling.HandleException(ex);
            }
        }

        //Displays the employees that has been sick during 2004 from database
        private void Sick2004Button_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();

            try
            {
                ArrayOfString[] twoDimension = service.GetSickEmployees();
                ArrayOfString columnCheck = twoDimension[0];

                listView.View = View.Details;

                for (int j = 0; j < columnCheck.Count; j++)
                {
                    int y = j + 1;
                    listView.Columns.Add("Column " + y.ToString(), 120, HorizontalAlignment.Left);
                }

                for (int i = 0; i < twoDimension.Length; i++)
                {
                    ArrayOfString oneDimension = twoDimension[i];

                    ListViewItem item = new ListViewItem(oneDimension[0]);


                    for (int j = 0; j < oneDimension.Count; j++)
                    {
                        if (j > 0)
                        {
                            item.SubItems.Add(oneDimension[j]);
                        }
                    }
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ResponseLbl2.Text = ErrorHandling.HandleException(ex);
            }
        }

        //Displays the employee that has the most absense from database
        private void AbsenseButton_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();

            try
            {
                ArrayOfString[] twoDimension = service.AbsenseEmployee();
                ArrayOfString columnCheck = twoDimension[0];

                listView.View = View.Details;

                for (int j = 0; j < columnCheck.Count; j++)
                {
                    int y = j + 1;
                    listView.Columns.Add("Column " + y.ToString(), 120, HorizontalAlignment.Left);
                }

                for (int i = 0; i < twoDimension.Length; i++)
                {
                    ArrayOfString oneDimension = twoDimension[i];

                    ListViewItem item = new ListViewItem(oneDimension[0]);


                    for (int j = 0; j < oneDimension.Count; j++)
                    {
                        if (j > 0)
                        {
                            item.SubItems.Add(oneDimension[j]);
                        }
                    }
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ResponseLbl2.Text = ErrorHandling.HandleException(ex);
            }
        }

        //Displays a Employee given a specific Employee ID from database
        private void EmployeeInfoButton_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();
            string empID = empIDTxt.Text;

            if (empID == "")
            {
                ResponseLbl2.Text = "Please specify Employee ID";
            }
            else
            {
                try
                {
                    ArrayOfString[] twoDimension = service.SearchEmployee(empID);
                    ArrayOfString columnCheck = twoDimension[0];

                    listView.View = View.Details;

                    for (int j = 0; j < columnCheck.Count; j++)
                    {
                        int y = j + 1;
                        listView.Columns.Add("Column " + y.ToString(), 120, HorizontalAlignment.Left);
                    }

                    for (int i = 0; i < twoDimension.Length; i++)
                    {
                        ArrayOfString oneDimension = twoDimension[i];

                        ListViewItem item = new ListViewItem(oneDimension[0]);


                        for (int j = 0; j < oneDimension.Count; j++)
                        {
                            if (j > 0)
                            {
                                item.SubItems.Add(oneDimension[j]);
                            }
                        }
                        listView.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    ResponseLbl2.Text = ErrorHandling.HandleException(ex);
                }
            }
        }

        //Displays metadata for Employee table and related tables from database
        private void MetaButton_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();

            try
            {
                ArrayOfString[] twoDimension = service.EmployeeData();
                ArrayOfString columnCheck = twoDimension[0];

                listView.View = View.Details;

                for (int j = 0; j < columnCheck.Count; j++)
                {
                    int y = j + 1;
                    listView.Columns.Add("Column " + y.ToString(), 120, HorizontalAlignment.Left);
                }

                for (int i = 0; i < twoDimension.Length; i++)
                {
                    ArrayOfString oneDimension = twoDimension[i];

                    ListViewItem item = new ListViewItem(oneDimension[0]);


                    for (int j = 0; j < oneDimension.Count; j++)
                    {
                        if (j > 0)
                        {
                            item.SubItems.Add(oneDimension[j]);
                        }
                    }
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ResponseLbl2.Text = ErrorHandling.HandleException(ex);
            }
        }

        //Displays all Employees from the database
        private void AllEmployeeButton_Click(object sender, EventArgs e)
        {
            ResponseLbl1.Text = "";
            ResponseLbl2.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();

            try
            {
                ArrayOfString[] twoDimension = service.EmployeeTables();
                ArrayOfString columnCheck = twoDimension[0];

                listView.View = View.Details;

                for (int j = 0; j < columnCheck.Count; j++)
                {
                    int y = j + 1;
                    listView.Columns.Add("Column " + y.ToString(), 120, HorizontalAlignment.Left);
                }

                for (int i = 0; i < twoDimension.Length; i++)
                {
                    ArrayOfString oneDimension = twoDimension[i];

                    ListViewItem item = new ListViewItem(oneDimension[0]);


                    for (int j = 0; j < oneDimension.Count; j++)
                    {
                        if (j > 0)
                        {
                            item.SubItems.Add(oneDimension[j]);
                        }
                    }
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                ResponseLbl2.Text = ErrorHandling.HandleException(ex);
            }
        }
    }
}
