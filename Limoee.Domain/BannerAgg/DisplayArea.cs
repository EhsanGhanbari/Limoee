using System;

namespace Limoee.Domain.BannerAgg
{
    /// <summary>
    ///  محل نمایش بنر در وبسایت
    /// </summary>
    [Flags]
    public enum DisplayArea
    {
        Top = 1,
        Left = 2
    }
}