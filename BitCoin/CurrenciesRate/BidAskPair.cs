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
        public int time { get; set; }

        private static string alpha = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";

        private void setID()
        {
            Random random = new Random();
            _id = "";
            for(int i = 0; i < 16; ++i)
            {
                _id += alpha[random.Next() % alpha.Length];
            }
        }

        public BidAskPair()
        {
            setID();
            bid = ask = 0;
            time = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public BidAskPair(double bid, double ask, string exchanger)
        {
            setID();
            this.bid = bid;
            this.ask = ask;
            this.exchanger = exchanger;
            time = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
