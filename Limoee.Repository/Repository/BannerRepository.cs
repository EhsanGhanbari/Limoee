using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using Limoee.Domain.BannerAgg;
using Limoee.Infrastructure.Domain;
using Limoee.Repository.Infrastructure;

namespace Limoee.Repository.Repository
{
    public class BannerRepository : BaseRepository<Banner, Guid>, IBannerRepository
    {

        public BannerRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        /// <summary>
        /// Returns all the active banners
        /// </summary>
        /// <returns></returns>
        public PagedResult<Banner> GetAllActiveBanners(int pageIndex = 1, int pageSize = 30)
        {
            var total = DataContext.Banners.CountAsync();

            var result = new PagedResult<Banner>
            {
                PageSize = pageSize,
                CurrentPage = pageIndex,
                TotalCount = total.Result,

                Results = DataContext.Banners.Where(ba => ba.IsActive)
               .OrderByDescending(ban => ban.CreationTime).

                Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
            };
            return result;
        }

        /// <summary>
        /// Returns all the deactive banners
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedResult<Banner> GetAllDeactiveBanners(int pageIndex = 1, int pageSize = 30)
        {
            var total = DataContext.Banners.CountAsync();

            var result = new PagedResult<Banner>
            {
                PageSize = pageSize,
                CurrentPage = pageIndex,
                TotalCount = total.Result,

                Results = DataContext.Banners.Where(ba => ba.IsActive == false)
               .OrderByDescending(ban => ban.CreationTime).

                Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
            };
            return result;
        }

        public void DeactiveBanner(Guid id)
        {
            var banner = new Banner { Id = id };
            DataContext.Banners.Attach(banner);
            banner.IsActive = false;
        }

        public void ActicateBanner(Guid id)
        {
            Queryable.Single(DataContext.Banners.Where(c => c.Id == id), c => c.IsActive);
        }


        public override PagedResult<Banner> GetMany(Expression<Func<Banner, bool>> expressionQuery, int pageIndex = 1, int pageSize = 30)
        {
            throw new NotImplementedException();
        }
    }
}
