using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQualityAPI.Models;
using MongoDB.Driver;

namespace AirQualityAPI.Services
{
    public class MeasurementService
    {
        private readonly IMongoCollection<Measurements> _measurements;

        public MeasurementService(IAirQualityDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _measurements = database.GetCollection<Measurements>(settings.MeasurementCollectionName);
        }

        public List<Measurements> Get()
        {
            return _measurements.Find(measurements => true).ToList();
        }

        public Measurements Get(string id) =>
            _measurements.Find<Measurements>(measurement => measurement.ID == id).FirstOrDefault();

        public Measurements Create(Measurements measurement)
        {
            _measurements.InsertOne(measurement);
            return measurement;
        }

        public void Update(string id, Measurements measurementIn) =>
            _measurements.ReplaceOne(measurement => measurement.ID == id, measurementIn);

        public void Remove(Measurements measurementIn) =>
            _measurements.DeleteOne(measurement => measurement.ID == measurementIn.ID);

        public void Remove(string id) =>
            _measurements.DeleteOne(measurement => measurement.ID == id);

    }
}
