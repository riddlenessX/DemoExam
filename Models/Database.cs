using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Masterpol.Models
{
    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database")
        {
        }

        public virtual DbSet<director> director { get; set; }
        public virtual DbSet<material> material { get; set; }
        public virtual DbSet<material_type> material_type { get; set; }
        public virtual DbSet<partner> partner { get; set; }
        public virtual DbSet<partner_products> partner_products { get; set; }
        public virtual DbSet<partner_type> partner_type { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<product_type> product_type { get; set; }
        public virtual DbSet<supplier> supplier { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<director>()
                .HasMany(e => e.partner)
                .WithOptional(e => e.director)
                .HasForeignKey(e => e.director_id);

            modelBuilder.Entity<material>()
                .Property(e => e.cost)
                .HasPrecision(20, 2);

            modelBuilder.Entity<material_type>()
                .Property(e => e.reject_rate)
                .HasPrecision(3, 2);

            modelBuilder.Entity<material_type>()
                .HasMany(e => e.material)
                .WithOptional(e => e.material_type)
                .HasForeignKey(e => e.material_type_id);

            modelBuilder.Entity<partner>()
                .HasMany(e => e.partner_products)
                .WithOptional(e => e.partner)
                .HasForeignKey(e => e.partner_id);

            modelBuilder.Entity<partner_type>()
                .HasMany(e => e.partner)
                .WithOptional(e => e.partner_type)
                .HasForeignKey(e => e.partner_type_id);

            modelBuilder.Entity<product>()
                .Property(e => e.min_cost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<product>()
                .Property(e => e.width)
                .HasPrecision(10, 2);

            modelBuilder.Entity<product>()
                .Property(e => e.height)
                .HasPrecision(10, 2);

            modelBuilder.Entity<product>()
                .Property(e => e.length)
                .HasPrecision(10, 2);

            modelBuilder.Entity<product>()
                .Property(e => e.netto)
                .HasPrecision(10, 2);

            modelBuilder.Entity<product>()
                .Property(e => e.brutto)
                .HasPrecision(10, 2);

            modelBuilder.Entity<product>()
                .Property(e => e.cost_price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<product>()
                .HasMany(e => e.partner_products)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.product_article);

            modelBuilder.Entity<product_type>()
                .Property(e => e.product_type_ratio)
                .HasPrecision(3, 2);

            modelBuilder.Entity<product_type>()
                .HasMany(e => e.product)
                .WithOptional(e => e.product_type)
                .HasForeignKey(e => e.product_type_id);

            modelBuilder.Entity<supplier>()
                .HasMany(e => e.material)
                .WithOptional(e => e.supplier)
                .HasForeignKey(e => e.supplier_id);
        }
    }
}
