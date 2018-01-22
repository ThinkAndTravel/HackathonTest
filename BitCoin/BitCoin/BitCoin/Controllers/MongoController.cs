using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver;
using CurrenciesRate;

namespace BitCoinWeb.Controllers
{
    public static class MongoController
    {
        public static MongoClient client;
        public static IMongoDatabase db;
        public static IMongoCollection<BidAskPair> Rates;
        public static void Connect()
        {
            client = new MongoClient("mongodb://admin:121314qw@ds111608.mlab.com:11608/bitcoin");
            db = client.GetDatabase("bitcoin");
            Rates = db.GetCollection<BidAskPair>("Rates");
        }
        public static void Add(BidAskPair rate)
        {
            Rates.InsertOne(rate);
        }
        public static List<BidAskPair> Find(String exchanger)
        {
            var filter = new BsonDocument("exchanger", exchanger);

            var q = Rates.FindSync(filter);
            return q.ToList();
        }
    }
}
