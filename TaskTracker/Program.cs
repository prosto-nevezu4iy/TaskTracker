using TaskTracker;

Console.WriteLine("Usage: add <task>, update <id> <task>, delete <id>, mark <id> <status>, list <filter>");
Console.WriteLine();

Console.WriteLine("# Adding a new task");
Console.WriteLine("add Clean Room");
Console.WriteLine("# Output: Task added successfully (ID: 1)");
Console.WriteLine();

Console.WriteLine("# Updating and deleting tasks");
Console.WriteLine("update 1 Clean Room");
Console.WriteLine("delete 1");
Console.WriteLine();

Console.WriteLine("# Marking a task as in-progress or done");
Console.WriteLine("mark 1 in-progress");
Console.WriteLine("mark 1 done");
Console.WriteLine();

Console.WriteLine("# Listing all tasks");
Console.WriteLine("list");
Console.WriteLine();

Console.WriteLine("# Listing tasks by status");
Console.WriteLine("list todo");
Console.WriteLine("list in-progress");
Console.WriteLine("list done");
Console.WriteLine();

TaskManager taskManager = new TaskManager();

while (true)
{
    string input = Console.ReadLine();

    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Invalid input. Try again.");
        continue;
    }

    args = input.Split(' ');
    string command = args[0].ToLower();

    switch (command)
    {
        case "add":
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: add <task>");
                break;
            }
            taskManager.AddTask(string.Join(" ", args.Skip(1)));
            break;
        case "update":
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: update <id> <task>");
                break;
            }

            if (!int.TryParse(args[1], out var updateId))
            {
                Console.WriteLine("Invalid ID");
                break;
            }
            taskManager.UpdateTask(updateId, string.Join(" ", args.Skip(2)));
            break;
        case "delete":
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: delete <id>");
                break;
            }

            if (!int.TryParse(args[1], out var deleteId))
            {
                Console.WriteLine("Invalid ID");
                break;
            }
            taskManager.DeleteTask(deleteId);
            break;
        case "mark":
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: mark <id> <status>");
                break;
            }

            if (!int.TryParse(args[1], out var markId))
            {
                Console.WriteLine("Invalid ID");
                break;
            }
            taskManager.MarkTask(markId, args[2].ToLower());
            break;
        case "list":
            taskManager.ListTasks(args.Length > 1 ? args[1].ToLower() : "all");
            break;
        default:
            Console.WriteLine("Unknown command");
            break;
    }
}