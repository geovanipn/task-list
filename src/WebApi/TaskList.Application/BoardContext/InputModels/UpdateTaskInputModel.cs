using Newtonsoft.Json;
using TaskList.Domain.BoardContext.Models;

namespace TaskList.Application.BoardContext.InputModels
{
    public sealed class UpdateTaskInputModel : CreateTaskInputModel
    {
        [JsonIgnore]
        public long Id { get; set; }

        public TypeTaskStatus Status { get; set; }
    }
}
