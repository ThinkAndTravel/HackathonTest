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
    public class MongoController
    {
        MongoClient client;
        IMongoDatabase db;
        IMongoCollection<BidAskPair> Rates;
        public void Connect()
        {
            client = new MongoClient("mongodb://admin:121314qw@ds046377.mlab.com:46377/bitcoin");
            db = client.GetDatabase("bitcoin");
            Rates = db.GetCollection<BidAskPair>("Rates");
        }
        public void Add(BidAskPair rate)
        {
            Rates.InsertOne(rate);
        }
        public List<BidAskPair> Find(String excahnger)
        {
            var filter = new BsonDocument("excahger", excahnger);

            var q = Rates.FindSync(filter);
            return q.ToList();
        }
    }
}
