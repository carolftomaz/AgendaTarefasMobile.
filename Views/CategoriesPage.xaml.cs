using AgendaTarefasMobile.Services;
using AgendaTarefasMobile.ViewModels;

namespace AgendaTarefasMobile.Views;

public partial class CategoriesPage : ContentPage
{
    private readonly CategoriesViewModel vm = new();

    public CategoriesPage()
    {
        InitializeComponent();
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
        if (error != null) await DisplayAlert("Atenção", error, "OK");
        else Feedback.Show("Categoria salva");
    }

    private void ClearClicked(object sender, EventArgs e) => vm.Clear();

    private async void DeleteClicked(object sender, EventArgs e)
    {
        if (vm.Selected == null)
        {
            await DisplayAlert("Atenção", "Selecione uma categoria.", "OK");
            return;
        }
        if (!await DisplayAlert("Confirmar exclusão", "Excluir esta categoria?", "Excluir", "Cancelar")) return;
        if (!await vm.DeleteAsync())
            await DisplayAlert("Não foi possível excluir", "Existem tarefas vinculadas a esta categoria.", "OK");
        else Feedback.Show("Categoria excluída");
    }
}
