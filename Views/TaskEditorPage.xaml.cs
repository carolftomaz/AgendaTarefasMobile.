using AgendaTarefasMobile.Models;
using AgendaTarefasMobile.Services;
using AgendaTarefasMobile.ViewModels;

namespace AgendaTarefasMobile.Views;

public partial class TaskEditorPage : ContentPage
{
    private readonly TaskEditorViewModel vm;

    public TaskEditorPage(TaskItem? item)
    {
        InitializeComponent();
        vm = new TaskEditorViewModel(item);
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.LoadAsync();
    }

    private async void SaveClicked(object sender, EventArgs e)
    {
        var error = await vm.SaveAsync();
        if (error != null)
        {
            await DisplayAlert("Atenção", error, "OK");
            return;
        }
        Feedback.Show("Tarefa salva com sucesso");
        await Navigation.PopModalAsync();
    }

    private async void CancelClicked(object sender, EventArgs e) => await Navigation.PopModalAsync();
}
