using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Limoee.Application.CommandProcessor.Dispatcher;
using Limoee.Domain.BannerAgg;
using Limoee.Infrastructure.Domain;

namespace Limoee.Application.BannerService
{
    public class BannerQueryService : IBannerQueryService
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly ICommandBus _commandBus;

        public BannerQueryService(IBannerRepository bannerRepository, ICommandBus commandBus)
        {
            _bannerRepository = bannerRepository;
            _commandBus = commandBus;
        }
        
        public BannerDTO GetBanner(Guid id)
        {
            var banner = _bannerRepository.GetById(id);
            return Mapper.Map<Banner, BannerDTO>(banner);
        }

        /// <summary>
        /// Returns all active banners of the system
        /// </summary>
        /// <param name="pagingOptions"></param>
        /// <returns></returns>
        public PagedResult<BannerDTO> GetAllActiveBanners(PagingOptions pagingOptions)
        {
            var banners = _bannerRepository.GetAllActiveBanners(pagingOptions.PageIndex, pagingOptions.PageSize);
            return Mapper.Map<PagedResult<Banner>, PagedResult<BannerDTO>>(banners);
        }

        /// <summary>
        /// Returns all Deactive banners of the system
        /// </summary>
        /// <param name="pagingOptions"></param>
        /// <returns></returns>
        public PagedResult<BannerDTO> GetAllDeactiveBanners(PagingOptions pagingOptions)
        {
            var banners = _bannerRepository.GetAllDeactiveBanners(pagingOptions.PageIndex, pagingOptions.PageSize);
            return Mapper.Map<PagedResult<Banner>, PagedResult<BannerDTO>>(banners);
        }

        /// <summary>
        /// returns all active banners with top side group
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BannerDTO> GetAllTopSideBannersByRandom()
        {
            var banners = _bannerRepository.GetAll().Where(b => b.DisplayArea == DisplayArea.Top && b.IsActive)
                .OrderBy(r => Guid.NewGuid());

            var command = new LogDisplayedBannerCommand
            {
                BannerIds = new HashSet<Guid>(banners.Select(c => c.Id))
            };
            _commandBus.Submit(command);

            return Mapper.Map<IEnumerable<Banner>, IEnumerable<BannerDTO>>(banners);
        }

        /// <summary>
        /// returns all active banners with left side group
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BannerDTO> GetAllLeftSideBannersByRandom()
        {
            var banners = _bannerRepository.GetAll().Where(b => b.DisplayArea == DisplayArea.Left && b.IsActive)
                .OrderBy(r => Guid.NewGuid());

            var command = new LogDisplayedBannerCommand
            {
                BannerIds = new HashSet<Guid>(banners.Select(c => c.Id))
            };

            _commandBus.Submit(command);

            return Mapper.Map<IEnumerable<Banner>, IEnumerable<BannerDTO>>(banners);
        }
    }
}
