namespace API.Models;
public class Tarefa
{
    public Tarefa()
    {
        Concluida = false;  // Inicializa Concluida como false por padrão
        CriadaEm = DateTime.Now;  // Inicializa CriadaEm com a data e hora atual
        ConcluirEm = DateTime.Now.AddDays(7); // Inicializa ConcluirEm sempre 7 dias a frente da data de criação
    }

    public int TarefaId { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime CriadaEm { get; set; }
    public DateTime ConcluirEm { get; set; }

    public bool Concluida { get; set; }

    public Usuario? Usuario { get; set; }
    public int? UsuarioId { get; set; }

    public Equipe? Equipe { get; set; }
    public int? EquipeId { get; set; }
}