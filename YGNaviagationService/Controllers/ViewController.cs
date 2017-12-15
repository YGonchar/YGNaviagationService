using System;
using System.Reflection;
using YG.View;
using YG.ViewLocation;
using YG.ViewModel;

namespace YG.Controllers
{
    public class ViewController : IViewController
    {
        private readonly IViewLocation _viewLocator;

        public ViewController(IViewLocation viewLocator)
        {
            _viewLocator = viewLocator;
        }
        public IViewController Parrent { get; set; }
        public IViewController Root { get; set; }
        public IViewController Current { get; }

        public IView GetView(Type viewModelType)
        {
            if (!typeof(IViewModel).GetTypeInfo().IsAssignableFrom(viewModelType))
                throw new ArgumentException(nameof(viewModelType));

            var view = _viewLocator.FindView(viewModelType);
            return view;
        }
    }
}
