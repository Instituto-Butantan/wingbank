using System.Collections.Generic;
using MosquitoLab.Domain.Accounts.Filters;
using MosquitoLab.Domain.Classifications.Dto;
using MosquitoLab.Domain.Common.Dto;

namespace MosquitoLab.Application.Common.Services.Interfaces
{
    public interface IAdvancedSearchAppService
    {
        IList<SimpleSelectDto> GetFamlies();
        IList<SimpleSelectDto> GetSubfamilies(AdancedSearchFilter filter);
        IList<SimpleSelectDto> GetTribes(AdancedSearchFilter filter);
        IList<SimpleSelectDto> GetGenus(AdancedSearchFilter filter);
        IList<SimpleSelectDto> GetSubgenus(AdancedSearchFilter filter);
        IList<SimpleSelectDto> GetSpecies(AdancedSearchFilter filter);
        IList<SimpleSelectDto> GetSubspecies(AdancedSearchFilter filter);
        DatabaseInfoDto GetDatabaseInfo();
    }
}
