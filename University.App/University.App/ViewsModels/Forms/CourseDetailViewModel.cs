using System;
using System.Collections.Generic;
using System.Text;
using University.App.DTOs;
using University.App.ViewModels;

namespace University.App.ViewsModels.Forms
{
    public class CourseDetailViewModel : BaseViewModel
    {
        private CoursesDTO _course;
        public CoursesDTO Course {

            get { return _course; }
            set { this.SetValue(ref _course, value); }
        }

        public CourseDetailViewModel(CoursesDTO course)
        {
                this.Course = course;  
        }

        public CourseDetailViewModel()
        {

        }

    }
    
}
