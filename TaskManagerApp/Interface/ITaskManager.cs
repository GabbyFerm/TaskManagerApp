using System.Collections.Generic;

namespace TaskManagerApp.Interface
{
    public interface ITaskManager
    {
        void AddTask(Task task);
        void RemoveTask(int taskId);
        void UpdateTask(int taskId, string title, string description);
        List<Task> GetTasks();
        void MarkTaskAsCompleted(int taskId);
    }
}