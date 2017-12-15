using System;
using YG.View;

namespace YG.Controllers
{
    internal class RootViewController : IViewController
    {
        public IViewController Parrent => this;
        public IViewController Root => this;
        public IViewController Current { get; private set; }

        public IView GetView(Type viewModelType)
        {
            throw new NotImplementedException();
        }
    }
}
