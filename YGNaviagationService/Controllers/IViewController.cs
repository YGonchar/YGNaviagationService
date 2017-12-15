using System;
using YG.View;

namespace YG.Controllers
{
    public interface IViewController
    {
        IViewController Parrent { get; }
        IViewController Root { get; }
        IViewController Current { get; }

        IView GetView(Type viewModelType);
    }
}
