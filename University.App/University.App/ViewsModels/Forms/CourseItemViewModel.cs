using System;
using System.Collections.Generic;
using System.Text;
using University.App.DTOs;
using Xamarin.Forms;

namespace University.App.ViewsModels.Forms
{
    public class CourseItemViewModel : CoursesDTO
    {
        async void OnItemClick()
        {

            await Application.Current.MainPage.DisplayAlert("Notify ", $"selectd {this.Title} ", "Ok");

        }

        public Command OnItemClickCommand { get; set; }

        public CourseItemViewModel()
        {
            this.OnItemClickCommand = new Command(OnItemClick);
        }
    }
    
}
