using SQLite;

namespace AgendaTarefasMobile.Models;

public class ActivityItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Action { get; set; } = "";
    public string Details { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Ignore]
    public string Display => $"{CreatedAt:dd/MM HH:mm} · {Action}";
}
