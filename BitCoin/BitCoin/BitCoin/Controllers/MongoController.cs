﻿using System;
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
        public static MongoClient client = null;
        public static IMongoDatabase db = null;
        public static IMongoCollection<BidAskPair> Rates = null;
        public static void Connect()
        {
            if (client != null && db != null && Rates != null) return;
            client = new MongoClient("mongodb://admin:121314qw@ds111608.mlab.com:11608/bitcoin");
            db = client.GetDatabase("bitcoin");
            Rates = db.GetCollection<BidAskPair>("Rates");
        }
        public static async void Add(BidAskPair rate)
        {
            await Rates.InsertOneAsync(rate);
        }
        public static async Task<List<BidAskPair>> Find(String exchanger)
        {
            var filter = new BsonDocument("exchanger", exchanger);

            var q = await Rates.FindAsync(filter);
            return q.ToList();
        }

        public static async Task<List<BidAskPair>> Last24h()
        {
            var now = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var filter = new BsonDocument("time", new BsonDocument("$gte", now - 24 * 60 * 60));
            var q = await Rates.FindAsync(filter);
            var l = q.ToList();
            return l;
        }
    }
}
