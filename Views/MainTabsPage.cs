namespace AgendaTarefasMobile.Views;

public class MainTabsPage : TabbedPage
{
    public MainTabsPage()
    {
        Title = "Minha Agenda";
        BarBackgroundColor = Color.FromArgb("#7853A6");
        BarTextColor = Colors.White;
        Children.Add(new TasksPage { Title = "Tarefas" });
        Children.Add(new CategoriesPage { Title = "Categorias" });
        Children.Add(new HistoryPage { Title = "Histórico" });
    }
}
