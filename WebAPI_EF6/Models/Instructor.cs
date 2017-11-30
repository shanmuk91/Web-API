using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_EF6.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}