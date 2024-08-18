using Autofac;
using LD.Desktop.CollectiveCheck.MVVM.Core;
using LD.Desktop.CollectiveCheck.MVVM.ViewModels;
using LD.Desktop.CollectiveCheck.MVVM.Views;
using LD.Desktop.CollectiveCheck.Services.Implementations;
using LD.Desktop.CollectiveCheck.Services.Interfaces;
using System;

namespace LD.Desktop.CollectiveCheck.Services.DI
{
    public class AutofacConfig
    {
        public static IContainer GetConfiguredContainer()
        {
            var builder = new ContainerBuilder();

            //регистрация сервисов
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

            //регистрация фабрик
            builder.Register<Func<Type, BaseViewModel>>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return viewType => (BaseViewModel)context.Resolve(viewType);
            }).SingleInstance();

            //регистрация VM
            builder.RegisterType<MainWindowVM>().SingleInstance();
            builder.RegisterType<MainViewVM>().SingleInstance();

            builder.RegisterType<SomeViewVM>().SingleInstance();

            //регистрация главного окна
            builder.Register(c => new MainWindow { DataContext = c.Resolve<MainWindowVM>() }).SingleInstance();

            ////регистрация страниц
            //builder.RegisterType<ExitView>().SingleInstance();
            //builder.RegisterType<MainView>().SingleInstance();
            //builder.RegisterType<SettingsView>();

            return builder.Build();
        }
    }
}
