using BitCoin.Xam.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BitCoin.Xam
{
    public static class Palku_v_glaz_ili_v_api_raz
    {
        public static async System.Threading.Tasks.Task<List<Services.BidAskPair>> Last24hPoints()
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
                return new List<Services.BidAskPair>();
            }
            catch (Exception e)
            {
                return new List<Services.BidAskPair>();
            }
        }
    }
}
