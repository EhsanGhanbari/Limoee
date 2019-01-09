using AutoMapper;

namespace Limoee.Application.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
                x.AddProfile<CommandToDomainMappingProfile>();
            });

            Mapper.AssertConfigurationIsValid();
        }

    }
}