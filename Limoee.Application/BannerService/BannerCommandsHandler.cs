using System;
using System.Linq;
using Limoee.Application.CommandProcessor.Command;
using Limoee.Domain.BannerAgg;
using Limoee.Infrastructure.Domain;
using Limoee.Repository.Infrastructure;

namespace Limoee.Application.BannerService
{
    public class BannerCommandsHandler : ICommandHandler<CreateBannerCommand>,
        ICommandHandler<ActivateBannerCommand>, ICommandHandler<DeactivateBannerCommand>
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BannerCommandsHandler(IBannerRepository bannerRepository, IUnitOfWork unitOfWork)
        {
            _bannerRepository = bannerRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create Banner Handler
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(CreateBannerCommand command)
        {
            try
            {
                var banner = AutoMapper.Mapper.Map<CreateBannerCommand, Banner>(command);
                if (banner.GetBrokenRules().Any())
                    return new FailureResult("A business rule exception occured!" +
                             banner.GetBrokenRules().Aggregate((x, y) => new BusinessRule("a", x.Rule + y.Rule)));
                _bannerRepository.Add(banner);
                _unitOfWork.Commit();
                return new SuccessResult("OK!");
            }
            catch (Exception exception)
            {
                return new FailureResult(exception.Message);
            }
        }

        /// <summary>
        /// Activate Banner Handler
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(ActivateBannerCommand command)
        {
            try
            {
                _bannerRepository.ActicateBanner(command.Id);
                _unitOfWork.Commit();
                return new SuccessResult("OK!");
            }
            catch (Exception exception)
            {
                return new FailureResult(exception.Message);
            }
        }

        /// <summary>
        /// Deactivate Banner Handler
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(DeactivateBannerCommand command)
        {
            try
            {
                _bannerRepository.DeactiveBanner(command.Id);
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