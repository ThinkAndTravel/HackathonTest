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


        public ProfitView ()
		{
			InitializeComponent ();
		}
	}
}