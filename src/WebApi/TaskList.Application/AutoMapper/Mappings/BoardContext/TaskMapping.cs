using TaskList.Application.BoardContext.InputModels;
using TaskList.Domain.BoardContext.Commands;

namespace TaskList.Application.AutoMapper.Mappings.BoardContext
{
    public static class TaskMapping
    {
        public static void TaskMapper(this InputModelToDomainMappingProfile profile)
        {
            profile.CreateMap<CreateTaskInputModel, CreateTaskCommand>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .ConstructUsing(x => CreateTaskCommand.Create(
                    x.Title,
                    x.Description));

            profile.CreateMap<UpdateTaskInputModel, UpdateTaskCommand>()
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .ConstructUsing(x => UpdateTaskCommand.Create(
                    x.Id,
                    x.Title,
                    x.Description,
                    x.Status));

            profile.CreateMap<DeleteTaskInputModel, DeleteTaskCommand>()
                .ForMember(x => x.Title, opt => opt.Ignore())
                .ForMember(x => x.Description, opt => opt.Ignore())
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.ValidationResult, opt => opt.Ignore())
                .ConstructUsing(x => DeleteTaskCommand.Create(x.id));
        }
    }
}
