using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bursa.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Paper> Papers { get; set; }
        public DbSet<BursaType> BursaTypeList { get; set; }
        public DbSet<PaperType> PaperTypeList { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();  
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bursadb;Trusted_Connection=True;");
        //}
    }
}
