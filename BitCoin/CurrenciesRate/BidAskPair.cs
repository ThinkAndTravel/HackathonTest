﻿using System;

namespace CurrenciesRate
{
    public class BidAskPair
    {
        public double bid { get; set; }
        public double ask { get; set; }
        public UInt32 time { get; set; }

        public BidAskPair()
        {
            bid = ask = 0;
            time = (UInt32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public BidAskPair(double bid, double ask)
        {
            this.bid = bid;
            this.ask = ask;
            time = (UInt32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
