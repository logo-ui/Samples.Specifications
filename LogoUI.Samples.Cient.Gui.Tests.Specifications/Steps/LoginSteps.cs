using Caliburn.Micro;
using LogoUI.Samples.Client.Data.Providers.Contracts;
using LogoUI.Samples.Client.Gui.Shell.ViewModels;
using LogoUI.Samples.Client.Gui.Tests.Fake;
using LogoUI.Samples.Client.Model.Shared;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LogoUI.Samples.Cient.Gui.Tests.Specifications.Steps
{
    [Binding]
    class LoginSteps : IntegrationTestsBase
    {        
        [Given(@"I am an authenticated user with username '(.*)'")]
        public void GivenIAmAnAuthenticatedUserWithUsername(string userName)
        {
            IdentityContext.Current = new FakeIdentityProvider {Name = userName};
        }

        [Given(@"I am an unauthenticated user")]
        public void GivenIAmAnUnauthenticatedUser()
        {
            IdentityContext.Current = new FakeIdentityProvider {Name = null};
        }               

        [Given(@"Login request succeeds")]
        public void GivenLoginRequestSucceeds()
        {
            var fakeLoginProvider = new FakeTestLoginProvider();
            fakeLoginProvider.SetupLoginSuccess();
            RegisterService<ILoginProvider>(fakeLoginProvider);            
        }

        [Given(@"Logout request succeeds")]
        public void GivenLogoutRequestSucceeds()
        {
            //TODO: do nothing for now
            //think what shoule be the behavior in case of failed logout
        }        

        [Given(@"Login request fails")]
        public void GivenLoginRequestFails()
        {
            var fakeLoginProvider = new FakeTestLoginProvider();
            fakeLoginProvider.SetupLoginFailure();
            RegisterService<ILoginProvider>(fakeLoginProvider); 
        }

        [When(@"I open the application")]
        public void WhenIOpenTheApplication()
        {
            ScenarioContext.Current.Add("test", CreateRootObject());
            ScreenExtensions.TryActivate(ScenarioContext.Current["test"]);
        }

        [When(@"I select the network authentication option")]
        public void WhenISelectTheNetworkAuthenticationOption()
        {
            var loginViewModel = GetLogin();
            loginViewModel.SelectedLogin = "Network Authentication";
        }        

        [When(@"I press the login button")]
        public void WhenIPressTheLoginButton()
        {
            var loginViewModel = GetLogin();
            loginViewModel.LoginCommand.Execute(null);
        }

        [When(@"I press the logout button")]
        public void WhenIPressTheLogoutButton()
        {
            GetShell().LogoutCommand.Execute(null);
        }

        [Then(@"Application automatically navigates to the login screen")]
        public void ThenApplicationAutomaticallyNavigatesToTheLoginScreen()
        {
            var activeItem = GetActiveItem();
            Assert.IsInstanceOf<LoginViewModel>(activeItem);
        }        

        [Then(@"Application navigates to the main screen")]
        public void ThenApplicationNavigatesToTheMainScreen()
        {
            var activeItem = GetActiveItem();
            Assert.IsInstanceOf<MainViewModel>(activeItem);
        }

        [Then(@"User remains at the login screen")]
        public void ThenUserRemainsAtTheLoginScreen()
        {
            var activeItem = GetActiveItem();
            Assert.IsInstanceOf<LoginViewModel>(activeItem);
        }

        [Then(@"User returns to the login screen")]
        public void ThenUserReturnsToTheLoginScreen()
        {
            var activeItem = GetActiveItem();
            Assert.IsInstanceOf<LoginViewModel>(activeItem);
        }

        [Then(@"Local authentication is automatically selected in the authentication options list")]
        public void ThenLocalAuthenticationIsAutomaticallySelectedInTheAuthenticationOptionsList()
        {
            var loginViewModel = GetLogin();
            var selectedLogin = loginViewModel.SelectedLogin;
            StringAssert.AreEqualIgnoringCase("Local authentication",selectedLogin);
        }

        [Then(@"Username text box contains '(.*)'")]
        public void ThenUsernameTextBoxContains(string userName)
        {
            var loginViewModel = GetLogin();
            var actualUserName = loginViewModel.UserName;
            Assert.AreEqual(userName, actualUserName);
        }        

        [Then(@"Error message is displayed with the following text '(.*)'")]
        public void ThenErrorMessageIsDisplayedWithTheFollowingText(string expectedErrorMessage)
        {
            var loginViewModel = GetLogin();
            var actualErrorMessage = loginViewModel.LoginFailureCause;
            StringAssert.AreEqualIgnoringCase(expectedErrorMessage, actualErrorMessage);
        }

        [Then(@"Username displayed at the top of the screen says '(.*)'")]
        public void ThenUsernameDisplayedAtTheTopOfTheScreenSays(string userName)
        {
            var actualUserName = GetShell().CurrentUser;
            Assert.AreEqual(userName, actualUserName);
        }        

        private static LoginViewModel GetLogin()
        {
            return (LoginViewModel)GetActiveItem();
        }

        private static IScreen GetActiveItem()
        {
            return (GetShell()).ActiveItem;
        }

        private static ShellViewModel GetShell()
        {
            return (ShellViewModel)ScenarioContext.Current["test"];
        }
    }
}
