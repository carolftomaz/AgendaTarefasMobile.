using AgendaTarefasMobile.ViewModels;

namespace AgendaTarefasMobile.Views;

public partial class HistoryPage : ContentPage
{
    private readonly HistoryViewModel vm = new();

    public HistoryPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.LoadAsync();
    }
}
