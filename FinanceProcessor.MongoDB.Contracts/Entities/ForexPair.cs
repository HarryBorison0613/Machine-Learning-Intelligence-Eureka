using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceProcessor.MongoDB.Contracts.Entities
{
	public class ForexPair
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		[BsonIgnoreIfDefault]
		public string Id { get; set; }
		public string Symbol { get; set; }
		public string FromCurrency { get; set; }
		public string ToCurrency { get; set; }
		public string Name { get; set; }
		public int IsCrypto { get; set; }
	}
}
