using TechTalk.SpecFlow;

namespace LogoUI.Samples.Cient.Gui.Tests.Specifications.Steps
{
    [Binding]
    class GeneralSteps
    {
        [When(@"I open the application")]
        public void WhenIOpenTheApplication()
        {
            ScenarioHelper.CreateAndActivateRootObject();
        }
    }
}
