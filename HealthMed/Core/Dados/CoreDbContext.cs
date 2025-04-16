using Core.Entidade;
using Microsoft.EntityFrameworkCore;

namespace Core.Dados;
public class CoreDbContext : DbContext
{
    public DbSet<Paciente> Pacientes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Paciente -------------------------------------------------------------------------------
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.DataCriacao);
            entity.Property(e => e.Codigo).ValueGeneratedOnAdd();
            entity.Property(e => e.DataCriacao).IsRequired();
            entity.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Email).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Cpf).IsRequired().HasMaxLength(11);
            entity.Property(p => p.Senha).IsRequired().HasMaxLength(50);
        });

        // Médico ---------------------------------------------------------------------------------
        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.DataCriacao);
            entity.Property(e => e.Codigo).ValueGeneratedOnAdd();
            entity.Property(e => e.DataCriacao).IsRequired();
            entity.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Crm).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Senha).IsRequired().HasMaxLength(50);
        });

        // Agenda ---------------------------------------------------------------------------------
        modelBuilder.Entity<Agenda>(entity =>
        {
            entity.HasKey(e => e.DataCriacao);
            entity.Property(e => e.Codigo).ValueGeneratedOnAdd();
            entity.Property(e => e.DataCriacao).IsRequired();
            entity.Property(p => p.Data).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Hora).IsRequired().HasMaxLength(5);
        });

        // Consulta -------------------------------------------------------------------------------
        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(c => c.Codigo);

            entity.HasOne(c => c.Customer).WithMany().HasForeignKey(c => c.PacienteId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.Agenda).WithMany().HasForeignKey(c => c.AgendaId).OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.Medico).WithMany().HasForeignKey(c => c.MedicoId).OnDelete(DeleteBehavior.Restrict);
        });
    }
}
