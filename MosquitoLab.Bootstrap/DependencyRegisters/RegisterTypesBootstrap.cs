using Microsoft.Practices.Unity;
using MosquitoLab.Bootstrap.DependencyRegisters.Classification;
using MosquitoLab.Bootstrap.DependencyRegisters.Common;
using MosquitoLab.Bootstrap.DependencyRegisters.Individual;

namespace MosquitoLab.Bootstrap.DependencyRegisters
{
    public class RegisterTypesBootstrap
    {
        public static void Initialize(IUnityContainer container)
        {
            CommonRegisterTypes.Initialize(container);
            IndividualRegisterTypes.Initialize(container);
            ClassificationRegisterType.Initialize(container);
        }
    }
}
