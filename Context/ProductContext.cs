using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RecipeBookVisual.ModelsProducts;


namespace RecipeBookVisual.Context;

public partial class ProductContext : DbContext
{
    public ProductContext() { }

    public ProductContext(DbContextOptions options) : base(options)
    {
    }


    public virtual DbSet<ProductArticleNrPrice> ProductArticleNrPrices { get; set; }

    public virtual DbSet<ProductInfo> ProductInfos { get; set; }

    public virtual DbSet<ProductUsage> ProductUsages { get; set; }

    public virtual DbSet<ProductsMain> ProductsMains { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\RecipeBookVisual\\Data\\Products.mdf;Integrated Security=True;");

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductArticleNrPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductA__3214EC27B6524BED");

            entity.ToTable("ProductArticleNrPrice");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.ProductArticleNumber).IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.ProductArticleNrPrices)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductAr__categ__3E52440B");
        });

        modelBuilder.Entity<ProductInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductI__3214EC2707310E7A");

            entity.ToTable("ProductInfo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MainId).HasColumnName("MainID");
            entity.Property(e => e.ProductDescription).IsUnicode(false);

            entity.HasOne(d => d.Main).WithMany(p => p.ProductInfos)
                .HasForeignKey(d => d.MainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIn__MainI__38996AB5");
        });

        modelBuilder.Entity<ProductUsage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductU__3214EC27D821420F");

            entity.ToTable("ProductUsage");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.ProductUsage1)
                .IsUnicode(false)
                .HasColumnName("ProductUsage");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductUsages)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductUs__categ__3B75D760");
        });

        modelBuilder.Entity<ProductsMain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC274B10B08A");

            entity.ToTable("ProductsMain");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stores__3214EC276F511BAD");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.FindInStoreName).IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Stores)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stores__category__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
