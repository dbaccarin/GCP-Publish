using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models
{
    [BsonIgnoreExtraElements]
    public class Movie
    {
        //[BsonId]
        //public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Runtime { get; set; }

        public DateTime Released { get; set; }
    }
}
