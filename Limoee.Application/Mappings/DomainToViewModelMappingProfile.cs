using AutoMapper;
using Limoee.Application.BannerService;
using Limoee.Application.CompetitionResponseService;
using Limoee.Application.CompetitionService;
using Limoee.Domain.BannerAgg;
using Limoee.Domain.CompetitionAgg;
using Limoee.Domain.CompetitionResponseAgg;

namespace Limoee.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Answer, AnswerDTO>();
            Mapper.CreateMap<Question, QuestionDTO>()
                 .ForMember(dest => dest.AcceptedAnswer, exprestion => exprestion.Ignore());

            Mapper.CreateMap<Competition, CompetitionDTO>().IncludePagedResultMapping();
           
            Mapper.CreateMap<CompetitionResponse, CompetitionResponseDTO>()
                .ForMember(dest => dest.Answers, exprestion => exprestion.Ignore());

            Mapper.CreateMap<Banner, BannerDTO>();
            Mapper.CreateMap<Banner, BannerDTO>().IncludePagedResultMapping();
        }

    }
}