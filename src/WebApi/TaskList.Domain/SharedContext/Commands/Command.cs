
using FluentValidation.Results;

namespace TaskList.Domain.SharedContext.Commands
{
    public abstract class Command
    {
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool IsValid();

        public string Name => GetType().Name;
    }
}
