using BitCoin.Xam.Navigation.Services;
using Unity;

namespace BitCoin.Xam.ViewModel.Base
{
    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<MainViewModel>();
            
            // Services     
            _container.RegisterType<INavigationService, NavigationService>();
        }
        
       
        public MainViewModel MainViewModel {
            get { return _container.Resolve<MainViewModel>(); }
        }
        
    }
}
