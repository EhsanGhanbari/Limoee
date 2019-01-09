using System;
using Limoee.Domain.BannerAgg;

namespace Limoee.Application.BannerService
{
    public class BannerDTO
    {
        public Guid Id { get; set; }
        public string Advertiser { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AdvertiserHomePage { get; set; }
        public DisplayArea DisplayArea { get; set; }
        public decimal AdvertisementCost { get; set; }
        public BannerImage BannerImage { get; set; }
    }
}
