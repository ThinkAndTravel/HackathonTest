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
            double bid = double.Parse(dict["bid"].Replace(".", ","));
            double ask = double.Parse(dict["ask"].Replace(".", ","));
            return new BidAskPair(bid , ask, "bitstamp");
        }

        /// <summary>
        /// Returns rate from bitfinex
        /// </summary>
        /// <returns></returns>
        public static async Task<BidAskPair> GetBitfinex()
        {
            var response = await GetApiResponse(@"https://api.bitfinex.com/v1/pubticker/btcusd");
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            double bid = double.Parse(dict["bid"].Replace(".", ","));
            double ask = double.Parse(dict["ask"].Replace(".", ","));
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
            var bid = double.Parse((dict.Result["XXBTZUSD"]["bids"][0][0] as string).Replace(".", ","));
            var ask = double.Parse((dict.Result["XXBTZUSD"]["asks"][0][0] as string).Replace(".", ","));
            return new BidAskPair(bid, ask, "kraken");
        }

        /// <summary>
        /// Model for kraken
        /// </summary>
        private class KrakenModel
        {
            public List<Object> Error { get; set; }
            public Dictionary<String , Dictionary<String , List<List<Object>>>> Result { get; set; }
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
    }
}
