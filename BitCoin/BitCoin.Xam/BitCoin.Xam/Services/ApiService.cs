using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Settings.App_Uri + @"Home/Last24hInfo");
                HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());

                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var str = await reader.ReadToEndAsync();
                    var list = JsonConvert.DeserializeObject<List<BidAskPair>>(str);
                    list.Sort((a, b) => a.time.CompareTo(b.time));
                    return list;
                }
            }catch(Exception e)
            {
                return new List<BidAskPair>();
            }
        }
    }
}
