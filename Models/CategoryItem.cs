using SQLite;

namespace AgendaTarefasMobile.Models;

public class CategoryItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [NotNull]
    public string Name { get; set; } = "";
    public string Color { get; set; } = "Lilás";
    [Ignore]
    public string Display => $"{Name} · {Color}";
}
