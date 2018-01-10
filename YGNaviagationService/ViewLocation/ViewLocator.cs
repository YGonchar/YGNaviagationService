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

        public ViewLocator(IViewDependencyContainer dependencyContainer)
        {
            _dependencyContainer = dependencyContainer;
        }

        //public IView FindView(Type viewModelType)
        //{
        //    var viewType = FindViewType(viewModelType);
        //}

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
