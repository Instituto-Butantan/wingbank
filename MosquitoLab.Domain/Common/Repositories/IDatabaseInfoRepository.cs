using System;
using MosquitoLab.Domain.Common.Dto;

namespace MosquitoLab.Domain.Common.Repositories
{
    public interface IDatabaseInfoRepository : IDisposable
    {
        DatabaseInfoDto GetDatabaseInfo();
    }
}
