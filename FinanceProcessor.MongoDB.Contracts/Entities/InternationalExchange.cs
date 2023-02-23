using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceProcessor.MongoDB.Contracts.Entities
{
	public class InternationalExchange
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		[BsonIgnoreIfDefault]
		public string Id { get; set; }
		public string Exchange { get; set; }
		public string Region { get; set; }
		public string Description { get; set; }
		public string Mic { get; set; }
		public string ExchangeSuffix { get; set; }
	}
}
