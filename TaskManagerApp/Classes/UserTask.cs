using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp.Classes
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsCompleted { get; set; }

        public UserTask(int id, string title, string description, DateTime? createdDate = null)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedDate = createdDate ?? DateTime.Now; 
            IsCompleted = false;
        }
    }
}