using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wandermateBackend.Models;

namespace wandermateBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base (dbContextOptions) 
        {

        }
        public DbSet <Hotel> Hotel {get; set;}
        public DbSet <Travel> Travel { get; set; }
        public DbSet <User> User { get; set; }
    }
}