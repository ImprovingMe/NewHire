using Microsoft.EntityFrameworkCore;
using NewHire.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewHire.Data
{
    public class NewHireDbContext : DbContext
    {

        public NewHireDbContext(DbContextOptions<NewHireDbContext> options) : base(options)
        {
            
        }
        public DbSet<Job> Jobs { get; set; }
    }
}
