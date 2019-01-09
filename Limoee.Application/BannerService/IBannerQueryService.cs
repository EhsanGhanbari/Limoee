using System;
using System.Collections.Generic;
using Limoee.Infrastructure.Domain;

namespace Limoee.Application.BannerService
{
    public interface IBannerQueryService
    {
        BannerDTO GetBanner(Guid id);
        PagedResult<BannerDTO> GetAllActiveBanners(PagingOptions pagingOptions);
        PagedResult<BannerDTO> GetAllDeactiveBanners(PagingOptions pagingOptions);
        IEnumerable<BannerDTO> GetAllTopSideBannersByRandom();
        IEnumerable<BannerDTO> GetAllLeftSideBannersByRandom();
    }
}