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
using System.Threading.Tasks;

namespace BitCoin.Xam.ViewModel
{
    public static class Profit
    {
        public class Dot
        {
            public double x { get; set; }
            public double y { get; set; } 
        }

        public static List<Dot> CalcProfit()
        {
            List<Dot> result = new List<Dot>();

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

            for(int i = list.Count - 1; i >= 0; --i)
            {
                list[i].time -= list[0].time;
            }

            for(int i = 0; i < list.Count; ++i)
            {
                double max_sell_price = list[i].bid;
                string sell_where, buy_where;
                double min_buy_price = list[i].ask;
                sell_where = buy_where = list[i].exchanger;

                while(i + 1 < list.Count && list[i + 1].time - list[i].time <= 30)
                {
                    ++i;
                    if(max_sell_price < list[i].bid)
                    {
                        max_sell_price = list[i].bid;
                        sell_where = list[i].exchanger;
                    }
                    if(min_buy_price > list[i].ask)
                    {
                        min_buy_price = list[i].ask;
                        buy_where = list[i].exchanger;
                    }
                }

                double btc = 1.0;
                double usd = 0.0;
                double profit = 0.0;
                
                btc -= Services.FeeManager.Deposit.DepositBtc(btc, sell_where);
                usd = btc * max_sell_price;
                btc = 0;

                usd -= Services.FeeManager.Withdraw.WithdrawUsd(usd, sell_where);
                usd -= Services.FeeManager.Deposit.DepositUsd(usd, buy_where);
                
                if(usd <= min_buy_price)
                {
                    //zero profit
                }
                else
                {
                    profit = usd - min_buy_price;
                    profit -= Services.FeeManager.Withdraw.WithdrawUsd(profit, buy_where);
                    profit = Math.Max(profit, 0);
                }

                result.Add(new Dot()
                {
                    x = list[i].time,
                    y = profit + (result.Count > 0 ? result[result.Count - 1].y : 0),
                });
            }
            return result;
        }
    }
}
