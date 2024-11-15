using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerApp
{
    public class TaskManager
    {
        private HandleTaskDB taskDB;

        public TaskManager()
        {
            taskDB = new HandleTaskDB();
        }

        public void AddTask(UserTask task)
        {
            taskDB.AllUserTasks.Add(task);
            taskDB.SaveTasksToFile();
        }

        public void RemoveTask(int taskId)
        {
            var task = taskDB.AllUserTasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                taskDB.AllUserTasks.Remove(task);
                taskDB.SaveTasksToFile();
            }
        }

        public void UpdateTask(int taskId, string title, string description)
        {
            var task = taskDB.AllUserTasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.Title = title;
                task.Description = description;
                taskDB.SaveTasksToFile();
            }
        }

        public List<UserTask> GetTasks()
        {
            return taskDB.AllUserTasks;
        }

        public void MarkTaskAsCompleted(int taskId)
        {
            var task = taskDB.AllUserTasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.IsCompleted = true;
                task.CompletedDate = DateTime.Now;
                taskDB.SaveTasksToFile();
            }
        }

        public List<UserTask> GetUncompletedTasks()
        {
            return taskDB.AllUserTasks.Where(t => !t.IsCompleted).ToList();
        }

        public List<UserTask> GetCompletedTasks()
        {
            return taskDB.AllUserTasks.Where(t => t.IsCompleted).ToList();
        }

        public List<UserTask> GetAllTasks()
        {
            return taskDB.AllUserTasks;
        }
    }
}
