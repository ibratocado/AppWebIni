using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AppWebIni.Models.DBWeb
{
    public partial class webContext : DbContext
    {
        public webContext()
        {
        }

        public webContext(DbContextOptions<webContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Tiket> Tikets { get; set; }
        public virtual DbSet<Ventum> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MIPC;Database=web;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.PrecioPub).HasColumnName("precioPub");
            });

            modelBuilder.Entity<Tiket>(entity =>
            {
                entity.ToTable("tiket");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cliente).HasColumnName("cliente");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Tikets)
                    .HasForeignKey(d => d.Cliente)
                    .HasConstraintName("FK_tiket_cliente");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.ToTable("venta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Producto).HasColumnName("producto");

                entity.Property(e => e.Tiket).HasColumnName("tiket");

                entity.Property(e => e.Total)
                    .HasMaxLength(10)
                    .HasColumnName("total")
                    .IsFixedLength(true);

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Producto)
                    .HasConstraintName("FK_venta_productos");

                entity.HasOne(d => d.TiketNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Tiket)
                    .HasConstraintName("FK_venta_tiket");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
