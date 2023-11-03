using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) :
    base(options)
    { }
    public DbSet<Tarefa> Tarefas { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Equipe> Equipes { get; set; }

    // public DbSet<EquipeUsuarioTarefa> EquipeUsuarioTarefa { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     // defino que a chave primaria da tabela EquipeUsuarioTarefa será uma chave "composta" baseada nos ids de quipe, usuario e tarefa
    //     modelBuilder.Entity<EquipeUsuarioTarefa>()
    //         .HasKey(e => new { e.EquipeId, e.UsuarioId, e.TarefaId });

    //     // HasMany() especifica que a entidade EquipeUsuarioTarefa terá muitas entidades associadas a ela.
    //     // Isso significa que uma entidade EquipeUsuarioTarefa pode estar associada a várias entidades Equipe, Usuario e Tarefa
    //     modelBuilder.Entity<EquipeUsuarioTarefa>()
    //         .HasOne(e => e.Equipe)
    //         .WithMany(e => e.EquipeUsuarioTarefas)
    //         .HasForeignKey(e => e.EquipeId);

    //     modelBuilder.Entity<EquipeUsuarioTarefa>()
    //         .HasOne(e => e.Usuario)
    //         .WithMany(e => e.EquipeUsuarioTarefas)
    //         .HasForeignKey(e => e.UsuarioId);

    //     modelBuilder.Entity<EquipeUsuarioTarefa>()
    //         .HasOne(e => e.Tarefa)
    //         .WithMany(e => e.EquipeUsuarioTarefas)
    //         .HasForeignKey(e => e.TarefaId);
    // }
}