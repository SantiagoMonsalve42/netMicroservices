using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Models.Identity;

public partial class MonsaSessionContext : DbContext
{
    public MonsaSessionContext()
    {
    }

    public MonsaSessionContext(DbContextOptions<MonsaSessionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEstadoTransaccion> TblEstadoTransaccions { get; set; }

    public virtual DbSet<TblLogAuditoria> TblLogAuditoria { get; set; }

    public virtual DbSet<TblTipoDocumento> TblTipoDocumentos { get; set; }

    public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=monsaSession;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEstadoTransaccion>(entity =>
        {
            entity.HasKey(e => e.IdEstadoTransaccion);

            entity.ToTable("TBL_ESTADO_TRANSACCION");

            entity.Property(e => e.IdEstadoTransaccion)
                .ValueGeneratedNever()
                .HasColumnName("ID_ESTADO_TRANSACCION");
            entity.Property(e => e.EstadoTransaccionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADO_TRANSACCION_ID");
        });

        modelBuilder.Entity<TblLogAuditoria>(entity =>
        {
            entity.HasKey(e => e.IdLog);
            entity.ToTable("TBL_LOG_AUDITORIA");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.FechaFinOperacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FIN_OPERACION");
            entity.Property(e => e.FechaInicioOperacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO_OPERACION");
            entity.Property(e => e.IdEstadoTransaccion).HasColumnName("ID_ESTADO_TRANSACCION");
            entity.Property(e => e.IdLog).HasColumnName("ID_LOG");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.MensajeError)
                .IsUnicode(false)
                .HasColumnName("MENSAJE_ERROR");

            entity.HasOne(d => d.IdEstadoTransaccionNavigation).WithMany()
                .HasForeignKey(d => d.IdEstadoTransaccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TBL_LOG_AUDITORIA_TBL_ESTADO_TRANSACCION");

        });

        modelBuilder.Entity<TblTipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento);

            entity.ToTable("TBL_TIPO_DOCUMENTO");

            entity.Property(e => e.IdTipoDocumento).HasColumnName("ID_TIPO_DOCUMENTO");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TIPO_DOCUMENTO");
        });

        modelBuilder.Entity<TblUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("TBL_USUARIO");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NUMERO_DOCUMENTO");
            entity.Property(e => e.Email)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("ID_TIPO_DOCUMENTO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.UltimaSesion)
                .HasColumnType("datetime")
                .HasColumnName("ULTIMA_SESION");
            entity.Property(e => e.UltimoToken)
                .IsUnicode(false)
                .HasColumnName("ULTIMO_TOKEN");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.TblUsuarios)
                .HasForeignKey(d => d.IdTipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TBL_USUARIO_TBL_TIPO_DOCUMENTO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
