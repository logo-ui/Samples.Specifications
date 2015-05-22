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
        private ShellViewModel _rootObject;

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
            _rootObject = CreateRootObject();
            ScreenExtensions.TryActivate(_rootObject);
        }

        [When(@"I select the network authentication option")]
        public void WhenISelectTheNetworkAuthenticationOption()
        {
            var loginViewModel = (LoginViewModel)_rootObject.ActiveItem;
            loginViewModel.SelectedLogin = "Network Authentication";
        }

        [When(@"I press the login button")]
        public void WhenIPressTheLoginButton()
        {
            var loginViewModel = (LoginViewModel)_rootObject.ActiveItem;
            loginViewModel.LoginCommand.Execute(null);
        }        

        [Then(@"Application automatically navigates to the login screen")]
        public void ThenApplicationAutomaticallyNavigatesToTheLoginScreen()
        {
            var activeItem = _rootObject.ActiveItem;
            Assert.IsInstanceOf<LoginViewModel>(activeItem);
        }

        [Then(@"Application navigates to the main screen")]
        public void ThenApplicationNavigatesToTheMainScreen()
        {
            var activeItem = _rootObject.ActiveItem;
            Assert.IsInstanceOf<MainViewModel>(activeItem);
        }

        [Then(@"User remains at the login screen")]
        public void ThenUserRemainsAtTheLoginScreen()
        {
            var activeItem = _rootObject.ActiveItem;
            Assert.IsInstanceOf<LoginViewModel>(activeItem);
        }

        [Then(@"Local authentication is automatically selected in the authentication options list")]
        public void ThenLocalAuthenticationIsAutomaticallySelectedInTheAuthenticationOptionsList()
        {
            var loginViewModel = (LoginViewModel)_rootObject.ActiveItem;
            var selectedLogin = loginViewModel.SelectedLogin;
            StringAssert.AreEqualIgnoringCase("Local authentication",selectedLogin);
        }

        [Then(@"Username text box contains '(.*)'")]
        public void ThenUsernameTextBoxContains(string userName)
        {
            var loginViewModel = (LoginViewModel)_rootObject.ActiveItem;
            var actualUserName = loginViewModel.UserName;
            Assert.AreEqual(userName, actualUserName);
        }        

        [Then(@"Error message is displayed with the following text '(.*)'")]
        public void ThenErrorMessageIsDisplayedWithTheFollowingText(string expectedErrorMessage)
        {
            var loginViewModel = (LoginViewModel)_rootObject.ActiveItem;
            var actualErrorMessage = loginViewModel.LoginFailureCause;
            StringAssert.AreEqualIgnoringCase(expectedErrorMessage, actualErrorMessage);
        }        
    }
}
