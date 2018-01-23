using BitCoin.Xam.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BitCoin.Xam.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfitView : ContentPage
	{
        public object Parameter { get; set; }

        public ProfitView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;

            BindingContext = App.Locator.ProfitViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var areaViewModel = BindingContext as ProfitViewModel;
            if (areaViewModel != null) areaViewModel.OnAppearing(Parameter);
        }
    }
}