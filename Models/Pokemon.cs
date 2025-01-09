using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace pokedex.Models
{
    public class Pokemon
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Ability { get; set; }
        public int? Level { get; set; }
    }
}
