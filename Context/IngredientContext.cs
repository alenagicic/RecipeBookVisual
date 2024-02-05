using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RecipeBookVisual.ModelsRecipe;

namespace RecipeBookVisual.Context;

public partial class IngredientContext : DbContext
{
    public IngredientContext()
    {
    }

    public IngredientContext(DbContextOptions<IngredientContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlternativeIngredient> AlternativeIngredients { get; set; }

    public virtual DbSet<FunFactRecipe> FunFactRecipes { get; set; }

    public virtual DbSet<MainRecipe> MainRecipes { get; set; }

    public virtual DbSet<PairingsRecipe> PairingsRecipes { get; set; }

    public virtual DbSet<RecipeStory> RecipeStories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\RecipeBookVisual\\Data\\Ingredients.mdf;Integrated Security=True");

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlternativeIngredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alternat__3214EC073D7ED85A");

            entity.Property(e => e.Idmain).HasColumnName("IDMain");

            entity.HasOne(d => d.IdmainNavigation).WithMany(p => p.AlternativeIngredients)
                .HasForeignKey(d => d.Idmain)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdMainRe");
        });

        modelBuilder.Entity<FunFactRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FunFactR__3214EC070D5D71F0");

            entity.ToTable("FunFactRecipe");

            entity.Property(e => e.Idmain).HasColumnName("IDMain");

            entity.HasOne(d => d.IdmainNavigation).WithMany(p => p.FunFactRecipes)
                .HasForeignKey(d => d.Idmain)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdMainReci");
        });

        modelBuilder.Entity<MainRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MainReci__3214EC0759F5756A");

            entity.ToTable("MainRecipe");
        });

        modelBuilder.Entity<PairingsRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pairings__3214EC078EA9A389");

            entity.ToTable("PairingsRecipe");

            entity.Property(e => e.Idmain).HasColumnName("IDMain");

            entity.HasOne(d => d.IdmainNavigation).WithMany(p => p.PairingsRecipes)
                .HasForeignKey(d => d.Idmain)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdMainRecip");
        });

        modelBuilder.Entity<RecipeStory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07EAA1027B");

            entity.ToTable("RecipeStory");

            entity.Property(e => e.Idmain).HasColumnName("IDMain");

            entity.HasOne(d => d.IdmainNavigation).WithMany(p => p.RecipeStories)
                .HasForeignKey(d => d.Idmain)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdMainRecipe");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
