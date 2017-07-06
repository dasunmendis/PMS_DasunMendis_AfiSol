using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PMS_DAL
{
    public class PMSDBContext : DbContext
    {
        public PMSDBContext()
            : base("PMS_Entities")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
    }
}
                                        