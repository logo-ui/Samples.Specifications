using Caliburn.Micro;
using LogoUI.Samples.Client.Gui.Shell.ViewModels;

namespace LogoUI.Samples.Cient.Gui.Tests.Specifications
{
    internal class StructureHelper
    {
        internal static LoginViewModel GetLogin()
        {
            return (LoginViewModel)GetActiveItem();
        }

        internal static IScreen GetActiveItem()
        {
            return (GetShell()).ActiveItem;
        }

        internal static ShellViewModel GetShell()
        {
            return (ShellViewModel)ScenarioHelper.RootObject;
        }
    }
}
