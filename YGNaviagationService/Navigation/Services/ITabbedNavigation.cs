using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace YG.Navigation.Services
{
    internal interface ITabbedNavigation : INavigation<Page>, IMultiPageController<Page>
    {
    }
}