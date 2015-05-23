using Caliburn.Micro;
using Solid.Practices.IoC;
using TechTalk.SpecFlow;

namespace LogoUI.Samples.Cient.Gui.Tests.Specifications
{
    static class ScenarioHelper
    {
        private const string RootObjectFactoryKey = "rootObjectFactory";
        private const string RootObjectKey = "rootObject";
        private const string ContainerKey = "container";

        internal static void Initialize(
            IIocContainer iocContainer,
            IRootObjectFactory rootObjectFactory)
        {
            ScenarioContext.Current.Add(ContainerKey, iocContainer);
            ScenarioContext.Current.Add(RootObjectFactoryKey, rootObjectFactory);
        }

        internal static void CreateAndActivateRootObject()
        {
            var rootObjectFactory = (IRootObjectFactory)ScenarioContext.Current[RootObjectFactoryKey];
            ScenarioContext.Current.Add(RootObjectKey, rootObjectFactory.CreateRootObject());
            ScreenExtensions.TryActivate(ScenarioContext.Current[RootObjectKey]);
        }        

        internal static void Clear()
        {
            ScenarioContext.Current.Clear();
        }

        internal static object Container
        {
            get { return ScenarioContext.Current[ContainerKey]; }
        }

        internal static object RootObject
        {
            get { return ScenarioContext.Current[RootObjectKey]; }
        }
    }
}