using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnderstandRepo.UI.Areas.School.ViewModel
{
    public class InstructorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [Display(Name = "Instructor Name")]
        public string InstructorName { get; set; }

        [Required(ErrorMessage ="Contact Information is needed")]
        [Display(Name = "Instructor Contact")]
        public string InstructorContact { get; set; }
    }
}