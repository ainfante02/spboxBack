using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



using appspbox.Models;
namespace appspbox.context
{
    public class productDbContext:DbContext
    {


        public productDbContext(DbContextOptions<productDbContext> options)
    : base(options)
        {
        }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
