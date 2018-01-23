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
        /// <summary>
        /// Returns  list of BidAskPair sorted by time field
        /// or empry list, if some error occurs
        /// </summary>
        /// <returns></returns>
        public static async Task<List<BidAskPair>> Last24hPoints()
        {
            try
            {
                var url = Settings.App_Uri + @"Home/Last24hInfo";
                using (var handler = new HttpClientHandler { UseDefaultCredentials = true })
                using (var client = new HttpClient(handler))
                {
                    var result = await client.GetStringAsync(url);
                    var tx = result;
                }

                /*
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Settings.App_Uri + @"Home /Last24hInfo");
                HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());

                using (Stream stream = response.GetResponseStream())
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
