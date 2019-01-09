using System;
using Limoee.Domain.Banners;
using Limoee.Infrastructure.Domain;

namespace Limoee.Application.Command.Banners
{
    public class BannerOperationCommand
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BannerOperationCommand(IBannerRepository bannerRepository, IUnitOfWork unitOfWork)
        {
            _bannerRepository = bannerRepository;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Create Banner by Admin
        /// </summary>
        /// <param name="command"></param>
        public void CreateBanner(CreateBannerCommand command)
        {
            var banner = new Banner(command.BannerDTO.PosterName, command.BannerDTO.Dimension,
                command.BannerDTO.CreationTime, command.BannerDTO.IsActive, command.BannerDTO.Deadline,
                command.BannerDTO.BannerPicture, command.BannerDTO.PosterWebSite, command.BannerDTO.PosterPhone,
                command.BannerDTO.PosterMobile);

            _bannerRepository.Add(banner);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Update Banner by Admin
        /// </summary>
        /// <param name="command"></param>
        public void UpdateBanner(UpdateBannerCommand command)
        {
            var banner = new Banner(command.BannerDTO.PosterName, command.BannerDTO.Dimension,
               command.BannerDTO.CreationTime, command.BannerDTO.IsActive, command.BannerDTO.Deadline,
               command.BannerDTO.BannerPicture, command.BannerDTO.PosterWebSite, command.BannerDTO.PosterPhone,
               command.BannerDTO.PosterMobile);

            _bannerRepository.Update(banner);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Remove a banner by Admin
        /// </summary>
        /// <param name="bannerId"></param>
        public void RemoveBanner(Guid bannerId)
        {
            _bannerRepository.Remove(bannerId);
        }

    }
}
