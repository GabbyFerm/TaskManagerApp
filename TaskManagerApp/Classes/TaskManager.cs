using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TaskManagerApp.Interface;

namespace TaskManagerApp.Classes
{
    public class TaskManager : ITaskManager
    {
        private List<UserTask> tasks = new List<UserTask>();
        private string jsonFilePath = @"Json\UserTasks.json";

        public TaskManager()
        {
            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine("JSON file does not exist. Creating a new one.");
                File.WriteAllText(jsonFilePath, "{\"userTasks\": []}");
            }
            else
            {
                Console.WriteLine("Reading JSON file...");
                var json = File.ReadAllText(jsonFilePath);
                Console.WriteLine($"JSON content: {json}");
                var taskList = JsonConvert.DeserializeObject<TaskList>(json);
                tasks = taskList?.UserTasks ?? new List<UserTask>();
                Console.WriteLine($"{tasks.Count} tasks loaded.");
            }
        }

        public void AddTask(UserTask task)
        {
            var validator = new TaskValidator();
            var result = validator.Validate(task);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"Validation error: {error.ErrorMessage}");
                }
                return; 
            }
            tasks.Add(task);
            SaveTasksToJson();
        }

        public void RemoveTask(int taskId)
        {
            var task = tasks.FirstOrDefault(task => task.Id == taskId);
            if (task != null)
            {
                tasks.Remove(task);
                SaveTasksToJson();
            }
        }

        public void UpdateTask(int taskId, string title, string description)
        {
            var task = tasks.FirstOrDefault(task => task.Id == taskId);
            if (task != null)
            {
                task.Title = title;
                task.Description = description;
                SaveTasksToJson();
            }
        }

        public List<UserTask> GetTasks()
        {
            return tasks;
        }

        public void MarkTaskAsCompleted(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.IsCompleted = true;
                task.CompletedDate = DateTime.Now;
                SaveTasksToJson();
            }
        }

        private void SaveTasksToJson()
        {
            var taskList = new TaskList { UserTasks = tasks };
            var json = JsonConvert.SerializeObject(taskList, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
    }
}