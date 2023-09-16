using Microsoft.EntityFrameworkCore;
using ProductCatalog.DB.Entities;

namespace ProductCatalog.DB
{
    public class ProductCatalogDbContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }

        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.ModifiedAt)
                    .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(140);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.ModifiedAt)
                    .HasDefaultValueSql("GETDATE()");
            });
        }

    }
}
