using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceProcessor.MongoDB.Contracts.Entities
{
	public class Tag
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		[BsonIgnoreIfDefault]
		public string Id { get; set; }
		public string Name { get; set; }
	}
}
