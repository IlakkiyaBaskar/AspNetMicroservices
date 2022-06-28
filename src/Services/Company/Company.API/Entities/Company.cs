using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.Entities
{
    
    public class CompanyData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CompanyCode { get; set; }
        [BsonElement("CompanyName")]
        public string CompanyName { get; set; }
    }
}
