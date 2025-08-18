using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AutosEJ.Models;

public partial class AutosEjContext : DbContext
{
    public AutosEjContext()
    {
    }

    public AutosEjContext(DbContextOptions<AutosEjContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AutVersion> AutVersions { get; set; }

    public virtual DbSet<CatColor> CatColors { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=AutosEJ;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AutVersion>(entity =>
        {
            entity.HasKey(e => e.IdAutVersion).HasName("PK__AutVersi__2E39114E15CE5117");

            entity.ToTable("AutVersion");

            entity.HasIndex(e => e.IdAutVersion, "U_AutVersion").IsUnique();

            entity.Property(e => e.Anio)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdModeloNavigation).WithMany(p => p.AutVersions)
                .HasForeignKey(d => d.IdModelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ModeloAutVersion");
        });

        modelBuilder.Entity<CatColor>(entity =>
        {
            entity.HasKey(e => e.IdColor).HasName("PK__CatColor__E83D55CB14B2BB7F");

            entity.ToTable("CatColor");

            entity.HasIndex(e => e.IdColor, "U_CatColor").IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PK__Marca__4076A8879DE01CB0");

            entity.ToTable("Marca");

            entity.HasIndex(e => e.IdMarca, "U_Marca").IsUnique();

            entity.Property(e => e.Abreviatura)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.IdModelo).HasName("PK__Modelo__CC30D30CCAEEA72E");

            entity.ToTable("Modelo");

            entity.HasIndex(e => e.IdModelo, "U_Modelo").IsUnique();

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MarcaModelo");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("PK__Vehiculo__708612158F7319C6");

            entity.ToTable("Vehiculo");

            entity.HasIndex(e => e.IdVehiculo, "U_Vehiculo").IsUnique();

            entity.Property(e => e.Motor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Niv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NIV");
            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Serie)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAutVersionNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdAutVersion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VersionVehiculo");

            entity.HasOne(d => d.IdColorExteriorNavigation).WithMany(p => p.VehiculoIdColorExteriorNavigations)
                .HasForeignKey(d => d.IdColorExterior)
                .HasConstraintName("FK_ColorExVehiculo");

            entity.HasOne(d => d.IdColorInteriorNavigation).WithMany(p => p.VehiculoIdColorInteriorNavigations)
                .HasForeignKey(d => d.IdColorInterior)
                .HasConstraintName("FK_ColorInVehiculo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
