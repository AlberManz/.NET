using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _64.EFCore.DataBaseFirst.Models
{
    public partial class EjercicioEFCore2Context : DbContext
    {
        public EjercicioEFCore2Context()
        {
        }

        public EjercicioEFCore2Context(DbContextOptions<EjercicioEFCore2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=EjercicioEFCore2;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasIndex(e => e.AutorId, "IX_Libros_AutorId");

                entity.Property(e => e.Resumen).HasMaxLength(50);

                entity.Property(e => e.Tematica)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.AutorId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
