namespace API.Models;
public class Tarefa
{
    public Tarefa() => CriadoEm = DateTime.Now;

    public int TarefaId { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime ConcluidoEm { get; set; }

    public bool Concluida { get; set; }
}