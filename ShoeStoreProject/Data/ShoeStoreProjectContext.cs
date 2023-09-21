using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoeStoreProject.Models;

namespace ShoeStoreProject.Data
{
    public class ShoeStoreProjectContext : DbContext
    {
        public ShoeStoreProjectContext (DbContextOptions<ShoeStoreProjectContext> options)
            : base(options)
        {
        }

        public DbSet<ShoeStoreProject.Models.Product> Product { get; set; } = default!;

        public DbSet<ShoeStoreProject.Models.Category>? Category { get; set; }

        public DbSet<ShoeStoreProject.Models.Source>? Source { get; set; }

        public DbSet<ShoeStoreProject.Models.Repo>? Repo { get; set; }

        public DbSet<ShoeStoreProject.Models.ProductRepo>? ProductRepo { get; set; }
    }
}
