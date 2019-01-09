using Limoee.Application.DTO;

namespace Limoee.Application.Command.Banners
{
    public class UpdateBannerCommand
    {
        internal BannerDTO BannerDTO { get; set; }

        public UpdateBannerCommand(BannerDTO bannerDTO)
        {
            BannerDTO = bannerDTO;
        }
    }
}
