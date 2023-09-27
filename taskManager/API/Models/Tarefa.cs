namespace API.Models;
public class Tarefa
{
    public Tarefa()
    {
        Concluida = false;  // Inicializa Concluida como false por padrão
        CriadaEm = DateTime.Now;  // Inicializa CriadaEm com a data e hora atual
        ConcluirEm = DateTime.Now.AddDays(7);
    }

    public int TarefaId { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime CriadaEm { get; set; }
    public DateTime ConcluirEm { get; set; }

    public bool Concluida { get; set; }
}