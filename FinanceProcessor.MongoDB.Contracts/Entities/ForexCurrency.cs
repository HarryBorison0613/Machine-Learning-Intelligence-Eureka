using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceProcessor.MongoDB.Contracts.Entities
{
	public class ForexCurrency
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		[BsonIgnoreIfDefault]
		public string Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public int IsCrypto { get; set; }
	}
}
