using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Dal
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
       
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string ContactNo{ get; set; }
    
        public string LastName { get; set; }
     
        public int Age { get; set; }

        public string Gender { get; set; }
    }
}
