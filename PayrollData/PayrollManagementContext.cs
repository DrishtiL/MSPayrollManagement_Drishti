using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayrollModels.Models;

namespace PayrollData
{
    public class PayrollManagementContext : DbContext
    {
        public PayrollManagementContext(DbContextOptions<PayrollManagementContext> options) : base(options) { }

        public DbSet<Departments> Depatments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Departments>().HasData(
                new Departments {Id=1, dName = "HR" },
                new Departments {Id=2, dName = "Finance" },
                new Departments {Id=3, dName = "Tech" }
                );
        }
    }
}
