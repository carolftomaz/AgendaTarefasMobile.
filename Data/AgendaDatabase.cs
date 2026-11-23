using AgendaTarefasMobile.Models;
using SQLite;

namespace AgendaTarefasMobile.Data;

public class AgendaDatabase
{
    private readonly SQLiteAsyncConnection connection;
    private readonly SemaphoreSlim gate = new(1, 1);
    private bool ready;

    public AgendaDatabase()
    {
        var path = Path.Combine(FileSystem.AppDataDirectory, "agenda.db3");
        connection = new SQLiteAsyncConnection(path);
    }

    public async Task InitializeAsync()
    {
        if (ready) return;
        await gate.WaitAsync();
        try
        {
            if (ready) return;
            await connection.CreateTableAsync<TaskItem>();
            await connection.CreateTableAsync<CategoryItem>();
            await connection.CreateTableAsync<ActivityItem>();
            if (await connection.Table<CategoryItem>().CountAsync() == 0)
            {
                await connection.InsertAllAsync(new[]
                {
                    new CategoryItem { Name = "Faculdade", Color = "Lilás" },
                    new CategoryItem { Name = "Trabalho", Color = "Azul" },
                    new CategoryItem { Name = "Pessoal", Color = "Rosa" }
                });
            }
            ready = true;
        }
        finally
        {
            gate.Release();
        }
    }

    public async Task<List<TaskItem>> GetTasksAsync()
    {
        await InitializeAsync();
        return await connection.Table<TaskItem>().OrderBy(x => x.DueDate).ToListAsync();
    }

    public async Task SaveTaskAsync(TaskItem item)
    {
        await InitializeAsync();
        var action = item.Id == 0 ? "Tarefa cadastrada" : "Tarefa editada";
        if (item.Id == 0) await connection.InsertAsync(item);
        else await connection.UpdateAsync(item);
        await LogAsync(action, item.Title);
    }

    public async Task DeleteTaskAsync(TaskItem item)
    {
        await InitializeAsync();
        await connection.DeleteAsync(item);
        await LogAsync("Tarefa excluída", item.Title);
    }

    public async Task SetDoneAsync(TaskItem item, bool done)
    {
        await InitializeAsync();
        item.IsDone = done;
        await connection.UpdateAsync(item);
        await LogAsync(done ? "Tarefa concluída" : "Tarefa reaberta", item.Title);
    }

    public async Task<List<CategoryItem>> GetCategoriesAsync()
    {
        await InitializeAsync();
        return await connection.Table<CategoryItem>().OrderBy(x => x.Name).ToListAsync();
    }

    public async Task SaveCategoryAsync(CategoryItem item)
    {
        await InitializeAsync();
        var action = item.Id == 0 ? "Categoria cadastrada" : "Categoria editada";
        if (item.Id == 0) await connection.InsertAsync(item);
        else await connection.UpdateAsync(item);
        await LogAsync(action, item.Name);
    }

    public async Task<bool> DeleteCategoryAsync(CategoryItem item)
    {
        await InitializeAsync();
        if (await connection.Table<TaskItem>().Where(t => t.CategoryId == item.Id).CountAsync() > 0)
            return false;
        await connection.DeleteAsync(item);
        await LogAsync("Categoria excluída", item.Name);
        return true;
    }

    public async Task<List<ActivityItem>> GetActivitiesAsync()
    {
        await InitializeAsync();
        return await connection.Table<ActivityItem>().OrderByDescending(x => x.CreatedAt).Take(100).ToListAsync();
    }

    private Task LogAsync(string action, string details) =>
        connection.InsertAsync(new ActivityItem { Action = action, Details = details });
}
