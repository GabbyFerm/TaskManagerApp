using System;
using TaskManagerApp;

namespace TaskManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskManager = new TaskManager();
            var validator = new TaskValidator();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Your To Do List!");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Remove Task");
                Console.WriteLine("3. Update Task");
                Console.WriteLine("4. Mark Task as Completed");
                Console.WriteLine("5. List All Tasks");
                Console.WriteLine("6. List Completed Tasks");
                Console.WriteLine("7. List Uncompleted Tasks");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        string title = "";
                        string description = "";

                        while (string.IsNullOrWhiteSpace(title))
                        {
                            Console.WriteLine("Enter task title:");
                            title = Console.ReadLine()!;
                            if (string.IsNullOrWhiteSpace(title))
                                Console.WriteLine("Title cannot be empty.");
                        }

                        while (string.IsNullOrWhiteSpace(description))
                        {
                            Console.WriteLine("Enter task description:");
                            description = Console.ReadLine()!;
                            if (string.IsNullOrWhiteSpace(description))
                                Console.WriteLine("Description cannot be empty.");
                        }

                        var newTask = new UserTask(taskManager.GetTasks().Count + 1, title, description);

                        var result = validator.Validate(newTask);
                        if (result.IsValid)
                        {
                            taskManager.AddTask(newTask);
                            Console.WriteLine("Task added successfully!");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                Console.WriteLine($"Error: {error.ErrorMessage}");
                            }
                        }
                        break;

                    case "2":
                        Console.WriteLine("Enter task ID to remove:");
                        int removeId = Convert.ToInt32(Console.ReadLine());
                        taskManager.RemoveTask(removeId);
                        Console.WriteLine("Task removed successfully!");
                        break;

                    case "3":
                        Console.WriteLine("Enter task ID to update:");
                        int updateId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new title:");
                        string newTitle = Console.ReadLine()!;
                        Console.WriteLine("Enter new description:");
                        string newDescription = Console.ReadLine()!;
                        taskManager.UpdateTask(updateId, newTitle, newDescription);
                        Console.WriteLine("Task updated successfully!");
                        break;

                    case "4":
                        Console.WriteLine("Enter task ID to mark as completed:");
                        int completeId = Convert.ToInt32(Console.ReadLine());
                        taskManager.MarkTaskAsCompleted(completeId);
                        Console.WriteLine("Task marked as completed!");
                        break;

                    case "5":
                        var allTasks = taskManager.GetAllTasks();
                        foreach (var task in allTasks)
                        {
                            Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Completed: {task.IsCompleted}");
                        }
                        break;

                    case "6":
                        var completedTasks = taskManager.GetCompletedTasks();
                        foreach (var task in completedTasks)
                        {
                            Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Completed: {task.CompletedDate}");
                        }
                        break;

                    case "7":
                        var uncompletedTasks = taskManager.GetUncompletedTasks();
                        foreach (var task in uncompletedTasks)
                        {
                            Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Completed: {task.IsCompleted}");
                        }
                        break;

                    case "8":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}