using System.Windows.Threading;
using Attest.Fake.Moq;
using Attest.Tests.Specflow;
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
    class SpecflowBridge : IntegrationTestsBase<ExtendedSimpleIocContainer, FakeFactory, ShellViewModel, TestBootstrapper>
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
