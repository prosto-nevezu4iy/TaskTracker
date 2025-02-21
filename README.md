# Task Tracker CLI

The Task Tracker CLI is a simple command-line interface application that helps you manage your tasks. Whether you're working on personal projects, studying, or simply keeping track of your to-do list, this tool allows you to:

- Add, update, and delete tasks
- Mark tasks as "in progress" or "done"
- List all tasks, all completed tasks, all incomplete tasks, and all tasks in progress

The tasks are stored in a local JSON file, ensuring that your data is preserved between sessions.

## Installation

1. Clone the repository or download the source code.
2. Navigate to the project directory in your terminal.
3. Run the application with the appropriate commands below.

## Usage

1. Add a task

```bash
add Task description
```

2. Update a task

```bash
update <task_id> Updated task description
```

3. Delete a task

```bash
delete <task_id>
```

4. Mark a task as done or as inprogress

```bash
mark <task_id> inprogress
mark <task_id> done
```

5. List all tasks

```bash
list
```

6. List tasks by status

```bash
list todo
list inprogress
list done
```

## Project url

https://github.com/prosto-nevezu4iy/TaskTracker