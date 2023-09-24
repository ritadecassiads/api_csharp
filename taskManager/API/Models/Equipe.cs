namespace API.Models;
public class Equipe
{

    public int EquipeId { get; set; }

    // Relacionamento um para muitos
    public ICollection<Usuario>? Usuarios { get; set; }

    // Relacionamento um para muitos
    public ICollection<Tarefa>? Tarefas { get; set; }
}