using System;
using System.Collections.Generic;
using MosquitoLab.Application.Common.Services;
using MosquitoLab.Application.Individuals.Services.Interfaces;
using MosquitoLab.Domain.Common.Repositories;
using MosquitoLab.Domain.Individuals.Dtos;
using MosquitoLab.Domain.Individuals.Entities;
using MosquitoLab.Domain.Individuals.Filters;
using MosquitoLab.Domain.Individuals.Repositories;
using MosquitoLab.Domain.Persistence.Context;

namespace MosquitoLab.Application.Individuals.Services
{
    public class WingImageAppService : AppService<WingImage>, IWingImageAppService
    {
        private readonly IWingImageRepository _wingImageRepository;
        public WingImageAppService(IRepository<WingImage> repository,
            IUnitOfWork unitOfWork,
            IWingImageRepository wingImageRepository)
            : base(repository, unitOfWork)
        {
            _wingImageRepository = wingImageRepository;
        }
        public override WingImage Get(object id)
        {
            return Repository.Get(x => x.Id == Convert.ToInt32(id));
        }

        public IList<WingResultDto> Find(WingFilter filter)
        {
            if(filter == null) filter = new WingFilter();
            return _wingImageRepository.Find(filter);
        }
    }
}
