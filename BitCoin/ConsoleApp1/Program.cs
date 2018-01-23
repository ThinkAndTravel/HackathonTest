using CurrenciesRate;
using MongoDB.Bson;
using MongoDB.Driver;
using System;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://admin:121314qw@ds111608.mlab.com:11608/bitcoin");
            var db = client.GetDatabase("bitcoin");
            var Rates = db.GetCollection<BidAskPair>("Rates");


            var filter = new BsonDocument("ask", new BsonDocument("$gte", 20000.0));
            var q = Rates.FindSync(filter);

            foreach(var e in q.ToList())
            {
                //var filter2 = Builders<BsonDocument>.Filter.Eq("_id", e._id);
                var filter2 = new BsonDocument("_id", e._id);
                double val = e.ask;
                while (val > 20000.0) val /= 10;
                //var upd = Builders<BsonDocument>.Update.Set("bid", val);
                var upd = Builders<BidAskPair>.Update.Set("ask", val);
                var res = Rates.UpdateOne(filter2, upd);
            }


            //   var e = GetRate.GetAll().GetAwaiter().GetResult();
            Console.WriteLine("Hello World!");
        }
    }
}
