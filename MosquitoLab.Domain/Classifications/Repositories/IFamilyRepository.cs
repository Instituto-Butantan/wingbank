using System.Collections.Generic;
using MosquitoLab.Domain.Classifications.Dto;
using MosquitoLab.Domain.Classifications.Entities;
using MosquitoLab.Domain.Common.Repositories;

namespace MosquitoLab.Domain.Classifications.Repositories
{
    public interface IFamilyRepository : IRepository<Family>
    {
        IList<SimpleSelectDto> All();
    }
}
