using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.BannerAgg
{
    public class BannerLog : BaseEntity<Guid>, IAggregateRoot
    {

        /// <summary>
        /// جزئیات بنر نمایش داده شده
        /// </summary>
        public virtual Banner Banner { get; set; }
        public Guid BannerId { get; set; }
         
        /// <summary>
        /// زمان دقیق نمایش بنر در سایت
        /// می تواند در روز چندین بار نمایش داده شود که
        /// هر سری این مقدار به روز رسانی می شود
        /// </summary>
        public DateTime DisplayDate { get; set; }

        /// <summary>
        /// تعداد نمایش بنر در وبسایت
        /// </summary>
        public long Count { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
