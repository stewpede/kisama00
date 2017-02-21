using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Dal
{
    public class DatabaseContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext()
            : base("DefaultConnection")
        {

        }
    }
}
