using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace YG.Navigation.Services
{
    public class TabNavigationService<TPage> : ITabbedNavigation where TPage : TabbedPage
    {
        private readonly TPage _page;

        public TabNavigationService(TPage page)
        {
            _page = page;
        }
        public IList<Type> Tabs { get; set; }
        public Page CurrentPage { get; }
        public Page GetPageByIndex(int index)
        {
            throw new NotImplementedException();
        }
    }
}
