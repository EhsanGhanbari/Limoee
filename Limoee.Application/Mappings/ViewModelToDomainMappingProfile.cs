using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Limoee.Application.CompetitionResponseService;
using Limoee.Application.CompetitionService;
using Limoee.Domain.CompetitionAgg;

namespace Limoee.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AnswerDTO, Answer>().ReverseMap();
            Mapper.CreateMap<QuestionDTO, Question>().ReverseMap();

            Mapper.CreateMap<CompetitionDTO, Competition>().ReverseMap();


        }
    }
}