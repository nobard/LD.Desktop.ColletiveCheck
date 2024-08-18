using LD.Desktop.CollectiveCheck.MVVM.Core;
using LD.Desktop.CollectiveCheck.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Desktop.CollectiveCheck.MVVM.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {
        public INavigationService NavigationService { get; }

        public MainWindowVM(INavigationService navService)
        {
            NavigationService = navService;

            NavigationService.NavigateTo<MainViewVM>();
        }
    }
}
