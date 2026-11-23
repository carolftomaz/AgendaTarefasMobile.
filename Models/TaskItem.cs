using SQLite;

namespace AgendaTarefasMobile.Models;

public class TaskItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime DueDate { get; set; } = DateTime.Today;
    public int Priority { get; set; } = 1;
    public bool IsDone { get; set; }
    public int CategoryId { get; set; }
    [Ignore]
    public string PriorityText => Priority switch { 0 => "Baixa", 2 => "Alta", _ => "Média" };
    [Ignore]
    public string StatusText => IsDone ? "Concluída" : "Pendente";
    [Ignore]
    public string DateText => DueDate.ToString("dd/MM/yyyy");
}
