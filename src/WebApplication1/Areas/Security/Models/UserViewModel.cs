using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Security.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        [Required, MinLength(3, ErrorMessage = "Min of 3 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, MaxLength(20, ErrorMessage = "Max of 20 characters")]
        [Display(Name = "Family Name")]
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public string School { get; set; }
        public string YearAttended { get; set; }
        public IList<string> Education { get; set; }
        public IList<string> Schools { get; set; }
    }
}