using System.Threading.Tasks;

namespace YG.Navigation
{
    /// <summary>
    /// Navigation aware ViewModels behavior
    /// </summary>
    public interface INavigationAware
    {
        void OnNavigationFrom();

        Task OnNavigationTo(object param = null);
    }
}
