using AgendaTarefasMobile.Models;
using AgendaTarefasMobile.ViewModels;

namespace AgendaTarefasMobile.Views;

public partial class TasksPage : ContentPage
{
    private readonly TasksViewModel vm = new();

    public TasksPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.LoadAsync();
    }

    private async void AddClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NavigationPage(new TaskEditorPage(null)));
    }

    private async void TaskSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is not TaskItem task) return;
        ((ListView)sender).SelectedItem = null;
        await Navigation.PushAsync(new TaskDetailsPage(task));
    }
}
