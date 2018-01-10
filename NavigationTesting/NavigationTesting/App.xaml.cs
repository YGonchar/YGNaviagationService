using NavigationTesting.ViewModels;
using NavigationTesting.Views;
using NavigationTesting.Views.TabViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YG.Navigation;
using YG.Registration;
using YG.ViewLocation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NavigationTesting
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var viewContainer = new ViewDependencyContainer();

            viewContainer.Setup(container => container.RegisterTabbedView<TabbedView, FirstView, SecondView, ThirdView, FourthView>());

            var navService = new YGLService(new ViewLocator(new ViewDependencyContainer()));
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            //navService.SetMainViewModel<SecondViewModel>();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }
    }
}