using System;
using YG.Annotations;
using YG.View;

namespace YG.ViewLocation
{
    public interface IViewLocation
    {
        IView FindView(Type viewModelType);
        Type FindViewType(Type viewModelType);
    }
}
