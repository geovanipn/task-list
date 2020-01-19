using TaskList.Domain.IdentityContext.Models;
using Utils.Domain.Models;

namespace TaskList.Domain.BoardContext.Models
{
    public sealed class Task : Entity
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public TypeTaskStatus Status { get; private set; }

        public long IdUser { get; private set; }

        public User User { get; private set; }

        public static Task Create(
            in long idUser,
            in string title,
            in string description,
            in TypeTaskStatus status,
            in long id = 0) =>
            new Task
            {
                Id = id,
                IdUser = idUser,
                Title = title,
                Description = description,
                Status = status
            };
    }
}
