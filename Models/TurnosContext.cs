using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TurnosConsultorioMedico.Models;

public partial class TurnosContext : DbContext
{
    // GENERADO POR ENTITY FRAMEWORK CORE SCAFFOLD
    public TurnosContext()
    {
    }

    public TurnosContext(DbContextOptions<TurnosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TDetallesTurno> TDetallesTurnos { get; set; }

    public virtual DbSet<TMedico> TMedicos { get; set; }

    public virtual DbSet<TTurno> TTurnos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TDetallesTurno>(entity =>
        {
            entity.HasKey(e => new { e.IdTurno, e.Matricula });

            entity.ToTable("T_DETALLES_TURNO");

            entity.Property(e => e.IdTurno).HasColumnName("id_turno");
            entity.Property(e => e.Matricula).HasColumnName("matricula");
            entity.Property(e => e.Fecha)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("hora");
            entity.Property(e => e.MotivoConsulta)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("motivo_consulta");

            entity.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.TDetallesTurnos)
                .HasForeignKey(d => d.IdTurno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_DETALLES_TURNO_T_TURNOS");

            entity.HasOne(d => d.MatriculaNavigation).WithMany(p => p.TDetallesTurnos)
                .HasForeignKey(d => d.Matricula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_T_DETALLES_TURNO_T_MEDICOS");
        });

        modelBuilder.Entity<TMedico>(entity =>
        {
            entity.HasKey(e => e.Matricula);

            entity.ToTable("T_MEDICOS");

            entity.Property(e => e.Matricula)
                .ValueGeneratedNever()
                .HasColumnName("matricula");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("especialidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TTurno>(entity =>
        {
            entity.ToTable("T_TURNOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Paciente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("paciente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
