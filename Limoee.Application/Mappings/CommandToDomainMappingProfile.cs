using System.Linq;
using AutoMapper;
using Limoee.Application.BannerService;
using Limoee.Application.CompetitionResponseService;
using Limoee.Application.CompetitionResponseService;
using Limoee.Application.CompetitionService;
using Limoee.Domain.BannerAgg;
using Limoee.Domain.CompetitionAgg;
using Limoee.Domain.CompetitionResponseAgg;

namespace Limoee.Application.Mappings
{
    public class CommandToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "CommandToDomainMappingProfile"; }
        }

        protected override void Configure()
        {

            #region Competition

            Mapper.CreateMap<CreateCompetitionCommand, Competition>()
                .ForMember(dest => dest.Id, expression => expression.Ignore());


            Mapper.CreateMap<EditCompetitionCommand, Competition>()
                 .ForMember(dest => dest.Id, expression => expression.Ignore());

            #endregion

            #region CompetitionResponse

            Mapper.CreateMap<CreateCompetitionResponseCommand, CompetitionResponse>()
                .ForMember(dest => dest.Id, expression => expression.Ignore())
                .ForMember(dest => dest.ResponsedQuestions, expresion => expresion.Ignore());
                
             

            Mapper.CreateMap<EditCompetitionResponseCommand, CompetitionResponse>()
           .ForMember(dest => dest.Id, expression => expression.Ignore())
             .ForMember(dest => dest.ResponsedQuestions, expresion => expresion.Ignore());

            #endregion



            #region Banner

            Mapper.CreateMap<CreateBannerCommand, Banner>()
                .ForMember(dest => dest.Id, expression => expression.Ignore())
                .ForMember(dest => dest.BannerImage, expression => expression.MapFrom(
                    src => new BannerImage(src.Type, src.Name, src.Path)));

            #endregion
        }
    }
}