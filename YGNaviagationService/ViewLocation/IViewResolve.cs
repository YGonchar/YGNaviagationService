using System;

namespace YG.ViewLocation
{
    public interface IViewResolve
    {
        object GetView(Type viewType);
        TView GetView<TView>() where TView : class, new();
    }
}
