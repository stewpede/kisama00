using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Areas.Security.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        
       
        [Required, MinLength(3, ErrorMessage = "Min of 3 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required, MaxLength(20, ErrorMessage = "Max of 20 characters")]
        [Display(Name = "Family Name")]
        public string LastName { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNo { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}