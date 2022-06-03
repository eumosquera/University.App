using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace University.App.DTOs
{
    public class CoursesDTO
    {
        //[JsonProperty("CourseID")]
        public int CourseID { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

    }
}
