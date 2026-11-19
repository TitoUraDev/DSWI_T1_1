using System;
using System.Collections.Generic;
using DSWI_T1_01.Models;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_01.Data;

public partial class ClinicaBdContext : DbContext
{
    public ClinicaBdContext()
    {
    }

    public ClinicaBdContext(DbContextOptions<ClinicaBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.Property(e => e.CitaId).HasColumnName("CitaID");
            entity.Property(e => e.Especialidad).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.PacienteId).HasColumnName("PacienteID");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Citas)
                .HasForeignKey(d => d.PacienteId);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.Property(e => e.PacienteId).HasColumnName("PacienteID");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("DNI");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
