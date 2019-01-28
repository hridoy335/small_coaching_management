
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace small_coaching_management.Models.Validation
{
    [MetadataType(typeof(MetadataSchedule))]
    public partial class Schedule
    {
    }
    public class MetadataSchedule
    {
        public int ScheduleId { get; set; }
        [Display(Name = "Class Time")]
        public System.DateTime ClassTime { get; set; }
        [Display(Name = "Class Day")]
        public string Class_Day { get; set; }
        [Display(Name = "Teacher Name ")]
        public int TeacherId { get; set; }
        [Display(Name = "Class")]
        public int ClassId { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }


    }
}