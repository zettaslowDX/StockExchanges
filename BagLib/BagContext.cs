using BagLib.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BagLib
{
    public partial class BagContext : DbContext
    {
        public DbSet<Country> Country { get; set; }
        public DbSet<Market> Market { get; set; }
        public DbSet<Stock> Stock { get; set; }

        public DbSet<Currency> Currency { get; set; }

        public DbSet<BagUser> BagUser { get; set; }

        public DbSet<MyStock> MyStock { get; set; }


        public BagContext(DbContextOptions<BagContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Blog;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=localhost\\SQLDEVELOPER;Database=Bag;Trusted_Connection=True;");
            }
        }
    }
}
