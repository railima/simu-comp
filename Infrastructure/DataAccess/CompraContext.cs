using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class CompraContext: DbContext
    {
        public CompraContext(DbContextOptions options) : base(options) { }

        public DbSet<Compra> Compras { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>().ToTable("Compra");
        }
    }
}
