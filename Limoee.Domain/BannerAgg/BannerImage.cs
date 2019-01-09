using System;
using Limoee.Infrastructure.Domain;

namespace Limoee.Domain.BannerAgg
{
    public class BannerImage : BaseValueObject
    {
        public BannerImage() { }
        public BannerImage(BannerType type, string name, string path)
        {
            Type = type;
            Name = name;
            Path = path;
        }
        /// <summary>
        /// نام تصویر
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// مسیر فیزیکی فایل در سیسیتم
        /// </summary>
        public string Path { get; private set; }

        /// <summary>                                              
        /// ابعاد بنر                                             
        /// </summary>                                             
        public BannerType Type { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
