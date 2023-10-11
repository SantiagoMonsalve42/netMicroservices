using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Models.Inventory;

public partial class MonsaInventoryContext : DbContext
{
    public MonsaInventoryContext()
    {
    }

    public MonsaInventoryContext(DbContextOptions<MonsaInventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCategoriaProducto> TblCategoriaProductos { get; set; }

    public virtual DbSet<TblProducto> TblProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=monsaInventory;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaProducto).HasName("PK_CATEGORIA_PRODUCTO");

            entity.ToTable("TBL_CATEGORIA_PRODUCTO");

            entity.Property(e => e.IdCategoriaProducto).HasColumnName("ID_CATEGORIA_PRODUCTO");
            entity.Property(e => e.CategoriaProductoDesc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CATEGORIA_PRODUCTO_DESC");
        });

        modelBuilder.Entity<TblProducto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.ToTable("TBL_PRODUCTO");

            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdCategoriaProducto).HasColumnName("ID_CATEGORIA_PRODUCTO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdCategoriaProductoNavigation).WithMany(p => p.TblProductos)
                .HasForeignKey(d => d.IdCategoriaProducto)
                .HasConstraintName("FK_TBL_PRODUCTO_CATEGORIA_PRODUCTO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
