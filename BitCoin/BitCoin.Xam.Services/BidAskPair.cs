using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoin.Xam.Services
{
    public class BidAskPair
    {
        public string _id { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
        public string exchanger { get; set; }
        public int time { get; set; }
    }
}
