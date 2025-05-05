using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var taskManager = new TaskManager();
            taskManager.PrintInstructions();

            bool run = true;
            while (run)
            {
                Console.Write("\nEnter: ");
                string input = Console.ReadLine()?.Trim();

                switch (input)
                {
                    case "x":
                        run = false;
                        break;

                    case "1":
                        Console.Write("Enter task description: ");
                        string descriptionInput = Console.ReadLine();
                        taskManager.AddTask(descriptionInput);
                        Console.WriteLine("Task added successfully.");
                        break;

                    case "2":
                        taskManager.ListTasks();
                        break;

                    case "3":
                        Console.Write("Enter ID of task: ");
                        if (int.TryParse(Console.ReadLine(), out int idToChange))
                        {
                            Console.Write("Enter 1 for done, 2 for to-do state: ");
                            string stateInput = Console.ReadLine();
                            string newState = stateInput == "1" ? "Done" :
                                              stateInput == "2" ? "To Do" : null;

                            if (newState != null)
                            {
                                if (taskManager.ChangeState(idToChange, newState))
                                    Console.WriteLine("Task state updated.");
                                else
                                    Console.WriteLine("Task not found.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid state input.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID input.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter ID of task to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int idToDelete))
                        {
                            if (taskManager.DeleteTask(idToDelete))
                                Console.WriteLine("Task deleted.");
                            else
                                Console.WriteLine("Task not found.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID input.");
                        }
                        break;

                    case "5":
                        Console.Clear();
                        taskManager.PrintInstructions();
                        break;

                    default:
                        Console.WriteLine($"{input} is not a valid option.");
                        taskManager.PrintInstructions();
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }

    public class TaskManager
    {
        private readonly List<TaskItem> tasks = new();

        public void PrintInstructions()
        {
            Console.WriteLine("\nWelcome to your Task Manager!");
            Console.WriteLine("1 - Add a task");
            Console.WriteLine("2 - View your tasks");
            Console.WriteLine("3 - Change the state of a task");
            Console.WriteLine("4 - Delete a task");
            Console.WriteLine("5 - Clear Console");
            Console.WriteLine("x - Exit the program");
        }

        public void AddTask(string description)
        {
            var task = new TaskItem
            {
                Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 0,
                Description = description,
                State = "To Do"
            };
            tasks.Add(task);
        }

        public void ListTasks()
        {
            Console.WriteLine("\n[Id] [State] [Description]");
            if (!tasks.Any())
            {
                Console.WriteLine("No tasks yet.");
                return;
            }

            foreach (var task in tasks)
            {
                Console.WriteLine($"  {task.Id}   {task.State}    {task.Description}");
            }
        }

        public bool ChangeState(int id, string state)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;
            task.State = state;
            return true;
        }

        public bool DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;
            tasks.Remove(task);
            return true;
        }
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}
