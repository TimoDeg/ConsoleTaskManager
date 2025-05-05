# Task Manager Console App

A simple C# console application to manage tasks. You can add, view, update, and delete tasks with an easy-to-use command-line interface.

## 🚀 Features

- Add new tasks with descriptions.
- List all current tasks with their status.
- Change the state of a task (To Do / Done).
- Delete tasks by ID.
- Clear the console to refresh the interface.
- Clean, modular code with good practices.

## 🔧 How to Run

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/tasks-manager.git
    cd tasks-manager
    ```

2. Open in Visual Studio or run from the command line using:

    ```bash
    dotnet build
    dotnet run
    ```

## 💡 Usage

When you run the program, you'll see:
```
Welcome to your Task Manager!
1 - Add a task
2 - View your tasks
3 - Change the state of a task
4 - Delete a task
5 - Clear Console
x - Exit the program
```

### Commands:
- Enter `1` to add a task (you'll be prompted for a description).
- Enter `2` to list all tasks.
- Enter `3` to change a task’s state (you'll enter the ID and new state).
- Enter `4` to delete a task by ID.
- Enter `5` to clear the console and refresh the interface.
- Enter `x` to exit.

