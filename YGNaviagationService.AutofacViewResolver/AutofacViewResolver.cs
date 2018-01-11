using System;
using Autofac;
using YG.ViewLocation;

namespace YGNaviagationService.AutofacViewResolver
{
    public class AutofacViewResolver : IViewResolve
    {
        private readonly IContainer _container;

        public AutofacViewResolver(IContainer container)
        {
            _container = container;
        }

        public object GetView(Type viewType)
        {
            return _container.Resolve(viewType);
        }

        public TView GetView<TView>() where TView : class, new()
        {
            return _container.Resolve<TView>();
        }
    }
}
