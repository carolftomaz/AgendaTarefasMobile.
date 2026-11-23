using AgendaTarefasMobile.Models;
using AgendaTarefasMobile.Services;

namespace AgendaTarefasMobile.Views;

public class TaskDetailsPage : ContentPage
{
    private readonly TaskItem task;

    public TaskDetailsPage(TaskItem selected)
    {
        task = selected;
        Title = "Detalhes da tarefa";
        var layout = new VerticalStackLayout { Padding = 22, Spacing = 16 };
        layout.Children.Add(new Label { Text = task.Title, FontSize = 27, FontAttributes = FontAttributes.Bold });
        layout.Children.Add(new Label { Text = task.Description.Length == 0 ? "Sem descrição" : task.Description });
        layout.Children.Add(new Label { Text = $"Data: {task.DateText}" });
        layout.Children.Add(new Label { Text = $"Prioridade: {task.PriorityText}" });
        layout.Children.Add(new Label { Text = $"Status: {task.StatusText}" });
        var edit = new Button { Text = "Editar" };
        edit.Clicked += async (_, _) => await Navigation.PushModalAsync(new NavigationPage(new TaskEditorPage(task)));
        var done = new Button { Text = task.IsDone ? "Marcar como pendente" : "Concluir tarefa" };
        done.Clicked += async (_, _) =>
        {
            await AppServices.Database.SetDoneAsync(task, !task.IsDone);
            Feedback.Show("Status atualizado");
            await Navigation.PopAsync();
        };
        var delete = new Button { Text = "Excluir tarefa", BackgroundColor = Color.FromArgb("#B75670") };
        delete.Clicked += async (_, _) =>
        {
            var confirm = await DisplayAlert("Confirmar exclusão", $"Excluir '{task.Title}'?", "Excluir", "Cancelar");
            if (!confirm) return;
            await AppServices.Database.DeleteTaskAsync(task);
            Feedback.Show("Tarefa excluída");
            await Navigation.PopAsync();
        };
        layout.Children.Add(edit);
        layout.Children.Add(done);
        layout.Children.Add(delete);
        Content = new ScrollView { Content = layout };
    }
}
