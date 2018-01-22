using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CurrenciesRate
{

    public class BidAskPair
    {
        [BsonId]
        public string _id { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
        public string exchanger { get; set; }
        public UInt32 time { get; set; }

        public BidAskPair()
        {
            bid = ask = 0;
            time = (UInt32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public BidAskPair(double bid, double ask, string exchanger)
        {
            this.bid = bid;
            this.ask = ask;
            this.exchanger = exchanger;
            time = (UInt32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
