using Microsoft.Practices.Unity;
using MosquitoLab.Application.Common.Services;
using MosquitoLab.Application.Common.Services.Interfaces;
using MosquitoLab.Domain.Common.Repositories;
using MosquitoLab.Domain.PakcageGenarator;
using MosquitoLab.Domain.Persistence.Context;
using MosquitoLab.Infra.Common.Repositories;
using MosquitoLab.Infra.PackageGenerator;
using MosquitoLab.Infra.Persistence.Context;

namespace MosquitoLab.Bootstrap.DependencyRegisters.Common
{
    public class CommonRegisterTypes
    {
        public static void Initialize(IUnityContainer container)
        {
            container.RegisterType<IDbContext, DbContext>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType(typeof(IAppService<>), typeof(AppService<>));
            container.RegisterType(typeof(IDatabaseInfoRepository), typeof(DatabaseInfoRepository));
            container.RegisterType(typeof(IWingbankPackageProcess), typeof(WingbankPackageProcess));
        }
    }
}
