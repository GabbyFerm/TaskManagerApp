using FluentValidation;

namespace TaskManagerApp
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