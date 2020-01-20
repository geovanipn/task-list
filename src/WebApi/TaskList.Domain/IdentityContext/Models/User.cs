using System.Collections.Generic;
using TaskList.Domain.BoardContext.Models;
using Utils.Domain.Models;

namespace TaskList.Domain.IdentityContext.Models
{
    public sealed class User : Entity
    {
        public string Name { get; private set; }

        public string Password { get; private set; }

        public ICollection<Task> TaskItems { get; private set; }

        private User() { }

        public static User Create(in string name, in string password) =>
            new User
            {
                Name = name,
                Password = password
            };
    }
}
