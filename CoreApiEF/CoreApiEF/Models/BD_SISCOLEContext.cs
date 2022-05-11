using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreApiEF.Models
{
    public partial class BD_SISCOLEContext : DbContext
    {
        public BD_SISCOLEContext()
        {
        }

        public BD_SISCOLEContext(DbContextOptions<BD_SISCOLEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<Colegio> Colegios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GDG7J4F\\PCRAULNERI;Database=BD_SISCOLE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno);

                entity.ToTable("ALUMNO");

                entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dni");

                entity.Property(e => e.FecCumple)
                    .HasColumnType("datetime")
                    .HasColumnName("fec_cumple");

                entity.Property(e => e.IdColegio).HasColumnName("id_colegio");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.HasOne(d => d.IdColegioNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdColegio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALUMNO_COLEGIO");
            });

            modelBuilder.Entity<Colegio>(entity =>
            {
                entity.HasKey(e => e.IdColegio);

                entity.ToTable("COLEGIO");

                entity.Property(e => e.IdColegio).HasColumnName("id_colegio");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.IdPais).HasColumnName("id_pais");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
