using AutoMapper;

namespace TaskList.Application.AutoMapper
{
    public sealed class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InputModelToDomainMappingProfile());
            });

            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
