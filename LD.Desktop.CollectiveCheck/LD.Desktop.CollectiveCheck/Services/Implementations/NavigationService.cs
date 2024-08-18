using LD.Desktop.CollectiveCheck.MVVM.Core;
using LD.Desktop.CollectiveCheck.Services.Interfaces;
using System;

namespace LD.Desktop.CollectiveCheck.Services.Implementations
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private BaseViewModel _currentView;

        public BaseViewModel CurrentView
        {
            get => _currentView;
            private set => SetProperty(ref _currentView, value);
        }

        private readonly Func<Type, BaseViewModel> viewModelFactory;

        public NavigationService(Func<Type, BaseViewModel> vmFactory)
        {
            viewModelFactory = vmFactory;
        }

        public void NavigateTo<T>()
            where T : BaseViewModel
        {
            var view = viewModelFactory.Invoke(typeof(T));
            CurrentView = view;
        }

        public void NavigateTo<T>(Action<T> action)
            where T : BaseViewModel
        {
            NavigateTo<T>();
            action.Invoke((T)CurrentView);
        }
    }
}
