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
        
        [Required]
        [MinLength(3, ErrorMessage = "At least 3 characters")]
        [MaxLength(20, ErrorMessage = "At most 20 characters")]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
       
        [Required]
        public int Age { get; set; }
       
        [Required]
        public string Gender { get; set; }
    }
}