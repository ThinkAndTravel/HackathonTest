using BitCoin.Xam.Navigation.Services;
using Unity;

namespace BitCoin.Xam.ViewModel.Base
{
    public class ViewModelLocator
    {
        public readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<MainViewModel>();
            _container.RegisterType<AreaViewModel>();
            _container.RegisterType<ProfitViewModel>();
            // Services     
            _container.RegisterType<INavigationService, NavigationService>();
        }
        
       
        public MainViewModel MainViewModel {
            get { return _container.Resolve<MainViewModel>(); }
        }

       public  AreaViewModel AreaViewModel {
            get { return _container.Resolve<AreaViewModel>(); }
        }
        public ProfitViewModel ProfitViewModel
        {
            get { return _container.Resolve<ProfitViewModel>(); }
        }
    }
}
