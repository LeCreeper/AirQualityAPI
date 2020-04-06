using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace AirQualityAPI__.NetFramework.Models
{
    public class AirDataContext
    {

        public IMongoDatabase MongoDB;

        public AirDataContext()
        {
            var Client = new MongoClient();
            MongoDB = Client.GetDatabase("AirQualityDB");
            var Collection = MongoDB.GetCollection<Measurements>("Measurements");
        }
    }
}