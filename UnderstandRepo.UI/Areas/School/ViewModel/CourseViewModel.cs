﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnderstandRepo.UI.Areas.School.ViewModel
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Course Name")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }
    }
}