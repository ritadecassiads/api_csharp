namespace API.Models;
public class Usuario
{
    public int UsuarioId { get; set; }
    public string? Nome { get; set; }
    public string? Username { get; set; }
    public string? Senha { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }

    public Equipe? Equipe { get; set; }
    public int? EquipeId { get; set; }

    // public ICollection<EquipeUsuarioTarefa>? EquipeUsuarioTarefas { get; set; }
}