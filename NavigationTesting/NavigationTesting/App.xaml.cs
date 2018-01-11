using System.Reflection;
using Autofac;
using NavigationTesting.ViewModels;
using NavigationTesting.Views;
using NavigationTesting.Views.TabViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YG.Navigation;
using YG.Registration;
using YG.ViewLocation;
using YGNaviagationService.AutofacViewResolver;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NavigationTesting
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetupIoC();

            var navService = new YGLService(new ViewLocator(new ViewDependencyContainer(), new SimpleViewResolver()));
            navService.SetMainViewModel<SecondViewModel>();
        }

        private void SetupIoC()
        {
            var viewContainer = new ViewDependencyContainer();
            viewContainer.Setup(container => container.RegisterTabbedView<TabbedView, FirstView, SecondView, ThirdView, FourthView>());

            var builder = new ContainerBuilder();

            builder.RegisterMvvmComponents(GetType().GetTypeInfo().Assembly);
            builder.RegisterInstance(viewContainer).SingleInstance();
            builder.RegisterType<AutofacViewResolver>().As<IViewResolve>().SingleInstance();
            builder.RegisterType<ViewLocator>().As<IViewLocation>().SingleInstance();
            builder.RegisterType(typeof(NavigationService)).As<INavigationService>().SingleInstance();

            Container = builder.Build();
        }

        public IContainer Container { get; private set; }
    }
}