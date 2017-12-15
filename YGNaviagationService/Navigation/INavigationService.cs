using System.Collections.Generic;
using System.Threading.Tasks;
using YG.Controllers;
using YG.ViewModel;

namespace YG.Navigation
{
    public interface INavigationService
    {
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);

        Task<string> DisplayActionSheet(string title, string cancel, string destruction, string[] buttons);

        Task SetMainViewModel<T>(object args = null) where T : IViewModel;

        Task NavigateToAsync<T>(object args = null) where T : IViewModel;

        Task ShowModalAsync<T>(object args = null) where T : IViewModel;

        void RemoveFromNavigationStack<T>(bool removeFirstOccurenceOnly = true) where T : IViewModel;

        Task PopAsync();

        Task HideModalAsync();

        Task PopToRootAsync();

        IReadOnlyList<IViewModel> GetNavigationStack();

        bool IsRootPage { get; }

        IViewController ViewController { get; }
    }
}
