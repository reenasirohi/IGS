using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IGSService.Models;

namespace IGSService.Data
{
    public class IGSServiceContext : DbContext
    {
        public IGSServiceContext (DbContextOptions<IGSServiceContext> options)
            : base(options)
        {

        }

        public DbSet<IGSService.Models.Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products { ProductCode = 001,Name = "Lavender heart",Price = 9.25}, 
                new Products { ProductCode = 002,Name = "Personalised cufflinks",Price = 45.00},
                new Products { ProductCode = 003,Name = "Kids T-shirt",Price = 19.95}
            );
           
        }
    }
}
