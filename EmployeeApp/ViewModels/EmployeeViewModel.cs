using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Input;
using System.Windows;
using EmployeeApp.Services;

namespace EmployeeApp.ViewModels
{

    public class EmployeeViewModel
    {
        //Collection
        public ObservableCollection<Employee> Employees { get; set; }

        //Xml file patch
        string filePath;
        
        //Commands
        public RelayCommand OpenCommand { get; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand AddCommand { get; }


        public EmployeeViewModel()
        {
            //Construct button commands
            OpenCommand = new RelayCommand(OpenFile);
            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(DeleteRows);
            AddCommand = new RelayCommand(AddRow);

            //Construct collection
            Employees = new ObservableCollection<Employee>();

        }

        public void OpenFile(object obj)
        {
            //Create OpenFileDialog and set filter for XML
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".xml",
                Filter = "XML files (*.xml)|*.xml"
            };

            //Display dialog
            Nullable<bool> result = dialog.ShowDialog();

            //Get result
            if (result == true)
            {
                filePath = dialog.FileName;

                XmlDocument xmlDoc = new XmlDocument();
                try
                {
                    xmlDoc.Load(filePath);
                }
                catch (Exception e)
                {
                    filePath = null;
                    MessageBox.Show("XML format required", "", MessageBoxButton.OK);
                    return;
                }
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("Users");
                XmlNode node = nodes.Item(0);

                Employees.Clear();

                //Add result to databound collection
                foreach (XmlNode childNode in node)
                {
                    XmlAttribute civilState = childNode.Attributes["CivilState"];
                    XmlAttribute firstName = childNode.Attributes["FirstName"];
                    XmlAttribute lastName = childNode.Attributes["LastName"];

                    if(firstName == null || lastName == null || civilState == null)
                    {
                        Employees.Clear();
                        filePath = null;
                        MessageBox.Show("Invalid XML file", "", MessageBoxButton.OK);
                        return;
                    }

                    Employees.Add(new Employee(firstName.Value, lastName.Value, ParseCivilState(civilState.Value)));
                }
            }
        }

        //Converts civilstate integer to string values
        private CivilState ParseCivilState(string civilstate)
        {
            switch (civilstate)
            {
                case "0":
                    return CivilState.Unknown;

                case "1":
                    return CivilState.Single;

                case "2":
                    return CivilState.Married;

                default:
                    return CivilState.Unknown;
            }
        }

        //Add an empty row to databound collection
        public void AddRow(object obj)
        {
            Employees.Add(new Employee());
        }

        //Is user allowed to save to XML document
        public bool CanSave(object obj)
        {
            TextValidation validation = new TextValidation();
            if(filePath == null)
            {
                return false;
            }
            foreach (Employee employee in Employees)
            {
                if(!validation.ValidateEmployee(employee))
                    return false;
            }
            return true;
        }
        public void Save(object obj)
        {
            //Reconstruct xml
            XmlDocument xmlDoc = new XmlDocument();

            XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", null, null);
            xmlDoc.AppendChild(declaration);

            XmlNode rootNode = xmlDoc.CreateElement("UserInformation");
            xmlDoc.AppendChild(rootNode);

            XmlNode usersNode = xmlDoc.CreateElement("Users");
            rootNode.AppendChild(usersNode);

            //Add all users in datagrid
            foreach(Employee employee in Employees)
            {
                XmlNode userNode = xmlDoc.CreateElement("User");
                
                //Add Firstname attribute
                XmlAttribute firstName = xmlDoc.CreateAttribute("FirstName");
                firstName.Value = employee.FirstName;
                userNode.Attributes.Append(firstName);

                //Add Lastname attribute
                XmlAttribute lastName = xmlDoc.CreateAttribute("LastName");
                lastName.Value = employee.LastName;
                userNode.Attributes.Append(lastName);

                //Add Civilstate attribute
                CivilState civilStateEnum = employee.CivilState;
                string civilStateInt = null;

                //Convert civilstate into integer
                switch(civilStateEnum)
                {
                    case CivilState.Unknown:
                        civilStateInt = "0";
                        break;
                    case CivilState.Single:
                        civilStateInt = "1";
                        break;
                    case CivilState.Married:
                        civilStateInt = "2";
                        break;
                }

                XmlAttribute civilState = xmlDoc.CreateAttribute("CivilState");
                civilState.Value = civilStateInt;
                userNode.Attributes.Append(civilState);

                usersNode.AppendChild(userNode);
                
            }
            xmlDoc.Save(filePath);
            MessageBox.Show("Changes saved", "", MessageBoxButton.OK);
        }

        public void DeleteRows(object obj)
        {
            //Display warning
            MessageBoxResult result = MessageBox.Show("Are you sure that you want to delete the selected row(s)?", "", MessageBoxButton.YesNo);

            if(result == MessageBoxResult.Yes)
            {
                //Remove employees from databound collection
                List<Employee> items = new List<Employee>();
                foreach (Employee employee in (System.Collections.IList)obj)
                {
                    items.Add(employee);
                }

                foreach (Employee employee in items)
                {
                    Employees.Remove(employee);
                }
            }

        }
    }
}
