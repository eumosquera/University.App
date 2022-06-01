using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace University.App.DTOs
{
    public class RegisterReqDTO
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }

    }

    public class RegisterResDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public class RegisterResFailDTO
    {
        [JsonProperty("error")]
        public string Error { get; set; }

    }
}
