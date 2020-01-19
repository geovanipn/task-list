using AutoMapper;
using TaskList.Application.AutoMapper.Mappings.BoardContext;
using TaskList.Application.AutoMapper.Mappings.IdentityContext;

namespace TaskList.Application.AutoMapper
{
    public sealed class InputModelToDomainMappingProfile : Profile
    {
        public InputModelToDomainMappingProfile()
        {
            this.TaskMapper();
            this.UserMapper();
        }
    }
}
