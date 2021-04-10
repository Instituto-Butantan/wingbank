using System.Collections.Generic;
using MosquitoLab.Application.Common.Services.Interfaces;
using MosquitoLab.Domain.Accounts.Filters;
using MosquitoLab.Domain.Classifications.Dto;
using MosquitoLab.Domain.Classifications.Repositories;
using MosquitoLab.Domain.Common.Dto;
using MosquitoLab.Domain.Common.Repositories;

namespace MosquitoLab.Application.Common.Services
{
    public class AdvancedSearchAppService : IAdvancedSearchAppService
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly ISubfamilyRepository _subfamilyRepository;
        private readonly ISpeciesRepository _speciesRepository;
        private readonly ISubspeciesRepository _subspeciesRepository;
        private readonly IGenusRepository _genusRepository;
        private readonly ISubgenusRepository _subgenusRepository;
        private readonly ITribeRepository _tribeRepository;
        private readonly IDatabaseInfoRepository _databaseInfoRepository;

        public AdvancedSearchAppService(
            IFamilyRepository familyRepository, 
            IGenusRepository genusRepository, 
            ISpeciesRepository speciesRepository, 
            ITribeRepository tribeRepository, 
            ISubspeciesRepository subspeciesRepository, 
            ISubgenusRepository subgenusRepository, 
            ISubfamilyRepository subfamilyRepository, 
            IDatabaseInfoRepository databaseInfoRepository)
        {
            _familyRepository = familyRepository;
            _genusRepository = genusRepository;
            _speciesRepository = speciesRepository;
            _tribeRepository = tribeRepository;
            _subspeciesRepository = subspeciesRepository;
            _subgenusRepository = subgenusRepository;
            _subfamilyRepository = subfamilyRepository;
            _databaseInfoRepository = databaseInfoRepository;
        }

        public IList<SimpleSelectDto> GetFamlies()
        {
            return _familyRepository.All();
        }

        public IList<SimpleSelectDto> GetSubfamilies(AdancedSearchFilter filter)
        {
            return _subfamilyRepository.All(filter);
        }

        public IList<SimpleSelectDto> GetTribes(AdancedSearchFilter filter)
        {
            return _tribeRepository.All(filter);
        }

        public IList<SimpleSelectDto> GetGenus(AdancedSearchFilter filter)
        {
            return _genusRepository.All(filter);
        }

        public IList<SimpleSelectDto> GetSubgenus(AdancedSearchFilter filter)
        {
            return _subgenusRepository.All(filter);
        }

        public IList<SimpleSelectDto> GetSpecies(AdancedSearchFilter filter)
        {
            return _speciesRepository.All(filter);
        }

        public IList<SimpleSelectDto> GetSubspecies(AdancedSearchFilter filter)
        {
            return _subspeciesRepository.All(filter);
        }

        public DatabaseInfoDto GetDatabaseInfo()
        {
            return _databaseInfoRepository.GetDatabaseInfo();
        }
    }
}
