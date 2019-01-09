using System;
using System.Collections.Generic;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.BannerAgg
{
    /// <summary>
    /// Banner aggregate Root
    /// </summary>
    public sealed class Banner : BaseEntity<Guid>, IAggregateRoot
    {

        /// <summary>
        /// نام آگهی دهنده
        /// </summary>
        public string Advertiser { get; set; }


        /// <summary>
        /// تاریخ درج بنر
        /// </summary>
        public DateTime CreationTime { get; set; }


        /// <summary>
        /// فعال یا غیر فعال بودن بنر 
        /// </summary>
        public bool IsActive { get; set; }


        /// <summary>
        /// تاریخ شروع نمایش بنر
        /// </summary>
        public DateTime StartDate { get; set; }


        /// <summary>
        /// تاریخ پایان نمایش بنر به صورت خودکار
        /// </summary>
        public DateTime EndDate { get; private set; }


        /// <summary>
        /// فایل تصویر بنر
        /// <see cref="http://upload.wikimedia.org/wikipedia/commons/4/43/Standard_web_banner_ad_sizes.svg"/>
        /// </summary>
        public BannerImage BannerImage { get; set; }


        /// <summary>
        /// آدرس وب سایت آگهی دهنده
        /// </summary>
        public string AdvertiserHomePage { get; set; }


        /// <summary>
        /// محل نمایش بنر در وبسایت
        /// بالا و سمت چپ
        /// </summary>
        public DisplayArea DisplayArea { get; set; }


        /// <summary>
        /// بهای پرداختی آگهی دهنده جهت نمایش در سایت
        /// </summary>
        public decimal AdvertisementCost { get; set; }

        protected override void Validate()
        {
            if (StartDate >= EndDate)
                AddBrokenRule(new BusinessRule("StartDate", "Start Date must be before than End Date!"));
        }
    }
}
