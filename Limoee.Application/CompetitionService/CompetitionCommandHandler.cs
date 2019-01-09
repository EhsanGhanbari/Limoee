using System;
using System.Linq;
using Limoee.Application.CommandProcessor.Command;
using Limoee.Domain.CompetitionAgg;
using Limoee.Infrastructure.Domain;
using Limoee.Repository.Infrastructure;

namespace Limoee.Application.CompetitionService
{
    public class CompetitionCommandHandler : ICommandHandler<CreateCompetitionCommand>,
        ICommandHandler<EditCompetitionCommand>
    {
        private readonly ICompetitionRepository _competitionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompetitionCommandHandler(ICompetitionRepository competitionRepository, IUnitOfWork unitOfWork)
        {
            _competitionRepository = competitionRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create Competition handler
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(CreateCompetitionCommand command)
        {
            try
            {
                var competition = AutoMapper.Mapper.Map<CreateCompetitionCommand, Competition>(command);
                if (competition.GetBrokenRules().Any())
                    return new FailureResult("This Competition has this broken rules!" +
                        competition.GetBrokenRules().Aggregate((x, y) => new BusinessRule("a", x.Rule + y.Rule)));

                _competitionRepository.Add(competition);
                _unitOfWork.Commit();
                return new SuccessResult("OK!");
            }
            catch (Exception exception)
            {
                return new FailureResult(exception.Message);
            }
        }

        /// <summary>
        /// Edit competition handler
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(EditCompetitionCommand command)
        {
            try
            {
                var competition = AutoMapper.Mapper.Map<EditCompetitionCommand, Competition>(command);
                if (competition.GetBrokenRules().Any())
                    return new FailureResult("This Competition has this broken rules!" +
                        competition.GetBrokenRules().Aggregate((x, y) => new BusinessRule("a", x.Rule + y.Rule)));

                _competitionRepository.Update(competition);
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
