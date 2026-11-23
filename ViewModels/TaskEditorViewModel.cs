using AgendaTarefasMobile.Models;
using AgendaTarefasMobile.Services;

namespace AgendaTarefasMobile.ViewModels;

public class TaskEditorViewModel : BaseViewModel
{
    private readonly int id;
    private string title;
    private string description;
    private DateTime date;
    private int priority;
    private bool isDone;
    private CategoryItem? category;

    public List<CategoryItem> Categories { get; private set; } = new();
    public string Title { get => title; set => Set(ref title, value); }
    public string Description { get => description; set => Set(ref description, value); }
    public DateTime DueDate { get => date; set => Set(ref date, value); }
    public bool IsDone { get => isDone; set => Set(ref isDone, value); }
    public CategoryItem? SelectedCategory { get => category; set => Set(ref category, value); }
    public bool IsLow { get => priority == 0; set { if (value) SetPriority(0); } }
    public bool IsMedium { get => priority == 1; set { if (value) SetPriority(1); } }
    public bool IsHigh { get => priority == 2; set { if (value) SetPriority(2); } }
    public string Header => id == 0 ? "Nova tarefa" : "Editar tarefa";

    public TaskEditorViewModel(TaskItem? item)
    {
        id = item?.Id ?? 0;
        title = item?.Title ?? "";
        description = item?.Description ?? "";
        date = item?.DueDate ?? DateTime.Today;
        priority = item?.Priority ?? 1;
        isDone = item?.IsDone ?? false;
        category = item == null ? null : new CategoryItem { Id = item.CategoryId };
    }

    private void SetPriority(int value)
    {
        priority = value;
        Notify(nameof(IsLow));
        Notify(nameof(IsMedium));
        Notify(nameof(IsHigh));
    }

    public async Task LoadAsync()
    {
        var selectedId = category?.Id ?? 0;
        Categories = await AppServices.Database.GetCategoriesAsync();
        Notify(nameof(Categories));
        SelectedCategory = Categories.FirstOrDefault(x => x.Id == selectedId) ?? Categories.FirstOrDefault();
    }

    public async Task<string?> SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(Title)) return "Informe o título da tarefa.";
        if (SelectedCategory == null) return "Selecione uma categoria.";
        await AppServices.Database.SaveTaskAsync(new TaskItem
        {
            Id = id,
            Title = Title.Trim(),
            Description = Description?.Trim() ?? "",
            DueDate = DueDate,
            Priority = priority,
            CategoryId = SelectedCategory.Id,
            IsDone = IsDone
        });
        return null;
    }
}
