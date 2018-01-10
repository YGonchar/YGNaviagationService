using System;
using System.Collections.Generic;
using Xamarin.Forms;
using YG.View;

namespace YG.Registration
{
    public interface IViewDependencyContainer : IFluentInterface
    {
        IReadOnlyDictionary<Type, Item> Items { get; }

        void Setup(Action<IViewDependencyContainer> setupAction);

        #region Tabbed page registration
        IViewDependencyContainer RegisterTabbedView<TContainer, TView1, TView2>()
           where TContainer : class //MultiPage<Page>
           where TView1 : Element, IView
           where TView2 : Element, IView;

        IViewDependencyContainer RegisterTabbedView<TContainer, TView1, TView2, TView3>()
            where TContainer : class //MultiPage<Page>
            where TView1 : Element, IView
            where TView2 : Element, IView
            where TView3 : Element, IView;

        IViewDependencyContainer RegisterTabbedView<TContainer, TView1, TView2, TView3, TView4>()
            where TContainer : class //MultiPage<Page>
            where TView1 : Element, IView
            where TView2 : Element, IView
            where TView3 : Element, IView
            where TView4 : Element, IView;

        IViewDependencyContainer RegisterTabbedView<TContainer, TView1, TView2, TView3, TView4, TView5>()
            where TContainer : class //MultiPage<Page>
            where TView1 : Element, IView
            where TView2 : Element, IView
            where TView3 : Element, IView
            where TView4 : Element, IView
            where TView5 : Element, IView;

        IViewDependencyContainer RegisterTabbedView(Type containerType, params Type[] viewTypes);
        #endregion
    }
}
