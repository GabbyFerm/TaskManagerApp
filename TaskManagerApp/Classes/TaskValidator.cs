using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TaskManagerApp.Classes
{
    public class TaskValidator : AbstractValidator<UserTask>
    {
        public TaskValidator()
        {
            RuleFor(task => task.Title).NotEmpty().WithMessage("Title cannot be empty.");
            RuleFor(task => task.Description).NotEmpty().WithMessage("Description cannot be empty.");
        }
    }
}
