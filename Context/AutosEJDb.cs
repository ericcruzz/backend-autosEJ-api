using AutosEJ.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutosEJ.Context
{
    public class AutosEJDb : DbContext
    {
        public AutosEJDb(DbContextOptions<AutosEJDb> options): base(options) 
        {

        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<AutVersion> AutVersiones { get; set; }
        public DbSet<CatColor> Colores { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marca>()
                .HasMany(e => e.Modelos)
                .WithOne(e => e.Marca)
                .HasForeignKey(e => e.IdMarca)
                .IsRequired();

            modelBuilder.Entity<Modelo>(builder => {
                
                builder.HasOne(e => e.Marca)
                       .WithMany(e => e.Modelos)
                       .HasForeignKey(e => e.IdMarca)
                       .IsRequired();

                builder.HasMany(e => e.AutVersions)
                       .WithOne(e => e.Modelo)
                       .HasForeignKey(e => e.IdModelo)
                       .IsRequired();
            });

            modelBuilder.Entity<AutVersion>(builder => { 
                 
                builder.HasOne(e => e.Modelo)
                       .WithMany(e => e.AutVersions)
                       .HasForeignKey(e => e.IdModelo)
                       .IsRequired();


            });

            modelBuilder.Entity<CatColor>(builder => {

                builder.HasMany(e => e.Vehiculos)
                       .WithOne(e => e.ColorExterior)
                       .HasForeignKey(e => e.IdColorExterior)
                       .IsRequired();

            });


            modelBuilder.Entity<Vehiculo>();


        }
    }
}
