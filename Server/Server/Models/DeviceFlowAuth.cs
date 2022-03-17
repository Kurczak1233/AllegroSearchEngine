using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class DeviceFlowAuth
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string user_code { get; set; }
        public string device_code { get; set; }
        public int expires_in { get; set; }
        public int interval { get; set; }
        public string verification_uri { get; set; }
        public string verification_uri_complete { get; set; }
    }
}
