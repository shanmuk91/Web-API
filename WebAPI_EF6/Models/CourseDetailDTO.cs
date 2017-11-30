using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_EF6.Models
{
    public class CourseDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public decimal Price { get; set; }
        public string InstructorName { get; set; }
        public string Dept { get; set; }
        public DateTime StartDate { get; set; }
    }
}