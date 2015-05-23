using System.Windows.Threading;
using Attest.Fake.Core;
using Attest.Fake.Moq;
using Caliburn.Micro;
using LogoFX.UI.Bootstrapping.SimpleContainer;
using LogoFX.UI.Tests.Infra;
using LogoUI.Samples.Client.Gui.Shell.ViewModels;
using LogoUI.Samples.Gui.Tests.Shared;
using Solid.Practices.IoC;
using Solid.Practices.Scheduling;
using TechTalk.SpecFlow;

namespace LogoUI.Samples.Cient.Gui.Tests.Specifications
{
    interface IRootObjectFactory
    {
        object CreateRootObject();
    }    

    internal abstract class SpecflowBridgeBase<TIocContainer, TFakeFactory, TRootObject, TBootstrapper> :        
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

        private TRootObject CreateRootObjectInternal()
        {
            return CreateRootObject();
        }

        object IRootObjectFactory.CreateRootObject()
        {
            return CreateRootObjectInternal();
        }
    }

    [Binding]
    class SpecflowBridge : SpecflowBridgeBase<ExtendedSimpleIocContainer, FakeFactory, ShellViewModel, TestBootstrapper>
    {
        protected override void SetupOverride()
        {
            base.SetupOverride();
            TaskScheduler.Current = new SameThreadTaskScheduler();
            Dispatch.Current = new SameThreadDispatch();            
        }

        protected override void TearDownOverride()
        {
            base.TearDownOverride();
            AssemblySource.Instance.Clear();            
        }        
    }
}
