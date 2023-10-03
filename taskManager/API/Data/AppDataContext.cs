using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

// contexto = classe que vai fazer toda a ponte entre a aplicação e o banco de dados
// contexto = referencia do banco de dados dentro da aplicacao
public class AppDataContext : DbContext // obrigatoriamente precisa herdar dessa classe | representa uma instancia do banco do dados
{
    // DbContextOptions<AppDataContext> = padroniza as informações que precisam ser passadas para o banco(pode ser sqlite, mysql) | contexto com opções
    public AppDataContext(DbContextOptions<AppDataContext> options) :
    base(options)
    { } // base = super() - para passar os parametros da classe filha pra classe pai
    // aqui eu digo pro entity framework saber quais serão as classes que serão tabelas no banco de dados
    public DbSet<Tarefa> Tarefas { get; set; } // metodo que cria no banco a tabela produtos
    // sempre mapear as classes modelos aqui para que o banco saiba quais serão as tabelas
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Equipe> Equipes { get; set; }

    public DbSet<EquipeUsuarioTarefa> EquipeUsuarioTarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // defino que a chave primaria da tabela EquipeUsuarioTarefa será uma chave "composta" baseada nos ids de quipe, usuario e tarefa
        modelBuilder.Entity<EquipeUsuarioTarefa>()
            .HasKey(e => new { e.EquipeId, e.UsuarioId, e.TarefaId });

        // HasMany() especifica que a entidade EquipeUsuarioTarefa terá muitas entidades associadas a ela.
        // Isso significa que uma entidade EquipeUsuarioTarefa pode estar associada a várias entidades Equipe, Usuario e Tarefa
        modelBuilder.Entity<EquipeUsuarioTarefa>()
            .HasOne(e => e.Equipe)
            .WithMany(e => e.EquipeUsuarioTarefas)
            .HasForeignKey(e => e.EquipeId);

        modelBuilder.Entity<EquipeUsuarioTarefa>()
            .HasOne(e => e.Usuario)
            .WithMany(e => e.EquipeUsuarioTarefas)
            .HasForeignKey(e => e.UsuarioId);

        modelBuilder.Entity<EquipeUsuarioTarefa>()
            .HasOne(e => e.Tarefa)
            .WithMany(e => e.EquipeUsuarioTarefas)
            .HasForeignKey(e => e.TarefaId);
    }
}