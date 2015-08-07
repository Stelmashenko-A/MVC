using System.Web.Mvc;
using DiGraph.MMAS;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using MVC.Authentication;
using MVC.Repository;

namespace MVC.Unity
{
    public class Loader
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IAlgorithm, MinMaxAntSystem>();
            container.RegisterType<IArrayRepository, ArrayRepository>();
            container.RegisterType<IParametersRepository, ParametersRepository>();
            container.RegisterType<IResultRepository, ResultRepositoty>();
            container.RegisterType<ICryptor, PassCryptor>();
            MvcUnityContainer.Container = container;
            return container;
        }
    }
}