using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestionHorarios.Modelos.Entidades;

namespace GestionHorarios.Datos.Context
{
    /// <summary>
    /// DbContext principal de la aplicación
    /// Gestiona todas las entidades y configuraciones de la base de datos
    /// </summary>
    public class GestionHorariosContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
    {
        public GestionHorariosContext(DbContextOptions<GestionHorariosContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<TipoTurno> TiposTurno { get; set; }
        public DbSet<MotivoLlamada> MotivosLlamada { get; set; }
        public DbSet<HorarioLlamada> HorariosLlamada { get; set; }
        public DbSet<RegistroLlamada> RegistrosLlamada { get; set; }
        public DbSet<IntercambioTurno> IntercambiosTurno { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Especialidad
            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.HasMany(e => e.Medicos)
                    .WithOne(m => m.Especialidad)
                    .HasForeignKey(m => m.IdEspecialidad);
            });

            // Configuración de Médico
            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Cedula).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Nombres).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellidos).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.Property(e => e.RegistroMedico).HasMaxLength(50);
                entity.HasIndex(e => e.Cedula).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasOne(m => m.Especialidad)
                    .WithMany(e => e.Medicos)
                    .HasForeignKey(m => m.IdEspecialidad);
                entity.HasOne(m => m.Usuario)
                    .WithOne(u => u.Medico)
                    .HasForeignKey<Usuario>(u => u.IdMedico);
            });

            // Configuración de TipoTurno
            modelBuilder.Entity<TipoTurno>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.HasMany(e => e.HorariosLlamada)
                    .WithOne(h => h.TipoTurno)
                    .HasForeignKey(h => h.IdTipoTurno);
            });

            // Configuración de MotivoLlamada
            modelBuilder.Entity<MotivoLlamada>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Categoria).IsRequired().HasMaxLength(50);
                entity.HasMany(e => e.RegistrosLlamada)
                    .WithOne(r => r.Motivo)
                    .HasForeignKey(r => r.IdMotivo);
            });

            // Configuración de HorarioLlamada
            modelBuilder.Entity<HorarioLlamada>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Observaciones).HasMaxLength(500);
                entity.HasOne(h => h.Medico)
                    .WithMany(m => m.HorariosLlamada)
                    .HasForeignKey(h => h.IdMedico);
                entity.HasOne(h => h.TipoTurno)
                    .WithMany(t => t.HorariosLlamada)
                    .HasForeignKey(h => h.IdTipoTurno);
                entity.HasOne(h => h.UsuarioCreador)
                    .WithMany(u => u.HorariosCreados)
                    .HasForeignKey(h => h.CreadoPor)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(h => h.RegistrosLlamada)
                    .WithOne(r => r.Horario)
                    .HasForeignKey(r => r.IdHorario)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(h => h.IntercambiosTurno)
                    .WithOne(i => i.HorarioOriginal)
                    .HasForeignKey(i => i.IdHorarioOriginal);
                entity.HasIndex(h => new { h.IdMedico, h.Fecha, h.IdTipoTurno }).IsUnique();
            });

            // Configuración de RegistroLlamada
            modelBuilder.Entity<RegistroLlamada>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Observaciones).HasMaxLength(500);
                entity.HasOne(r => r.Horario)
                    .WithMany(h => h.RegistrosLlamada)
                    .HasForeignKey(r => r.IdHorario);
                entity.HasOne(r => r.Motivo)
                    .WithMany(m => m.RegistrosLlamada)
                    .HasForeignKey(r => r.IdMotivo);
                entity.HasOne(r => r.UsuarioRegistrador)
                    .WithMany(u => u.RegistrosCreadosPor)
                    .HasForeignKey(r => r.RegistradoPor)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de IntercambioTurno
            modelBuilder.Entity<IntercambioTurno>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Motivo).HasMaxLength(500);
                entity.HasOne(i => i.HorarioOriginal)
                    .WithMany(h => h.IntercambiosTurno)
                    .HasForeignKey(i => i.IdHorarioOriginal);
                entity.HasOne(i => i.MedicoReemplaza)
                    .WithMany(m => m.IntercambiosTurnoRealizado)
                    .HasForeignKey(i => i.IdMedicoReemplaza);
                entity.HasOne(i => i.UsuarioAprobador)
                    .WithMany(u => u.IntercambiosAprobados)
                    .HasForeignKey(i => i.AprobadoPor)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de Usuario (Identity)
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasOne(u => u.Medico)
                    .WithOne(m => m.Usuario)
                    .HasForeignKey<Usuario>(u => u.IdMedico);
            });
        }
    }
}