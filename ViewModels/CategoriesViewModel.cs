using System.Collections.ObjectModel;
using AgendaTarefasMobile.Models;
using AgendaTarefasMobile.Services;

namespace AgendaTarefasMobile.ViewModels;

public class CategoriesViewModel : BaseViewModel
{
    public ObservableCollection<CategoryItem> Categories { get; } = new();
    private string name = "";
    private string color = "Lilás";
    private CategoryItem? selected;
    public string Name { get => name; set => Set(ref name, value); }
    public string Color { get => color; set => Set(ref color, value); }
    public CategoryItem? Selected
    {
        get => selected;
        set
        {
            Set(ref selected, value);
            if (value != null) { Name = value.Name; Color = value.Color; }
        }
    }
    public async Task LoadAsync()
    {
        Categories.Clear();
        foreach (var item in await AppServices.Database.GetCategoriesAsync()) Categories.Add(item);
    }
    public async Task<string?> SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(Name)) return "Digite o nome da categoria.";
        if (Categories.Any(x => x.Id != (Selected?.Id ?? 0) && x.Name.Equals(Name.Trim(), StringComparison.OrdinalIgnoreCase)))
            return "Essa categoria já existe.";
        await AppServices.Database.SaveCategoryAsync(new CategoryItem
        {
            Id = Selected?.Id ?? 0,
            Name = Name.Trim(),
            Color = Color
        });
        Clear();
        await LoadAsync();
        return null;
    }
    public async Task<bool> DeleteAsync()
    {
        if (Selected == null) return false;
        var deleted = await AppServices.Database.DeleteCategoryAsync(Selected);
        if (deleted) { Clear(); await LoadAsync(); }
        return deleted;
    }
    public void Clear()
    {
        Selected = null;
        Name = "";
        Color = "Lilás";
    }
}
