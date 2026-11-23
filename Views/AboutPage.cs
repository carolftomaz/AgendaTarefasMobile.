namespace AgendaTarefasMobile.Views;

public class AboutPage : ContentPage
{
    public AboutPage()
    {
        Title = "Sobre o aplicativo";
        Content = new VerticalStackLayout
        {
            Padding = 24,
            Spacing = 16,
            Children =
            {
                new Image { Source = "agenda.png", HeightRequest = 90 },
                new Label { Text = "Minha Agenda", FontSize = 27, FontAttributes = FontAttributes.Bold },
                new Label { Text = "Agenda de tarefas com categorias, prioridades, pesquisa e histórico de atividades." },
                new Label { Text = "Trabalho Final – Desenvolvimento Mobile" },
                new Label { Text = "Tecnologias: .NET MAUI, C#, XAML, SQLite e MVVM." }
            }
        };
    }
}
