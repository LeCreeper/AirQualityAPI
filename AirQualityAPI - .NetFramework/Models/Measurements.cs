using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQualityAPI__.NetFramework.Models
{
    [BsonIgnoreExtraElements]
    public class Measurements
    {
        //BsonId identifies this as a primary key
        //BsonRepresentation allows the program to auto-convert
        //the string to an ObjectId
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }



        public string RåResultat { get; set; }


        public string Enhedsnavn { get; set; }


        public string Stofnavn { get; set; }

        public string Datomærke { get; set; }

        public string Målestedsnavn { get; set; }

        public string ProduktId { get; set; }


        public override string ToString()
        {
            return $"{nameof(ID)}: {ID}, {nameof(RåResultat)}: {RåResultat}, {nameof(Enhedsnavn)}: {Enhedsnavn}, {nameof(Stofnavn)}: {Stofnavn}, {nameof(Datomærke)}: {Datomærke}, {nameof(Målestedsnavn)}: {Målestedsnavn}, {nameof(ProduktId)}: {ProduktId}";
        }
    }
}