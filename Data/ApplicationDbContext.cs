using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationTracker.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Application> Applications { get; set; }
        
    }
}