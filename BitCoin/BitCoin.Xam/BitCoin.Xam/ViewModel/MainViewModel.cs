using BitCoin.Xam.Navigation.Services;
using BitCoin.Xam.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BitCoin.Xam.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private ICommand _areaCommand;
        private ICommand _profitCommand;

        private INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand AreaCommand {
            get { return _areaCommand = _areaCommand ?? new DelegateCommand(AreaCommandExecute); }
        }
        private void AreaCommandExecute()
        {
            _navigationService.NavigateTo<AreaViewModel>();
        }

        public ICommand ProfitCommand {
            get { return _areaCommand = _areaCommand ?? new DelegateCommand(ProfitCommandExecute); }
        }
        private void ProfitCommandExecute()
        {
            _navigationService.NavigateTo<ProfitViewModel>();
        }


    }
}
