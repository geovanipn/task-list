using TaskList.Domain.BoardContext.Models;

namespace TaskList.Domain.BoardContext.OutputModels
{
    public sealed class TaskOutputModel
    {
        public long Id { get; set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public TypeTaskStatus Status { get; private set; }

        public TaskOutputModel(
            in long id,
            in string title,
            in string description,
            in TypeTaskStatus status)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
        }
    }
}
