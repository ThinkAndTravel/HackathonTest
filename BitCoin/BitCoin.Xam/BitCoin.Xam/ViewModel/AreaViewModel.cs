using System;
using System.Collections.Generic;
using System.Text;
using OxyPlot;
using OxyPlot.Series;
using BitCoin.Xam.ViewModel.Base;
using BitCoin.Xam.Services;

namespace BitCoin.Xam.ViewModel
{
    public class AreaViewModel : ViewModelBase
    {
        private PlotModel _plotModel;

        public PlotModel PlotModel {
            get { return _plotModel; }
            set {
                _plotModel = value;
                RaisePropertyChanged();
            }
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);

            PlotModel = new PlotModel
            {
                Title = "Area"
            };

            var areaSerie = new AreaSeries
            {
                StrokeThickness = 2.0
            };
            List<BidAskPair> list = new List<BidAskPair>();
          
            double[] Bid = Array.ConvertAll(new double[1450], v => -1.0);
            double[] Ask = Array.ConvertAll(new double[1450], v => -1.0);

            list = ApiService.Last24hPoints().Result;
            var t = list[0].time;
            foreach (var a in list)
            {
                DateTime time = DateTimeOffset.FromUnixTimeSeconds(a.time-t).DateTime;
                int i = time.Hour * 60 + time.Minute;
                if (Bid[i] == -1) Bid[i] = a.bid; else Bid[i] = System.Math.Max(Bid[i], a.bid);
                if (Ask[i] == -1) Ask[i] = a.ask; else Ask[i] = System.Math.Min(Ask[i], a.ask);
            }
            for (int i = 0; i < 1440; i++)
            {
                areaSerie.Points.Add(new DataPoint(i, Bid[i]));
                areaSerie.Points2.Add(new DataPoint(i, Ask[i]));
            }

            PlotModel.Series.Add(areaSerie);
        }
    }
}