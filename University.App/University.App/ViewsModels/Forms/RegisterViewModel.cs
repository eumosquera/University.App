using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using University.App.DTOs;
using University.App.ViewModels;
using University.App.Views.Forms;
using Xamarin.Forms;

namespace University.App.ViewsModels.Forms
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Attributes
        private string _email;
        private string _password;
        #endregion

        #region Properties
        public String Email
        {
            get { return _email; }
            set { this.SetValue(ref _email, value); }
        }

        public string Password
        {
            get { return _password; }
            set { this.SetValue(ref _password, value); }
        }
        #endregion

        #region Methods

        async void Register()
        {

            
            var data = new RegisterReqDTO
            {
                Email = this.Email,
                Password = this.Password
            };
            var json = JsonConvert.SerializeObject(data);

            var req = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://reqres.in/api/register";

            var result = string.Empty;

            using (var client = new HttpClient())
            {

                var response = await client.PostAsync(url, req);
                var statusCode = response.StatusCode;
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    //TODO: Logic App
                    var registerRes = JsonConvert.DeserializeObject<RegisterResDTO>(result);
                    var id = registerRes.Id;
                    var token = registerRes.Token;
                    await Application.Current.MainPage.DisplayAlert("Notify", ${token + id}, "Aceptar");

                    //Redirect
                    await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    var loginResFail = JsonConvert.DeserializeObject<RegisterResFailDTO>(result);
                    var error = loginResFail.Error;
                    await Application.Current.MainPage.DisplayAlert("Notify", error, "Aceptar");
                }


            }


        }

        async void Login()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());

        }
        #endregion

        #region Commands
        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        #endregion
        public RegisterViewModel()
        {
            this.RegisterCommand = new Command(Register);
            this.LoginCommand = new Command(Login);

        }

    }
}
