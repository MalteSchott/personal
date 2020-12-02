using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOne.ViewModel
{
    class AdminViewModel : ViewModelBase
    {
        private String ssn;
        public String SSN
        {
            get { return ssn; }
            set
            {
                SetProperty(ref ssn, value, "SSN");
            }
        }

        private String ssnForDelete;
        public String SSNforDelete
        {
            get { return ssnForDelete; }
            set
            {
                SetProperty(ref ssnForDelete, value, "SSNforDelete");
            }
        }

        private String userName;
        public String UserName
        {
            get { return userName; }
            set
            {
                SetProperty(ref userName, value, "UserName");
            }
        }
        private String password1;
        public String Password1
        {
            get { return password1; }
            set
            {
                SetProperty(ref password1, value, "password1");
            }
        }
        private String password2;
        public String Password2
        {
            get { return password2; }
            set
            {
                SetProperty(ref password2, value, "password2");
            }
        }
        private String courseName;
        public String CourseName
        {
            get { return courseName; }
            set
            {
                SetProperty(ref courseName, value, "CourseName");
            }
        }
        private String courseID;
        public String CourseID
        {
            get { return courseID; }
            set
            {
                SetProperty(ref courseID, value, "CourseID");
            }
        }
        private String maxPart;
        public String MaxPart
        {
            get { return maxPart; }
            set
            {
                SetProperty(ref maxPart, value, "MaxPart");
            }
        }
        public DelegateCommand AddMemberCommand { get; }
        public DelegateCommand AddCourseCommand { get; }
        public DelegateCommand DeleteMemberCommand { get; }


        public AdminViewModel()
         {
            AddMemberCommand = new DelegateCommand(CreateMember);
            AddCourseCommand = new DelegateCommand(AddCourse);
            DeleteMemberCommand = new DelegateCommand(DeleteMember);

        }

        private void AddCourse(object obj)
        {
            if (CourseName == null || CourseName.Length == 0)
            {
                Output = "Please enter course name";
                return;
            }
            if (CourseID == null || CourseID.Length == 0)
            {
                Output = "Please enter course ID";
                return;
            }
            foreach (char c in CourseID.Trim())
            {
                if (c<'0' || c>'9')
                {
                    Output = "courseID can only contain numbers, invalid character '" + c + "'";
                    return;
                }
            }
            if (MaxPart == null || MaxPart.Length == 0)
            {
                Output = "Please enter max number of participants";
                return;
            }
            
            try
            {
                Dal.AddCourse(CourseID, CourseName, int.Parse(MaxPart));
                Output = "Course added";
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }

        private void CreateMember(object source)
        {
            
                Console.WriteLine("Create Member");
            if (SSN == null)
            {
                Output = "Please enter SSN";
                return;
            }
            if (SSN.Length != 12)
            {
                Output = String.Format("SSN needs to be twelve characters long, \"{0}\" is {1} characters long", SSN, SSN.Length);
                return;
            }

            if (!(Password1 == Password2))
            {
                Output = "Passwords do not match.";
                return;
            }
            if (UserName == null || UserName.Length == 0)
            {
                Output = "Please enter name";
                return;
            }
            if (Password1 == null || Password1.Length == 0)
            {
                Output = "Please enter password";
                return;
            }

            try
            {
                Dal.AddMember(SSN, UserName, Utils.CryptographyUtilities.Hash(Password1, SSN));
                Output = String.Format("Successfully added member: {0}, {1}", SSN, UserName);
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }

        private void DeleteMember(object source)
        {

            if (SSNforDelete == null)
            {
                Output = "Please enter SSN";
                return;
            }
            if (SSNforDelete.Length != 12)
            {
                Output = String.Format("SSN needs to be twelve characters long, \"{0}\" is {1} characters long", SSN, SSN.Length);
                return;
            }

            
            

            try
            {
                if (Dal.DeleteMember(SSNforDelete))
                    Output = String.Format("Successfully deleted member: {0}", SSNforDelete);
                else
                    Output = "No member was deleted";
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }
    }
}
