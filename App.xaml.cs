using AgendaTarefasMobile.Views;

namespace AgendaTarefasMobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new MainFlyoutPage());
    }
}
