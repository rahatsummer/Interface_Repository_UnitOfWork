using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnderstandRepo.UI.Areas.School.ViewModel
{
    public class InstructorCourseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Course Name")]
        public int CourseId { get; set; }

        [Required]
        [Display(Name = "Instructor Name")]
        public int InstructorId { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; }
    }
}