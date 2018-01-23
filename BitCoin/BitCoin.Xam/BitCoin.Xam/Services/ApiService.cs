using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BitCoin.Xam.Services
{
    public static class ApiService
    {
        static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        /// <summary>
        /// Returns  list of BidAskPair sorted by time field
        /// or empry list, if some error occurs
        /// </summary>
        /// <returns></returns>
        public static async Task<List<BidAskPair>> Last24hPoints()
        {
            try
            {
                var client = GetClient();
                //  var request = WebRequest.Create(Settings.App_Uri + @"Home/Last24hInfo");
                var response = await client.GetAsync(Settings.App_Uri + @"Home/Last24hInfo");
                /*using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var str = await reader.ReadToEndAsync();
                    var list = JsonConvert.DeserializeObject<List<BidAskPair>>(str);
                    list.Sort((a, b) => a.time.CompareTo(b.time));
                    return list;
                }*/
                return new List<BidAskPair>();
            }
            catch(Exception e)
            {
                return new List<BidAskPair>();
            }
        }
    }
}
