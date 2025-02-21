using System.Text.Json;

namespace TaskTracker;

public class TaskManager
{
    private readonly string _fileName;
    private readonly List<Task> _tasks;

    public TaskManager()
    {
        _fileName = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "data.json"));
        _tasks = LoadTasks();
    }

    public void AddTask(string description)
    {
        int id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;

        _tasks.Add(new Task { Id = id, Description = description, Status = Status.Todo, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });

        SaveTasks();

        Console.WriteLine($"Task added successfully (ID: {id})");
    }

    public void UpdateTask(int id, string description)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }
        task.Description = description;
        task.UpdatedAt = DateTime.UtcNow;
        SaveTasks();
        Console.WriteLine($"Task updated successfully (ID: {id})");
    }

    public void DeleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }
        _tasks.Remove(task);
        SaveTasks();
        Console.WriteLine($"Task deleted successfully (ID: {id}).");
    }

    public void MarkTask(int id, string status)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }
        if (status != Status.InProgress.ToString().ToLower() && status != Status.Done.ToString().ToLower())
        {
            Console.WriteLine("Invalid status. Use: inprogress, done");
            return;
        }
        task.Status = Enum.Parse<Status>(status, true);
        task.UpdatedAt = DateTime.UtcNow;
        SaveTasks();
        Console.WriteLine($"Task status successfully updated (ID: {id}).");
    }

    public void ListTasks(string filter)
    {
        IEnumerable<Task> filteredTasks = filter switch
        {
            "todo" => _tasks.Where(t => t.Status == Status.Todo),
            "inprogress" => _tasks.Where(t => t.Status == Status.InProgress),
            "done" => _tasks.Where(t => t.Status == Status.Done),
            _ => _tasks
        };

        foreach (var task in filteredTasks)
        {
            Console.WriteLine($"[{task.Id}] {task.Description} - {task.Status}");
        }
    }

    private List<Task> LoadTasks()
    {
        if (!File.Exists(_fileName)) return new List<Task>();
        return JsonSerializer.Deserialize<List<Task>>(File.ReadAllText(_fileName)) ?? new List<Task>();
    }

    private void SaveTasks()
    {
        File.WriteAllText(_fileName, JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true }));
    }
}