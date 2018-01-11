using System;

namespace YG.ViewLocation
{
    public class SimpleViewResolver : IViewResolve
    {
        public object GetView(Type viewType)
        {
            return Activator.CreateInstance(viewType);
        }

        public TView GetView<TView>() where TView : class, new()
        {
            return Activator.CreateInstance<TView>();
        }
    }
}
