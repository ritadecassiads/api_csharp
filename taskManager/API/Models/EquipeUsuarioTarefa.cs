namespace API.Models;
public class EquipeUsuarioTarefa
{

    // classe que armazenará o relacionamento muitos para muitos entre as entidades
    public Equipe? Equipe { get; set; }
    public int? EquipeId { get; set; }

    public Usuario? Usuario { get; set; }
    public int? UsuarioId { get; set; }

    public Tarefa? Tarefa { get; set; }
    public int? TarefaId { get; set; }
}