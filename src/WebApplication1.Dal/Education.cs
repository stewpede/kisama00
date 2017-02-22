using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WebApplication1.Dal
{
     [Table("Education")]
   public class Education
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string School { get; set; }
        public string YearAttended { get; set; }

        //reference to User
        public User User { get; set; }
    }
}
