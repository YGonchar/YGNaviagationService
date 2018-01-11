using System;
using YG.Registration;
using YG.View;
using System.Reflection;
using Xamarin.Forms.Internals;

namespace YG.ViewLocation
{
    public class ViewLocator : IViewLocation
    {
        private readonly IViewDependencyContainer _dependencyContainer;
        private readonly IViewResolve _viewResolver;

        public ViewLocator(IViewDependencyContainer dependencyContainer, IViewResolve viewResolver)
        {
            _dependencyContainer = dependencyContainer;
            _viewResolver = viewResolver;
        }

        public IView FindView(Type viewModelType)
        {
            var viewType = FindViewType(viewModelType);
            return (IView)_viewResolver.GetView(viewType);
        }

        public Type FindViewType(Type viewModelType)
        {
            var attribute = viewModelType.GetTypeInfo().GetCustomAttribute<ViewModelAttribute>(false);
            var type = attribute.ViewType;

            if (!type.IsAssignableFrom(typeof(IView)))
                throw new InvalidViewTypeException(type);

            return type;
        }
    }
}
