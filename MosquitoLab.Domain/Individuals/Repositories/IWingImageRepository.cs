using System.Collections.Generic;
using MosquitoLab.Domain.Common.Repositories;
using MosquitoLab.Domain.Individuals.Dtos;
using MosquitoLab.Domain.Individuals.Entities;
using MosquitoLab.Domain.Individuals.Filters;

namespace MosquitoLab.Domain.Individuals.Repositories
{
    public interface IWingImageRepository : IRepository<WingImage>
    {
        IList<WingResultDto> Find(WingFilter filter);

        IList<WingResultDto> GetByIds(string ids);

        IList<WingResultDto> GetByIds(int [] ids);
    }
}
