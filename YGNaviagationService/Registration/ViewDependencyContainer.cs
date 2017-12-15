using System;
using Xamarin.Forms;
using YG.View;

namespace YG.Registration
{
    public class ViewDependencyContainer : IViewDependencyContainer
    {
        public void Setup(Action<IViewDependencyContainer> setupAction)
        {
            setupAction(this);
        }

        public IViewDependencyContainer RegisterTabbedView<TContainer, TView1, TView2>() where TContainer : MultiPage<Page> where TView1 : Element, IView where TView2 : Element, IView
        {
            return RegisterTabbedView(typeof(TContainer), new[] { typeof(TView1), typeof(TView2) });
        }

        public IViewDependencyContainer RegisterTabbedView<TContainer, TView1, TView2, TView3>() where TContainer : MultiPage<Page> where TView1 : Element, IView where TView2 : Element, IView where TView3 : Element, IView
        {
            return RegisterTabbedView(typeof(TContainer), new[] { typeof(TView1), typeof(TView2), typeof(TView3) });
        }

        public IViewDependencyContainer RegisterTabbedView<TContainer, TView1, TView2, TView3, TView4>() where TContainer : MultiPage<Page> where TView1 : Element, IView where TView2 : Element, IView where TView3 : Element, IView where TView4 : Element, IView
        {
            return RegisterTabbedView(typeof(TContainer), new[] { typeof(TView1), typeof(TView2), typeof(TView3), typeof(TView4) });
        }

        public IViewDependencyContainer RegisterTabbedView<TContainer, TView1, TView2, TView3, TView4, TView5>() where TContainer : MultiPage<Page> where TView1 : Element, IView where TView2 : Element, IView where TView3 : Element, IView where TView4 : Element, IView where TView5 : Element, IView
        {
            return RegisterTabbedView(typeof(TContainer), new[] { typeof(TView1), typeof(TView2), typeof(TView3), typeof(TView4), typeof(TView5) });
        }

        public IViewDependencyContainer RegisterTabbedView(Type containerType, params Type[] viewTypes)
        {
            
            throw new NotImplementedException();
        }
    }
}
