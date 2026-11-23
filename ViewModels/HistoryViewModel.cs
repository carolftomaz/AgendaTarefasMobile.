using System.Collections.ObjectModel;
using AgendaTarefasMobile.Models;
using AgendaTarefasMobile.Services;

namespace AgendaTarefasMobile.ViewModels;

public class HistoryViewModel
{
    public ObservableCollection<ActivityItem> Activities { get; } = new();

    public async Task LoadAsync()
    {
        Activities.Clear();
        foreach (var item in await AppServices.Database.GetActivitiesAsync()) Activities.Add(item);
    }
}
