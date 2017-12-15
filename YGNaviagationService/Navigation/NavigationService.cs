using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using YG.Controllers;
using YG.Navigation.Services;
using YG.View;
using YG.ViewLocation;
using YG.ViewModel;
using IViewController = YG.Controllers.IViewController;

namespace YG.Navigation
{
    public abstract class NavigationService : INavigationService
    {
        public IList<INavigation<Page>> Navigations { get; set; }

        protected INavigation Navigation { get; private set; }
        protected readonly IViewLocation _viewLocator;

        public NavigationService(IViewLocation viewLocator)
        {
            _viewLocator = viewLocator;
            ViewController = new RootViewController();
        }

        public bool IsRootPage => Navigation.NavigationStack.Count == 1;

        public IViewController ViewController { get; }

        public IViewModel CurrentViewModel => CurrentPage?.BindingContext as IViewModel;

        public IView CurrentPage => Navigation?.NavigationStack?.LastOrDefault() as IView;

        public IReadOnlyList<IViewModel> GetNavigationStack()
        {
            return Navigation.NavigationStack.Select(page => page.BindingContext as IViewModel).ToList();
        }

        public async Task NavigateToAsync<T>(object args = null) where T : IViewModel
        {
            var pageBinding = GetView<T>(args);

            if (pageBinding == null)
            {
                var msg = args?.GetType() + " " + args;
                return;
            }

            await Navigation.PushAsync((Page)pageBinding);
            await PerformViewModelLifecycle((IViewModel)pageBinding.BindingContext, args);
        }

        public async Task ShowModalAsync<T>(object args = null) where T : IViewModel
        {
            var pageBinding = GetView<T>(args);

            await Navigation.PushModalAsync((Page)pageBinding);
            await PerformViewModelLifecycle((IViewModel)pageBinding.BindingContext, args);
        }

        public async Task PopAsync()
        {
            await Navigation.PopAsync();
        }

        public async Task HideModalAsync()
        {
            await Navigation.PopModalAsync();
        }

        public async Task PopToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }

        public void RemoveFromNavigationStack<T>(bool removeFirstOccurenceOnly = true) where T : IViewModel
        {
            Type pageType = _viewLocator.FindViewType(typeof(T));

            var navigationStack = Navigation.NavigationStack.Reverse();

            foreach (var page in navigationStack)
            {
                if (page.GetType() == pageType)
                {
                    Navigation.RemovePage(page);

                    if (removeFirstOccurenceOnly)
                    {
                        break;
                    }
                }
            }
        }

        public IView GetView<T>(object args = null) where T : IViewModel
        {
            var page = _viewLocator.FindView(typeof(T));

            return page;
        }

        public abstract Task<bool> DisplayAlert(string title, string message, string accept, string cancel);

        public abstract Task<string> DisplayActionSheet(string title, string cancel, string destruction, string[] buttons);

        public async Task SetMainViewModel<T>(object args = null) where T : IViewModel
        {
            var pageBinding = _viewLocator.FindView(typeof(T));

            if (pageBinding == null)
            {
                throw new Exception("Resolve page for " + typeof(T).Name + " returned null!");
            }
            if (Application.Current.MainPage == null)
            {
                var navigationPage = new NavigationPage((Page)pageBinding);
                Navigation = navigationPage.Navigation;
                Application.Current.MainPage = navigationPage;
            }
            else
            {
                await Navigation.PushAsync((Page)pageBinding);
                ClearNavigationStack();
            }

            (pageBinding as IViewModel).InitAsync();
        }

        private void ClearNavigationStack()
        {
            for (int i = 0; i < Navigation.NavigationStack.Count - 1; i++)
                Navigation.RemovePage(Navigation.NavigationStack[i]);
        }

        private async Task PerformViewModelLifecycle(IViewModel newViewModel, object args = null)
        {
            await Task.Run(async () =>
            {
                (CurrentViewModel as INavigationAware)?.OnNavigationFrom();

                var onNavigationTo = (newViewModel as INavigationAware)?.OnNavigationTo(args);
                if (onNavigationTo != null)
                    await onNavigationTo;

                newViewModel.InitAsync();
            });
        }
    }
}
