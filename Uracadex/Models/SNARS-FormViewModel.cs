using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Uracadex.Models
{
    public class SNARS_FormViewModel
    {
        public SNARS_FormViewModel()
        {
            UniversityDropDown = new List<SelectListItem>();
        }

        public int SNARSId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Name of University")]
        public int UniversityId { get; set; }

        [Required]
        [Display(Name = "Course Of Study")]
        public string CourseOfStudy { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        public string Request { get; set; }

        [Required]
        public string ResearchInterest { get; set; }

        public IList<SelectListItem> UniversityDropDown { get; set; }
    }
}