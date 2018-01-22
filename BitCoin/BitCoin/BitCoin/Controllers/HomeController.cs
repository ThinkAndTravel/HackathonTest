using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BitCoin.Models;
using CurrenciesRate;

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
                foreach (var rate in rates)
                {

                }

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
