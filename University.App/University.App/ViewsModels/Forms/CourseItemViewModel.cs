using System;
using System.Collections.Generic;
using System.Text;
using University.App.DTOs;
using Xamarin.Forms;
using University.App.Views.Forms;

namespace University.App.ViewsModels.Forms
{
    public class CourseItemViewModel : CoursesDTO
    {
        async void OnItemClick()
        {

            await Application.Current.MainPage.DisplayAlert("Notify ", $"selectd {this.Title} ", "Ok");

            CourseDetailPage detailPage = new CourseDetailPage();
            detailPage.BindingContext = new CourseDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }

        public Command OnItemClickCommand { get; set; }

        public CourseItemViewModel()
        {
            this.OnItemClickCommand = new Command(OnItemClick);
        }
    }
    
}
