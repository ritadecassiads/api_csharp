namespace API.Models;
public class Equipe
{

    public int EquipeId { get; set; }
    public string? Nome { get; set; }

    public ICollection<EquipeUsuarioTarefa>? EquipeUsuarioTarefas { get; set; }

    // public int? EquipeUsuarioTarefaId { get; set; }

    // public Usuario? Usuario { get; set; }
    // public int? UsuarioId { get; set; }

    // public Tarefa? Tarefa { get; set; }
    // public int? TarefaId { get; set; }
}