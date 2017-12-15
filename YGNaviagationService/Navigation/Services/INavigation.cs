using Xamarin.Forms;

namespace YG.Navigation.Services
{
    public interface INavigation<out TPage> : IPageContainer<TPage> where TPage : Page
    { }
}
