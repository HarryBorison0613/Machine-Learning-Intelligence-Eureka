using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceProcessor.MongoDB.Contracts.Entities
{
	public class IEXSymbol
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		[BsonIgnoreIfDefault]
		public string Id { get; set; }
		public string Symbol { get; set; }
		public DateTime Date { get; set; }
		public bool IsEnabled { get; set; }
	}
}
