using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_EF6.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Credits { get; set; }
        public decimal Price { get; set; }
        public string Dept { get; set; }
        public DateTime StartDate { get; set; }

        // Foreign Key
        public int InstructorId { get; set; }
        // Navigation property
        public Instructor Instructor { get; set; }
    }
}