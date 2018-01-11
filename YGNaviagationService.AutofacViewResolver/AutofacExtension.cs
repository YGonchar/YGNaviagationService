using System.Linq;
using System.Reflection;
using Autofac;
using YG.View;
using YG.ViewLocation;
using YG.ViewModel;

namespace YGNaviagationService.AutofacViewResolver
{
    public static class AutofacExtension
    {
        public static ContainerBuilder RegisterMvvmComponents(this ContainerBuilder builder,
            params Assembly[] assemblies)
        {
            builder
                .RegisterType<ViewLocator>()
                .As<IViewLocation>()
                .SingleInstance();

            builder
                .RegisterViewModels(assemblies)
                .RegisterViews(assemblies);

            return builder;
        }

        public static ContainerBuilder RegisterViewModels(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            builder
                .RegisterAssemblyTypes(assemblies)
                .Where(x =>
                    x.GetTypeInfo().IsClass &&
                    x.GetTypeInfo().ImplementedInterfaces.Any(y => y == typeof(IViewModel)))
                .InstancePerDependency();

            return builder;
        }


        public static ContainerBuilder RegisterViews(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            builder
                .RegisterAssemblyTypes(assemblies)
                .Where(x =>
                    x.GetTypeInfo().IsClass &&
                    x.GetTypeInfo().ImplementedInterfaces.Any(i => i == typeof(IView)))
                .InstancePerDependency();

            return builder;
        }
    }
}
