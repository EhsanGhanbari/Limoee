using System;

namespace Limoee.Repository.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        LimoeeDataContext Get();
    }
}