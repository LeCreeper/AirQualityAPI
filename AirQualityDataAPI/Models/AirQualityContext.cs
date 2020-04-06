using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace AirQualityDataAPI.Models
{
    public class AirQualityContext
    {
        public IMongoDatabase MongoDB;

        public AirQualityContext()
        {
            var Client = new MongoClient();
            MongoDB = Client.GetDatabase("AirQualityDB");
            var Collection = MongoDB.GetCollection<Measurements>("MeasurementsFinal");

        }
        public IMongoCollection<Measurements> Measurements
        {
            get { return MongoDB.GetCollection<Measurements>("MeasurementsFinal"); }
        }
    }
}