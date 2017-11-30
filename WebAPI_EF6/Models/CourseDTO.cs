using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_EF6.Models
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string InstructorName { get; set; }
    }
}