using Microsoft.Practices.Unity;
using MosquitoLab.Application.Common.Services;
using MosquitoLab.Application.Common.Services.Interfaces;
using MosquitoLab.Application.Individuals.Services;
using MosquitoLab.Application.Individuals.Services.Interfaces;
using MosquitoLab.Domain.Individuals.Repositories;
using MosquitoLab.Infra.Publications.Repositories;

namespace MosquitoLab.Bootstrap.DependencyRegisters.Individual
{
    public class IndividualRegisterTypes
    {
        public static  void Initialize(IUnityContainer container)
        {
            RegisterRepository(container);
            RegisterAppService(container);
        }

        private static void RegisterAppService(IUnityContainer container)
        {
            container.RegisterType<IWingImageAppService, WingImageAppService>();
            container.RegisterType<IAdvancedSearchAppService, AdvancedSearchAppService>();
            
        }

        private static void RegisterRepository(IUnityContainer container)
        {
            container.RegisterType<IWingImageRepository, WingImageRepository>();
        }
    }
}
