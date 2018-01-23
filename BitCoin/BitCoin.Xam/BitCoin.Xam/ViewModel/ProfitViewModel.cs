using System;
using System.Collections.Generic;
using System.Text;
using OxyPlot;
using OxyPlot.Series;
using BitCoin.Xam.ViewModel.Base;
using System.Net.Http;
using BitCoin.Xam.Services;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace BitCoin.Xam.ViewModel
{
   public  class ProfitViewModel: ViewModelBase
    {
      
        private PlotModel _plotModelProfit;

        public PlotModel PlotModelProfit
        {
            get { return _plotModelProfit; }
            set
            {
                _plotModelProfit = value;
                RaisePropertyChanged();
            }
        }
        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);

            PlotModelProfit = new PlotModel
            {
                Title = "Profit"
            };
            var areaSerieProfit = new AreaSeries
            {
                StrokeThickness = 2.0
            };
            List<Profit.Dot> listProfit = new List<Profit.Dot>();
            listProfit = Profit.CalcProfit();
            double[] profit = Array.ConvertAll(new double[1450], v => -1.0);
            foreach (var a in listProfit)
            {
                DateTime time = DateTimeOffset.FromUnixTimeSeconds((long)a.x).DateTime;
                int i = time.Hour * 60 + time.Minute;
                if (profit[i] == -1) profit[i] = a.y;
            }
            for (int i = 0; i < 1440; i++)
            {
                if (profit[i] != -1)
                {
                    areaSerieProfit.Points.Add(new DataPoint(i / 60.0, profit[i]));
                    areaSerieProfit.Points2.Add(new DataPoint(i / 60.0, profit[i]));
                }
            }

            PlotModelProfit.Series.Add(areaSerieProfit);
        }
    }
}