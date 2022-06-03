using System;
using System.Collections.Generic;
using System.Text;
using University.App.ViewModels;
using University.App.DTOs;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace University.App.ViewsModels.Forms
{
    public class CoursesViewModel : BaseViewModel
    {

        #region Attributes
        private ObservableCollection<CoursesDTO> _courses;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<CoursesDTO> Courses
        {
            get { return _courses; }
            set { this.SetValue(ref _courses, value); }
        }
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion

        #region Methods
        async void GetCourses()
        {
            this.IsRefreshing = true;

            var url = "https://apimocha.com/universityemu/api/Courses";

            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var courses = JsonConvert.DeserializeObject<ObservableCollection<CoursesDTO>>(result);
                    this.Courses = courses;

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Notify", "Fail", "Aceptar");
                }
            }
            this.IsRefreshing = false;
        }
        #endregion


        #region Commands
        public Command RefreshCommand { get; set; } 
        #endregion

        public CoursesViewModel()
        {
            this.RefreshCommand = new Command(GetCourses);
            this.RefreshCommand.Execute(null);
        }

    }
}
