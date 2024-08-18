using LD.Desktop.CollectiveCheck.MVVM.Core;
using System;

namespace LD.Desktop.CollectiveCheck.Services.Interfaces
{
    public interface INavigationService
    {
        BaseViewModel CurrentView { get; }

        void NavigateTo<T>()
            where T : BaseViewModel;

        void NavigateTo<T>(Action<T> action)
            where T : BaseViewModel;
    }
}
