using Attest.Fake.Core;
using Solid.Practices.IoC;

namespace LogoUI.Samples.Cient.Gui.Tests.Specifications
{
    interface IRootObjectFactory
    {
        object CreateRootObject();
    }

    internal abstract class IntegrationTestsBase<TIocContainer, TFakeFactory, TRootObject, TBootstrapper> :        
        Attest.Tests.Specflow.IntegrationTestsBase
            <TIocContainer, TFakeFactory, TRootObject, TBootstrapper>,        
        IRootObjectFactory
        where TIocContainer : IIocContainer, new() where TFakeFactory : IFakeFactory, new() where TRootObject : class        
    {
        protected override void SetupOverride()
        {
            base.SetupOverride();            
            ScenarioHelper.Initialize(IocContainer, this);
        }

        protected override void TearDownOverride()
        {
            base.TearDownOverride();
            ScenarioHelper.Clear();
        }

        private TRootObject CreateRootObjectTyped()
        {
            return CreateRootObject();
        }

        object IRootObjectFactory.CreateRootObject()
        {
            return CreateRootObjectTyped();
        }
    }    
}
