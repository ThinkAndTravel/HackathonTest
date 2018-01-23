using System;
using System.Collections.Generic;
using System.Text;

namespace BitCoin.Xam.Navigation.Services
{
    public interface INavigationService
    {
        void NavigateTo<TDestinationViewModel>(object navigationContext = null);

        void NavigateTo(Type destinationType, object navigationContext = null);

        void NavigateBack();
    }
}
