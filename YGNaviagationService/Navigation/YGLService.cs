using System.Threading.Tasks;
using YG.ViewLocation;

namespace YG.Navigation
{
    public class YGLService : NavigationService
    {
        public YGLService(IViewLocation viewLocator) : base(viewLocator)
        {
        }

        public override Task<string> DisplayActionSheet(string title, string cancel, string destruction, string[] buttons)
        {
            throw new System.NotImplementedException();
        }

        public override Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            throw new System.NotImplementedException();
        }
    }
}
