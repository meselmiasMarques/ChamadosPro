using ChamadosPro.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ChamadosPro.Infraestructure.Data;

public partial class ChamadoProDbContext : DbContext
{
    public ChamadoProDbContext()
    {
    }

    public ChamadoProDbContext(DbContextOptions<ChamadoProDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chamados> Chamados { get; set; }

    public virtual DbSet<HistoricoChamado> HistoricoChamado { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Use o nome definido no appsettings.json
            optionsBuilder.UseSqlServer("Name=DefaultConnection");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chamados>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chamados__3214EC07573BC99E");

            entity.Property(e => e.DataAbertura).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Cliente).WithMany(p => p.ChamadosCliente)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chamado_Cliente");

            entity.HasOne(d => d.Tecnico).WithMany(p => p.ChamadosTecnico)
                .HasForeignKey(d => d.TecnicoId)
                .HasConstraintName("FK_Chamado_Tecnico");
        });

        modelBuilder.Entity<HistoricoChamado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historic__3214EC07975EC724");

            entity.Property(e => e.DataAlteracao).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.Chamado).WithMany(p => p.HistoricoChamado)
                .HasForeignKey(d => d.ChamadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historico_Chamado");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC076FDC4DC0");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D1053418F4553C").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Perfil).HasMaxLength(20);
            entity.Property(e => e.SenhaHash).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
