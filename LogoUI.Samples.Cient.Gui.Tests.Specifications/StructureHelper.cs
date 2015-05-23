using Attest.Tests.Specflow;
using Caliburn.Micro;
using LogoUI.Samples.Client.Gui.Shell.ViewModels;

namespace LogoUI.Samples.Cient.Gui.Tests.Specifications
{
    internal static class StructureHelper
    {
        internal static LoginViewModel GetLogin()
        {
            return (LoginViewModel)GetShellActiveItemInternal();
        }

        internal static IScreen GetShellActiveItem()
        {
            return GetShellActiveItemInternal();
        }        

        internal static ShellViewModel GetShell()
        {
            return GetShellInternal();
        }

        private static ShellViewModel GetShellInternal()
        {
            return (ShellViewModel)ScenarioHelper.RootObject;
        }

        private static IScreen GetShellActiveItemInternal()
        {
            return (GetShellInternal()).ActiveItem;
        }
    }
}
