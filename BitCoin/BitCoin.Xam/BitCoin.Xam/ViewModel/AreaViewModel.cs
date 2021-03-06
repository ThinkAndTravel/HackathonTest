﻿using System;
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
                Title = "Rate Bitcoin",
                
            };

            var areaSerie = new AreaSeries
            {
                StrokeThickness = 2.0,
               
            };
            List<BidAskPair> list = new List<BidAskPair>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Settings.App_Uri + @"Home/Last24hInfo");
            HttpWebResponse response = (HttpWebResponse)(request.GetResponseAsync().GetAwaiter().GetResult());

            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var str = reader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<BidAskPair>>(str);
                list.Sort((a, b) => a.time.CompareTo(b.time));

            }
          
            double[] Ask = Array.ConvertAll(new double[1450], v => -1.0);
            var t = list[0].time;
            foreach (var a in list)
            {
                DateTime time = DateTimeOffset.FromUnixTimeSeconds(a.time-t).DateTime;
                int i = time.Hour * 60 + time.Minute;
                if (Ask[i] == -1) Ask[i] = a.ask; else Ask[i] = System.Math.Min(Ask[i], a.ask);
            }
            for (int i = 0; i < 1440; i++)
            {
                if (Ask[i] != -1)
                {
                    areaSerie.Points.Add(new DataPoint(i / 60.0, Ask[i]));
                    areaSerie.Points2.Add(new DataPoint(i / 60.0, Ask[i]));
                }
            }

            PlotModel.Series.Add(areaSerie);
        
        }
    }
}