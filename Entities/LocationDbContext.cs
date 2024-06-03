using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_Pro.Entities;

public partial class LocationDbContext : DbContext
{
    public LocationDbContext()
    {
    }

    public LocationDbContext(DbContextOptions<LocationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Huyen> Huyens { get; set; }

    public virtual DbSet<Tinh> Tinhs { get; set; }

    public virtual DbSet<Xa> Xas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ZERO_ONE;Database=LocationDB;User Id=sa; Password=77882664; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Huyen>(entity =>
        {
            entity.HasKey(e => e.MaH).HasName("PK__Huyen__C7977BB088794589");

            entity.ToTable("Huyen");

            entity.Property(e => e.MaH).ValueGeneratedNever();
            entity.Property(e => e.Cap).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(255);

            entity.HasOne(d => d.MaTNavigation).WithMany(p => p.Huyens)
                .HasForeignKey(d => d.MaT)
                .HasConstraintName("FK__Huyen__MaT__398D8EEE");
        });

        modelBuilder.Entity<Tinh>(entity =>
        {
            entity.HasKey(e => e.MaT).HasName("PK__Tinh__C7977BA401551E39");

            entity.ToTable("Tinh");

            entity.Property(e => e.MaT).ValueGeneratedNever();
            entity.Property(e => e.Cap).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(255);
        });

        modelBuilder.Entity<Xa>(entity =>
        {
            entity.HasKey(e => e.MaX).HasName("PK__Xa__C7977BA0510DE5D5");

            entity.ToTable("Xa");

            entity.Property(e => e.MaX).ValueGeneratedNever();
            entity.Property(e => e.Cap).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(255);

            entity.HasOne(d => d.MaHNavigation).WithMany(p => p.Xas)
                .HasForeignKey(d => d.MaH)
                .HasConstraintName("FK__Xa__MaH__3C69FB99");

            entity.HasOne(d => d.MaTNavigation).WithMany(p => p.Xas)
                .HasForeignKey(d => d.MaT)
                .HasConstraintName("FK__Xa__MaT__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
