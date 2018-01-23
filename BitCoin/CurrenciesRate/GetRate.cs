using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CurrenciesRate
{
    public static class GetRate
    {
        /// <summary>
        /// Returns an array of rates from all three exchangers
        /// </summary>
        /// <returns></returns>
        public static async Task<BidAskPair[]> GetAll()
        {
            var arr = new BidAskPair[3];
            arr[0] = await GetBitstamp();
            arr[1] = await GetBitfinex();
            arr[2] = await GetKraken();
            return arr;
        }

        /// <summary>
        /// Returns rate from bitstamp
        /// </summary>
        /// <returns></returns>
        public static async Task<BidAskPair> GetBitstamp()
        {
            var response = await GetApiResponse(@"https://www.bitstamp.net/api/ticker/");
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            //double bid = double.Parse(dict["bid"].Replace(".", ","));
            //double ask = double.Parse(dict["ask"].Replace(".", ","));
            var bid = toDouble(dict["bid"]);
            var ask = toDouble(dict["ask"]);
            return new BidAskPair(bid, ask, "bitstamp");
        }

        /// <summary>
        /// Returns rate from bitfinex
        /// </summary>
        /// <returns></returns>
        public static async Task<BidAskPair> GetBitfinex()
        {
            var response = await GetApiResponse(@"https://api.bitfinex.com/v1/pubticker/btcusd");
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            //    double bid = double.Parse(dict["bid"].Replace(".", ","));
            //    double ask = double.Parse(dict["ask"].Replace(".", ","));
            var bid = toDouble(dict["bid"]);
            var ask = toDouble(dict["ask"]);
            return new BidAskPair(bid, ask, "bitfinex");
        }

        /// <summary>
        /// Returns rate from kraken
        /// </summary>
        /// <returns></returns>
        public static async Task<BidAskPair> GetKraken()
        {
            var response = await GetApiResponse(@"https://api.kraken.com/0/public/Depth?pair=XXBTZUSD");
            var dict = JsonConvert.DeserializeObject<KrakenModel>(response);
            //    var bid = double.Parse((dict.Result["XXBTZUSD"]["bids"][0][0] as string).Replace(".", ","));
            //    var ask = double.Parse((dict.Result["XXBTZUSD"]["asks"][0][0] as string).Replace(".", ","));
            var bid = toDouble(dict.Result["XXBTZUSD"]["bids"][0][0] as string);
            var ask = toDouble(dict.Result["XXBTZUSD"]["asks"][0][0] as string);
            return new BidAskPair(bid, ask, "kraken");
        }

        /// <summary>
        /// Model for kraken
        /// </summary>
        private class KrakenModel
        {
            public List<Object> Error { get; set; }
            public Dictionary<String, Dictionary<String, List<List<Object>>>> Result { get; set; }
        }

        /// <summary>
        /// Returns response from api
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private static async Task<String> GetApiResponse(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        /// <summary>
        /// MS Azure, I really love you (no)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static double toDouble(string str)
        {
            str = str.Trim();
            double res = 0;
            int p = 0;
            while (p < str.Length && str[p] != '.' && str[p] != ',') ++p;
            if (p == str.Length) return Int32.Parse(str);
            for (int i = p - 1, j = 0; i >= 0 + (str[0] != '-' ? 0 : 1); --i, ++j) res += Math.Pow(10, j) * (str[i] - '0');
            for (int i = p + 1, j = 1; i < str.Length; ++i, ++j) res += 1.0 * (str[i] - '0') / Math.Pow(10, j);
            if (str[0] == '-') res *= -1;
            return res;
        }
    }

}

