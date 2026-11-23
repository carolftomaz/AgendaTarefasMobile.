using AgendaTarefasMobile.Data;

namespace AgendaTarefasMobile.Services;

public static class AppServices
{
    public static AgendaDatabase Database { get; } = new();
}
