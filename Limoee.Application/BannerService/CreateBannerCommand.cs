using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Limoee.Application.CommandProcessor.Command;
using Limoee.Domain.BannerAgg;

namespace Limoee.Application.BannerService
{
    public class CreateBannerCommand : ICommand
    {

        [Required(ErrorMessage = "نام آگهی دهنده ضروریست")]
        [DataType(DataType.Text, ErrorMessage = "نام آگهی دهنده نامعتبر است")]
        public string Advertiser { get; set; }

        public DateTime CreationTime { get { return DateTime.Now; } }

        public bool IsActive { get; set; }
        
        [Required(ErrorMessage = "تاریخ شروع  نمایش بنر ضروریست ")]
        [DataType(DataType.DateTime, ErrorMessage = "تاریخ وارد شده نا معتبر است")]
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage = "تاریخ پایان  نمایش بنر ضروریست ")]
        [DataType(DataType.DateTime, ErrorMessage = "تاریخ وارد شده نا معتبر است")]
        public DateTime EndDate { get; set; }


        [Required(ErrorMessage = "محل نمایش بنر بایستی مشخص شود")]
        public DisplayArea DisplayArea { get; set; }

        [Required(ErrorMessage = "آدرس سایت بنر ضروریست.")]
        [Url(ErrorMessage = "آدرس وب سایت نا معتبر است.")]
        public string AdvertiserHomePage { get; set; }
        
        [Range(0, 99999999)]
        public decimal AdvertisementCost { get; set; }

        public BannerImage BannerImage { get; set; }

        //[FileExtensions(Extensions = "jpg,png,gif,jpeg", ErrorMessage = "Please upload valid format")]
        [ValidateFile]
        public HttpPostedFileBase File { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public BannerType Type { get; set; }

    }
}
