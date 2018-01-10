using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using YG.View;

namespace YG.Registration
{
    public class ViewDependencyContainer : IViewDependencyContainer
    {
        private readonly Dictionary<Type, Item> _items = new Dictionary<Type, Item>();

        public IReadOnlyDictionary<Type, Item> Items => _items;

        public void Setup(Action<IViewDependencyContainer> setupAction)
        {
            setupAction(this);
        }

        public IViewDependencyContainer RegisterTabbedView<TContainer, TView1, TView2>() where TContainer : class where TView1 : Element, IView where TView2 : Element, IView
        {
            return RegisterTabbedView(typeof(TContainer), new[] { typeof(TView1), typeof(TView2) });
        }

        public IViewDependencyContainer RegisterTabbedView<TContainer, TView1, TView2, TView3>() where TContainer : class where TView1 : Element, IView where TView2 : Element, IView where TView3 : Element, IView
        {
            return RegisterTabbedView(typeof(TContainer), new[] { typeof(TView1), typeof(TView2), typeof(TView3) });
        }

        public IViewDependencyContainer RegisterTabbedView<TContainer, TView1, TView2, TView3, TView4>() where TContainer : class where TView1 : Element, IView where TView2 : Element, IView where TView3 : Element, IView where TView4 : Element, IView
        {
            return RegisterTabbedView(typeof(TContainer), new[] { typeof(TView1), typeof(TView2), typeof(TView3), typeof(TView4) });
        }

        public IViewDependencyContainer RegisterTabbedView<TContainer, TView1, TView2, TView3, TView4, TView5>() where TContainer : class where TView1 : Element, IView where TView2 : Element, IView where TView3 : Element, IView where TView4 : Element, IView where TView5 : Element, IView
        {
            return RegisterTabbedView(typeof(TContainer), new[] { typeof(TView1), typeof(TView2), typeof(TView3), typeof(TView4), typeof(TView5) });
        }

        public IViewDependencyContainer RegisterTabbedView(Type containerType, params Type[] viewTypes)
        {
            var parentItem = new Item { Children = new LinkedList<Type>(viewTypes) };
            _items.Add(containerType, parentItem);

            viewTypes.ForEach(type => _items.Add(type, new Item { Parrent = containerType }));

            return this;
        }
    }
}

public class Item
{
    public Type Parrent { get; set; }
    public LinkedList<Type> Children { get; set; }
}
