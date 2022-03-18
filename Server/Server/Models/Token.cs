using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Models
{
    public class Token
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }

        public string access_token { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public bool allegro_api { get; set; }
        public string jti { get; set; }
        public DateTime ExpiredDateTime { get; set; }

    }
}