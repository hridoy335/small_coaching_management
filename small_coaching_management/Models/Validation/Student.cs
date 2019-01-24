using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace small_coaching_management.Models
{
    [MetadataType(typeof(MetadataStudent))] 
    public partial class Student
    {
    
    }
    public class MetadataStudent
    {
        [Required]
        [Display(Name ="Student Name")]
        public string StudentName { get; set; }
        public int ID { get; set; }
        [Required]
        [Display(Name = "Student Contact")]
        public string StudentContact { get; set; }
        [Required]
        [Display(Name = "Student Address")]
        public string StudentAddress { get; set; }
        [Required]
        [Display(Name = "Class")]
        public string studentClass { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string PamentAmount { get; set; }

    }
}