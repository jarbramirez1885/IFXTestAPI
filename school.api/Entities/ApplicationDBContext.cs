using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school.api.Entities
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<House> Houses { get; set; }

        public ApplicationDBContext()
        {

        }

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
