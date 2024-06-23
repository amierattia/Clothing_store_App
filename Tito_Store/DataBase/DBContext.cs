using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tito_Store.models;

namespace Tito_Store.DataBase
{
    public class DBContext : DbContext
    {
        // tables
        public DbSet<InventoryItem> Inventory { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<OuterMonyModels> outerMonyModels { get; set; }
        public DbSet<OrderModels> Order { get; set; }


        // create and connect With db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(path, "Tito.db");
            optionsBuilder.UseSqlite($"FileName={filePath}");
        }
       
    }
}
