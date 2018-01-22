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
    public partial class AreaView : ContentPage
    {
        public object Parameter { get; set; }

        public AreaView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;

            BindingContext = App.Locator.AreaViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var areaViewModel = BindingContext as AreaViewModel;
            if (areaViewModel != null) areaViewModel.OnAppearing(Parameter);
        }
    }
}