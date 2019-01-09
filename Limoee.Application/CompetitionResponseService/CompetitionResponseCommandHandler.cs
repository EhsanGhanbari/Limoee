using System;
using Limoee.Application.CommandProcessor.Command;
using Limoee.Domain.CompetitionAgg;
using Limoee.Domain.CompetitionResponseAgg;
using Limoee.Repository.Infrastructure;

namespace Limoee.Application.CompetitionResponseService
{
    public class CompetitionResponseCommandHandler : ICommandHandler<CreateCompetitionResponseCommand>
    {
        private readonly ICompetitionRepository _competitionRepository;
        private readonly ICompetitionResponseRepository _competitionResponseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompetitionResponseCommandHandler(ICompetitionRepository competitionRepository,
            ICompetitionResponseRepository competitionResponseRepository,
            IUnitOfWork unitOfWork)
        {
            _competitionRepository = competitionRepository;
            _competitionResponseRepository = competitionResponseRepository;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Create Competition respond 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(CreateCompetitionResponseCommand command)
        {
            try
            {
                var competitionRespond = AutoMapper.Mapper.Map<CreateCompetitionResponseCommand, CompetitionResponse>(command);

                var competition = _competitionRepository.GetById(command.Competition.Id);
                if (command.ResponseDate < competition.StartDate || command.ResponseDate > competition.EndDate)
                {
                    throw new ArgumentException("تاریخ پاسخ دهی در بازی زمانی تعیین شده برای مسابقه نیست ");
                }
                _competitionResponseRepository.Add(competitionRespond);
                _unitOfWork.Commit();
                return new SuccessResult("OK!");
            }
            catch (Exception exception)
            {
                return new FailureResult(exception.Message);
            }
        }
    }
}
