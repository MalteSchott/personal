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
    public partial class Assignment1 : Form
    {
        ERPService.WebServiceERPAssignmentSoapClient service = new ERPService.WebServiceERPAssignmentSoapClient();

        public Assignment1()
        {
            InitializeComponent();
        }

        //Displays a user with the given User ID from the database
        private void FindButton_Click(object sender, EventArgs e)
        {
            ResponseLbl.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();


            string table = "CRONUS Sverige AB$EP User";
            string userID = userIDTxt.Text;

            if (userID == "")
            {
                ResponseLbl.Text = "Please specify User ID";
            }
            else
            {
                try
                {



                        ArrayOfString meta = service.FetchColumns(table);
                        ArrayOfString[] twoDimension = service.SearchUser(userID);

                        listView.View = View.Details;

                        for (int j = 0; j < meta.Count; j++)
                        {
                            listView.Columns.Add(meta[j], 100, HorizontalAlignment.Left);
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
                    ResponseLbl.Text = ErrorHandling.HandleException(ex);
                }
            }
        }

        //Creates a User in the database
        private void CreateButton_Click(object sender, EventArgs e)
        {
            ResponseLbl.Text = "";
            string userID = userIDTxt.Text;
            string languageID = languageIDTxt.Text;

            if (userID == "")
            {
                ResponseLbl.Text = "Please specify User ID";
            }
            if (languageID == "")
            {
                ResponseLbl.Text = "Please specify Language ID";
            }
            if(userID != "" && languageID != "")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(languageID, "^[a-zA-Z0-9\x20]+$"))
                {
                    try
                    {
                        bool response = service.CreateUser(userID, languageID);
                        if (response == true)
                        {
                            ResponseLbl.Text = "User Added";
                        }
                        else
                        {
                            ResponseLbl.Text = "Could not add User, make sure User ID is available";
                        }
                    }
                    catch (Exception ex)
                    {
                        ResponseLbl.Text = ErrorHandling.HandleException(ex);
                    }
                }
                else
                {
                    ResponseLbl.Text = "Launguage ID can not contain special characters";
                }
            }
        }

        //Updates the attributes of a User in the database
        private void EditButton_Click(object sender, EventArgs e)
        {
            ResponseLbl.Text = "";
            string userID = userIDTxt.Text;
            string languageID = languageIDTxt.Text;

            if(userID == "")
            {
                ResponseLbl.Text = "Please specify User ID";
            }
            if (languageID == "")
            {
                ResponseLbl.Text = "Please specify Language ID";
            }
            if (userID != "" && languageID != "")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(languageID, "^[a-zA-Z0-9\x20]+$"))
                {
                    try
                    {
                        bool response = service.EditUser(userID, languageID);
                        if (response == true)
                        {
                            ResponseLbl.Text = "User Updated";
                        }
                        else
                        {
                            ResponseLbl.Text = "Could not Edit User, make sure the User exists";
                        }
                    }
                    catch (Exception ex)
                    {
                        ResponseLbl.Text = ErrorHandling.HandleException(ex);
                    }
                }
                else
                {
                    ResponseLbl.Text = "Launguage ID can not contain special characters";
                }
            }
        }

        //Deletes a User from the database
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            ResponseLbl.Text = "";
            string userID = userIDTxt.Text;

            if (userID == "")
            {
                ResponseLbl.Text = "Please specify User ID";
            }
            else
            {
                try
                {
                    bool response = service.DeleteUser(userID);
                    if (response == true)
                    {
                        ResponseLbl.Text = "User Removed";
                    }
                    else
                    {
                        ResponseLbl.Text = "Could not Delete User, make sure the User exists";
                    }
                }
                catch (Exception ex)
                {
                    ResponseLbl.Text = ErrorHandling.HandleException(ex);
                }
            }
        }

        //Returns the User to the main page
        private void BackButton_Click(object sender, EventArgs e)
        {
            var MainWindow = (MainWindow)Tag;
            MainWindow.Show();
            Close();
        }

        //Displays all Users in the database
        private void DisplayButton_Click(object sender, EventArgs e)
        {
            ResponseLbl.Text = "";
            listView.Items.Clear();
            listView.Columns.Clear();

            string table = "CRONUS Sverige AB$EP User";

            try
            {
                ArrayOfString meta = service.FetchColumns(table);
                ArrayOfString[] twoDimension = service.GetUserTable();

                listView.View = View.Details;

                for (int j = 0; j < meta.Count; j++)
                {
                    listView.Columns.Add(meta[j], 100, HorizontalAlignment.Left);
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
                ResponseLbl.Text = ErrorHandling.HandleException(ex);
            }
        }
    }
}
