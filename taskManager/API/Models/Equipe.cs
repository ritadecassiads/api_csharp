namespace API.Models;
public class Equipe
{

    public int EquipeId { get; set; }

    // Relacionamento um para muitos
    public List<Usuario>? Usuarios { get; set; }

    // Relacionamento um para muitos
    public List<Tarefa>? Tarefas { get; set; }
}