using System.Collections.Generic;
using MosquitoLab.Application.Common.Services.Interfaces;
using MosquitoLab.Domain.Individuals.Dtos;
using MosquitoLab.Domain.Individuals.Entities;
using MosquitoLab.Domain.Individuals.Filters;

namespace MosquitoLab.Application.Individuals.Services.Interfaces
{
    public interface IWingImageAppService : IAppService<WingImage>
    {
        IList<WingResultDto> Find(WingFilter filter);

    }
}
