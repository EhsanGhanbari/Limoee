using System;
using System.Collections.Generic;
using AutoMapper;
using Limoee.Application.CommandProcessor.Command;
using Limoee.Domain.BannerAgg;
using Limoee.Repository.Infrastructure;

namespace Limoee.Application.BannerService
{
    public class BannerLogCommandsHandler : ICommandHandler<LogDisplayedBannerCommand>
    {
        private readonly IBannerLogRepository _bannerLogRepository;
        private readonly IBannerQueryService _bannerQueryService;
        private readonly IUnitOfWork _unitOfWork;

        public BannerLogCommandsHandler(IBannerLogRepository bannerLogRepository, IBannerQueryService bannerQueryService,
            IUnitOfWork unitOfWork)
        {
            _bannerLogRepository = bannerLogRepository;
            _bannerQueryService = bannerQueryService;
            _unitOfWork = unitOfWork;
        }

        public ICommandResult Execute(LogDisplayedBannerCommand command)
        {
            try
            {
                _bannerLogRepository.BannerLogBulkInsert(command.BannerIds);
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
