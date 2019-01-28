//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace small_coaching_management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public System.DateTime ClassTime { get; set; }
        public string Class_Day { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public int CourseId { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }

        [NotMapped]
        public List<Teacher> TeacherCollection { get; set; }
        public List<Class> ClassCollection { get; set; }  
        public List<Course> CourseCollection { get; set; }


    }
}
