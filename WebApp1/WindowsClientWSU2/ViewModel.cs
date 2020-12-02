using System;
using WindowsClientWSU2.ServiceReferenceWSU2;
using System.Collections.Generic;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace WindowsClientWSU2
{
    class ViewModel : ViewModelBase


    {
        DataGrid dg;
        WebService2SoapClient reference;
        private ObservableCollection<Row> grid;
        public ObservableCollection<Row> Grid
        {
            get => grid;
            set => SetProperty(ref grid, value, "Grid");
        }


        private ObservableCollection<DropdownItem> items;

        public ObservableCollection<DropdownItem> Items
        {
            get { return items; }
            set { items = value; }
        }

        private DropdownItem selected;

        public DropdownItem Selected
        {
            get { return selected; }
            set {
                OnSelect(value);
                selected = value; }
        }

       
        public ViewModel(DataGrid dg)
        {
            this.dg = dg;

            try
            {
                reference = new WebService2SoapClient();

                // populates the Combobox
                Items = new ObservableCollection<DropdownItem>()
            {
            new DropdownItem(){Item="Member"},
            new DropdownItem(){Item="Course"},
            new DropdownItem(){Item="MemberCourse"}
            };


            }
            catch (Exception e)
            {
                HandleException(e);

            }



        }

        // Invokes method appropirate for the selected item in the Combobox
        private void OnSelect(DropdownItem selected)
        {
            String item = selected.Item;

            switch (item)
            {
                case "Member":
                    ShowMembers();
                    break;
                case "Course":
                    ShowCourses();
                    break;
                case "MemberCourse":
                    ShowMemberCourseRelations();
                    break;
                default:
                    break;
            }
        }




        // Creates an ObservableCollection with data from the Member table
        public void ShowMembers()
        {
            try
            {
                ArrayOfString[] memberMatrix = reference.GetAllMembers();


                Grid = new ObservableCollection<Row>();



                for (int i = 0; i < memberMatrix.Length; i++)
                {
                    ArrayOfString memberArray = memberMatrix[i];

                    Row row = new Row
                    {
                        Col1 = memberArray[0],
                        Col2 = memberArray[1],
                        Col3 = memberArray[2]
                    };

                    Grid.Add(row);
                    dg.Columns[0].Header = reference.GetMemberColumnNames()[0][0];
                    dg.Columns[1].Header = reference.GetMemberColumnNames()[1][0];
                    dg.Columns[2].Header = reference.GetMemberColumnNames()[2][0];

                }
            }
            catch (Exception e)
            {
                HandleException(e);

            }
        }

        // Creates an ObservableCollection with data from the Course table

        public void ShowCourses()
        {
            try
            {
                ArrayOfString[] courseMatrix = reference.GetAllCourses();
                Grid = new ObservableCollection<Row>();

                for (int i = 0; i < courseMatrix.Length; i++)
                {
                    ArrayOfString courseArray = courseMatrix[i];

                    Row row = new Row
                    {
                        Col1 = courseArray[0],
                        Col2 = courseArray[1],
                        Col3 = courseArray[2]
                    };

                    Grid.Add(row);
                    dg.Columns[0].Header = reference.GetCourseColumnNames()[0][0];
                    dg.Columns[1].Header = reference.GetCourseColumnNames()[1][0];
                    dg.Columns[2].Header = reference.GetCourseColumnNames()[2][0];


                }
            }

            catch (Exception e)
            {
                HandleException(e);

            }
        }
        // Creates an ObservableCollection with data from the MemberCourse table

        public void ShowMemberCourseRelations()
        {

            try {
                ArrayOfString[] memberCourseMatrix = reference.GetAllMemberCourses();
                Grid = new ObservableCollection<Row>();

                for (int i = 0; i < memberCourseMatrix.Length; i++)
                {
                    ArrayOfString memberCourseArray = memberCourseMatrix[i];

                    Row row = new Row
                    {
                        Col1 = memberCourseArray[0],
                        Col2 = memberCourseArray[1],
                    };

                    Grid.Add(row);
                    dg.Columns[0].Header = reference.GetMemberCourseColumnNames()[0][0];
                    dg.Columns[1].Header = reference.GetMemberCourseColumnNames()[1][0];
                    dg.Columns[2].Header = "";

                }
        }

            catch (Exception e)
            {
                HandleException(e);

            }
        }

        // error handling
        protected void HandleException(Exception e)
        { 
           
              Output = "An unexpected error occured, check your connection and restart the program.";
          
            
        }

        private string output;
        public string Output
        {
            get => output;
            set => SetProperty(ref output, value, "Output");
        }
    }
}
