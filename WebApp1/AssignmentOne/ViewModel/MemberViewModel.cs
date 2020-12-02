using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Controls;
namespace AssignmentOne
{
    class MemberViewModel : ViewModelBase
    {

        private ObservableCollection<RowViewModel> m_RowsRegistered;
        private ObservableCollection<RowViewModel> m_RowsAvailable;
        private string user;

        public DelegateCommand JoinCommand { get; }
        public DelegateCommand RemoveCommand { get; }

        private RowViewModel selectedAvailable;
        private RowViewModel selectedRegistered;

        public RowViewModel SelectedAvailable
        {
            get => selectedAvailable;
            set => SetProperty(ref selectedAvailable, value, "SelectedAvailable");
        }
        public RowViewModel SelectedRegistered
        {

            get => selectedRegistered;
            set => SetProperty(ref selectedRegistered, value, "SelectedRegistered");
        }


        public ObservableCollection<RowViewModel> RowsAvailable
        {
            get { return m_RowsAvailable; }
            set { m_RowsAvailable = value; }
        }

        public ObservableCollection<RowViewModel> RowsRegistered
        {
            get => m_RowsRegistered;
            set => SetProperty(ref m_RowsRegistered, value, "RowsRegistered");

        }

        public MemberViewModel(string user)
        {
            this.user = user;

            JoinCommand = new DelegateCommand(JoinCourse);
            RemoveCommand = new DelegateCommand(RemoveCourse);

            UpdateAvailableCourses();
            UpdateRegisteredCourses();
        }

        // adds Member to Course
        public void JoinCourse(object source)
        {
            try
            {
            int selectedCourseID = 0;
            if (!Int32.TryParse(SelectedAvailable.CourseID, out selectedCourseID))

            {
                selectedCourseID = -1;
            }
                if (Dal.getFreeSpotNo(selectedCourseID.ToString()) <= 0)
                {
                    Output = "Course is full";
                    return;
                }


                Dal.AddMemberToCourse(user, selectedCourseID.ToString());
              UpdateRegisteredCourses();
                Output = "Successfully registered to course";
            }

            catch (Exception e)
            {
                HandleException(e);
            }
        }

        // removes Member from COurse
        public void RemoveCourse(object source)
        {
            try
            {
                int selectedCourseID = 0;
                if (!Int32.TryParse(SelectedRegistered.CourseID, out selectedCourseID))
                {
                    selectedCourseID = -1;
                }

                Dal.RemoveMemberFromCourse(user, selectedCourseID.ToString());
                UpdateRegisteredCourses();
                Output = "Successfully unregistered from course";
            }


            catch (Exception e)
            {
                HandleException(e);
            }
        }

        // Populates the listview for available courses with data from the database
        public void UpdateAvailableCourses()
        {
            try {
                List<List<string>> cols = Dal.ShowCourses();
                RowsAvailable = new ObservableCollection<RowViewModel>();
                RowsRegistered = new ObservableCollection<RowViewModel>();

                foreach (List<string> rows in cols)
                {
                    RowsAvailable.Add(new RowViewModel
                    {
                        CourseID = rows[0],
                        CourseName = rows[1],
                        MaxMembers = rows[2]
                    });
                }
            } catch(Exception e)
            {
                HandleException(e);
            }
            }

        // Populates the listview for registered courses with data from the database
        public void UpdateRegisteredCourses() {

            try
            {
                RowsRegistered = new ObservableCollection<RowViewModel>();
                List<List<string>> colsRegistered = Dal.ShowCoursesTaken(user);

                foreach (List<string> rows in colsRegistered)
                {
                    RowsRegistered.Add(new RowViewModel
                    {
                        CourseID = rows[0],
                        CourseName = rows[1],
                        MaxMembers = rows[2]
                    });
                }
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }



        

       
        
        
    }

    
}
