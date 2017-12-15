using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace YG.Navigation.Services
{
    public class StackNavigation : INavigation<Page>, INavigationPageController
    {
        private readonly NavigationPage _page;

        public StackNavigation(NavigationPage page)
        {
            _page = page;
        }
        public Page CurrentPage { get; }
        public Page Peek(int depth = 0)
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopAsyncInner(bool animated, bool fast = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Page> Pages { get; }
        public int StackDepth { get; }
        public event EventHandler<NavigationRequestedEventArgs> InsertPageBeforeRequested;
        public event EventHandler<NavigationRequestedEventArgs> PopRequested;
        public event EventHandler<NavigationRequestedEventArgs> PopToRootRequested;
        public event EventHandler<NavigationRequestedEventArgs> PushRequested;
        public event EventHandler<NavigationRequestedEventArgs> RemovePageRequested;
    }
}
