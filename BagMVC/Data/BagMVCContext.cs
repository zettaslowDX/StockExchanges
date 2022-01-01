using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BagLib.Models;

namespace BagMVC.Data
{
    public class BagMVCContext : DbContext
    {
        public BagMVCContext (DbContextOptions<BagMVCContext> options)
            : base(options)
        {
        }

        public DbSet<BagLib.Models.Country> Country { get; set; }
    }
}
