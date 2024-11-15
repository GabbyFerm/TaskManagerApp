using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp.Classes
{
    public class TaskList
    {
        public List<UserTask> UserTasks { get; set; }

        public TaskList()
        {
            UserTasks = new List<UserTask>();
        }
    }
}