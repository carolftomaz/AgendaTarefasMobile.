namespace AgendaTarefasMobile.Views;

public class MainFlyoutPage : FlyoutPage
{
    public MainFlyoutPage()
    {
        var tabs = new MainTabsPage();
        Detail = new NavigationPage(tabs) { BarBackgroundColor = Color.FromArgb("#7853A6"), BarTextColor = Colors.White };
        var menu = new ContentPage { Title = "Menu", BackgroundColor = Color.FromArgb("#F8F5FC") };
        var layout = new VerticalStackLayout { Padding = new Thickness(24, 45), Spacing = 18 };
        layout.Children.Add(new Label { Text = "Minha Agenda", FontSize = 27, FontAttributes = FontAttributes.Bold });
        var tasks = new Button { Text = "Tarefas" };
        tasks.Clicked += (_, _) => { tabs.CurrentPage = tabs.Children[0]; IsPresented = false; };
        var categories = new Button { Text = "Categorias" };
        categories.Clicked += (_, _) => { tabs.CurrentPage = tabs.Children[1]; IsPresented = false; };
        var history = new Button { Text = "Histórico" };
        history.Clicked += (_, _) => { tabs.CurrentPage = tabs.Children[2]; IsPresented = false; };
        var about = new Button { Text = "Sobre", BackgroundColor = Color.FromArgb("#AC92CB") };
        about.Clicked += async (_, _) =>
        {
            IsPresented = false;
            await ((NavigationPage)Detail).PushAsync(new AboutPage());
        };
        layout.Children.Add(tasks);
        layout.Children.Add(categories);
        layout.Children.Add(history);
        layout.Children.Add(about);
        menu.Content = layout;
        Flyout = menu;
    }
}
