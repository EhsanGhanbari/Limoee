using System;

namespace Limoee.Domain.BannerAgg
{
    public enum BannerType
    {
        Leaderboard = 1,                 // 728px * 90px    
        HalfBanner = 2,                  // 234px * 60px    
        FullBanner = 4,                  // 468px * 60px    
        Rectangle = 8,                   // 300px * 100px   
        VerticalBanner = 16,             // 120px * 240px   
        VerticalRectangle = 32,          // 240px * 400px   
        Rectabgle = 64,                  // 180px * 150px   
    }
}