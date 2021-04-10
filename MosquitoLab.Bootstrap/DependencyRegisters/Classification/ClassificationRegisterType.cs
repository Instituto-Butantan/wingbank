using Microsoft.Practices.Unity;
using MosquitoLab.Domain.Classifications.Repositories;
using MosquitoLab.Infra.Classifications.Repositories;

namespace MosquitoLab.Bootstrap.DependencyRegisters.Classification
{
    public class ClassificationRegisterType
    {
        public static void Initialize(IUnityContainer container)
        {
            RegisterRepository(container);
            RegisterAppService(container);
        }

        private static void RegisterAppService(IUnityContainer container)
        {
            
        }

        private static void RegisterRepository(IUnityContainer container)
        {
            container.RegisterType<IFamilyRepository, FamilyRepository>();
            container.RegisterType<ISubfamilyRepository, SubfamilyRepository>();
            container.RegisterType<IGenusRepository, GenusRepository>();
            container.RegisterType<ISubgenusRepository, SubgenusRepository>();
            container.RegisterType<ISpeciesRepository, SpeciesRepository>();
            container.RegisterType<ISubspeciesRepository, SubspeciesRepository>();
            container.RegisterType<ITribeRepository, TribeRepository>();
        }
    }
}
