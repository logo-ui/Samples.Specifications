﻿using Attest.Fake.Moq;
using TechTalk.SpecFlow;

namespace LogoUI.Samples.Cient.Gui.Tests.Specifications.Steps
{
    [Binding]
    class LogoutSteps : StepsBase<FakeFactory>
    {
        [Given(@"Logout request succeeds")]
        public void GivenLogoutRequestSucceeds()
        {
            //TODO: do nothing for now
            //think what should be the behavior in case of failed logout
        }

        [When(@"I press the logout button")]
        public void WhenIPressTheLogoutButton()
        {
            StructureHelper.GetShell().LogoutCommand.Execute(null);
        }
    }
}
