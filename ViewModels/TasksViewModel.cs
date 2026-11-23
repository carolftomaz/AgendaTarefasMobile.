using System.Collections.ObjectModel;
using AgendaTarefasMobile.Models;
using AgendaTarefasMobile.Services;

namespace AgendaTarefasMobile.ViewModels;

public class TasksViewModel : BaseViewModel
{
    private List<TaskItem> all = new();
    public ObservableCollection<TaskItem> Tasks { get; } = new();
    private string search = "";
    private bool pendingOnly;
    private string summary = "";
    public string Search
    {
        get => search;
        set { Set(ref search, value); Filter(); }
    }
    public bool PendingOnly
    {
        get => pendingOnly;
        set { Set(ref pendingOnly, value); Filter(); }
    }
    public string Summary
    {
        get => summary;
        private set => Set(ref summary, value);
    }

    public async Task LoadAsync()
    {
        all = await AppServices.Database.GetTasksAsync();
        Filter();
    }

    private void Filter()
    {
        var query = all.Where(x => (!PendingOnly || !x.IsDone) &&
            (string.IsNullOrWhiteSpace(Search) ||
            x.Title.Contains(Search, StringComparison.OrdinalIgnoreCase) ||
            x.Description.Contains(Search, StringComparison.OrdinalIgnoreCase)));
        Tasks.Clear();
        foreach (var task in query) Tasks.Add(task);
        Summary = $"{all.Count(x => !x.IsDone)} pendentes · {all.Count(x => x.IsDone)} concluídas";
    }
}
