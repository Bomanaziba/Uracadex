using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Uracadex.DatabaseModel
{
    public class SNARS
    {
        [Key]
        public int SNARSId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int UniversityId { get; set; }

        [Required]
        public string CourseOfStudy { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string Request { get; set; }

        [Required]
        public string ResearchInterest { get; set; }
    }
}
