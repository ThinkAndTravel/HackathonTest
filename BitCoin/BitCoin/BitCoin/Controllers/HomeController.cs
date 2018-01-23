using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CurrenciesRate;
using BitCoinWeb.Controllers;

namespace BitCoin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UpdateRates()
        {
            try
            {
                var rates = await GetRate.GetAll();
              

                MongoController.Connect();

                foreach (var rate in rates)
                {
                    MongoController.Add(rate);    
                }

                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        public async Task<List<BidAskPair>> Last24hInfo()
        {
            MongoController.Connect();
            var info = await MongoController.Last24h();
            return info;
        }

    }
}
