using System;
using System.Collections.Generic;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.BannerAgg
{
    public interface IBannerLogRepository : IBaseRepository<BannerLog, Guid>
    {
        void BannerLogBulkInsert(ISet<Guid> bannerIds);
    }
}
