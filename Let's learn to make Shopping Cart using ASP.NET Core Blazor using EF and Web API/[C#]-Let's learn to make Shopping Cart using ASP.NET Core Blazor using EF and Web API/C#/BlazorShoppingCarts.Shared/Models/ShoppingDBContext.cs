using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorShoppingCarts.Shared.Models
{
    public partial class ShoppingDBContext : DbContext
    {
        public ShoppingDBContext()
        {
        }

        public ShoppingDBContext(DbContextOptions<ShoppingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItemDetails> ItemDetails { get; set; }
        public virtual DbSet<ShoppingDetails> ShoppingDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= SERVERNAME;Database=ShoppingDB;user id=SQLID;password=SQLPWD;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemDetails>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemId).HasColumnName("Item_ID");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasColumnName("Image_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("Item_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnName("Item_Price");
            });

            modelBuilder.Entity<ShoppingDetails>(entity =>
            {
                entity.HasKey(e => e.ShopId);

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId).HasColumnName("Item_ID");

                entity.Property(e => e.ShoppingDate)
                    .HasColumnName("shoppingDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
