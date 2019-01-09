using System;
using Limoee.Application.CommandProcessor.Command;

namespace Limoee.Application.BannerService
{
    public class DeactivateBannerCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
