using Caliburn.Micro;
using TechTalk.SpecFlow;

namespace LogoUI.Samples.Cient.Gui.Tests.Specifications.Steps
{
    [Binding]
    class GeneralSteps
    {
        [When(@"I open the application")]
        public void WhenIOpenTheApplication()
        {
            var rootObjectFactory = (SpecflowBridge)ScenarioContext.Current["rootObjectFactory"];
            ScenarioContext.Current.Add("rootObject", rootObjectFactory.CreateRootObjectInternal());
            ScreenExtensions.TryActivate(ScenarioContext.Current["rootObject"]);
        }
    }
}
