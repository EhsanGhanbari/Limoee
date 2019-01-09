using System;
using System.Collections.Generic;
using Limoee.Application.CommandProcessor.Command;

namespace Limoee.Application.BannerService
{
    public class LogDisplayedBannerCommand : ICommand
    {
        public ISet<Guid> BannerIds { get; set; } 

    }
}
