using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BitCoin.Xam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var entries = new[]
            {
                 new Microcharts.Entry(11100)
                 {
                    Label = "1",
                   // ValueLabel = "200",
                 },
                 new Microcharts.Entry(12200)
                 {
                    Label = "2",
                   // ValueLabel = "200",
                 },
                 new Microcharts.Entry(110)
                 {
                    Label = "3",
                   // ValueLabel = "200",
                 },
                 new Microcharts.Entry(120)
                 {
                    Label = "4",
                   // ValueLabel = "200",
                 },
                 new Microcharts.Entry(110)
                 {
                    Label = "5",
                   // ValueLabel = "200",
                 },
                 new Microcharts.Entry(10)
                 {
                    Label = "6",
                   // ValueLabel = "200",
                 }

            };

            var _chart = new LineChart()
            {
                Entries = entries,
                
            };
            // _chart.MinValue = 9000;
            this.chart.Chart = _chart;
        }
        protected override void OnAppearing()
        {

            base.OnAppearing();

           // var entries = new[]
           // {
           //      new Microcharts.Entry(200)
           //      {
           //         Label = "January",
           //         ValueLabel = "200",
           //      },
           //      new Microcharts.Entry(200)
           //      {
           //         Label = "January",
           //         ValueLabel = "200",
           //      }

           // };

           // var _chart = new LineChart()
           // {
           //     Entries = entries,
           //     LineMode = LineMode.Straight,
           //     LineSize = 8,
           //     PointMode = PointMode.Square,
           //     PointSize = 18,
           // };
           //// _chart.MinValue = 9000;
           // this.chart.Chart = _chart;
        }
    }
}