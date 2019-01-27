using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace small_coaching_management.Models
{
    [MetadataType(typeof(metadataTeacher))]
    public partial class Teacher
    {
    }
    public class metadataTeacher
    {
        [Required]
        [Display(Name = " Teacher Name ")]
        public string TeacherName { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}