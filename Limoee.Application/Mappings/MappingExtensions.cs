using AutoMapper;
using Limoee.Infrastructure.Domain;

namespace Limoee.Application.Mappings
{
    public static class MappingExtensions
    {
        public static IMappingExpression<TSrc, TDest> IncludePagedResultMapping<TSrc, TDest>(this IMappingExpression<TSrc, TDest> expression)
        {
            Mapper.CreateMap<PagedResult<TSrc>, PagedResult<TDest>>()
                .ForMember(dest => dest.HasMoreResults, opt => opt.MapFrom(src => src.HasMoreResults))
                .ForMember(dest => dest.CurrentPage, opt => opt.MapFrom(src => src.CurrentPage))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Results))
                .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages));

            return expression;
        }
    }
}