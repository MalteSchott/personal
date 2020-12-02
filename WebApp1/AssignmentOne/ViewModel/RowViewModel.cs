using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AssignmentOne
{
     // class for storing data from one row in the database

    public class RowViewModel : ViewModelBase
    {
        public RowViewModel()
        {
        }
        private string courseID;
        public string CourseID
        {
            get => courseID;
            set => SetProperty(ref courseID, value, "Course");
        }
        public string CourseName
        {
            get;
            set;
        }

        public string MaxMembers
        {
            get;
            set;
        }

        


        
    }
}
