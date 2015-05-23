using System.Windows.Threading;
using Attest.Fake.Moq;
using Caliburn.Micro;
using LogoFX.UI.Bootstrapping.SimpleContainer;
using LogoFX.UI.Tests.Infra;
using LogoUI.Samples.Client.Gui.Shell.ViewModels;
using LogoUI.Samples.Gui.Tests.Shared;
using Solid.Practices.Scheduling;
using TechTalk.SpecFlow;

namespace LogoUI.Samples.Cient.Gui.Tests.Specifications
{
    [Binding]
    class SpecflowBridge : Attest.Tests.Specflow.IntegrationTestsBase<ExtendedSimpleIocContainer, FakeFactory, ShellViewModel, TestBootstrapper>
    {
        protected override void SetupOverride()
        {
            base.SetupOverride();
            TaskScheduler.Current = new SameThreadTaskScheduler();
            Dispatch.Current = new SameThreadDispatch();
            ScenarioContext.Current.Add("container", IocContainer);  
            ScenarioContext.Current.Add("rootObjectFactory",this);
        }

        protected override void TearDownOverride()
        {
            base.TearDownOverride();
            AssemblySource.Instance.Clear();
            ScenarioContext.Current.Clear();
        }

        internal ShellViewModel CreateRootObjectInternal()
        {
            return CreateRootObject();
        }
    }
}
