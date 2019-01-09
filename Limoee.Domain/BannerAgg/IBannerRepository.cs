using System;
using System.Collections.Generic;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.BannerAgg
{
    public interface IBannerRepository : IBaseRepository<Banner, Guid>
    {
        PagedResult<Banner> GetAllActiveBanners(int pageIndex = 1, int pageSize = 30);
        PagedResult<Banner> GetAllDeactiveBanners(int pageIndex = 1, int pageSize = 30);
        void DeactiveBanner(Guid id);
        void ActicateBanner(Guid id);
    }
}
