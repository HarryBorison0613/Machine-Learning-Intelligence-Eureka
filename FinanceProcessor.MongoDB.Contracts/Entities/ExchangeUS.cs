using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceProcessor.MongoDB.Contracts.Entities
{
	public class ExchangeUS
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		[BsonIgnoreIfDefault]
		public string Id { get; set; }
		public string Mic { get; set; }
		public string Name { get; set; }
		public string LongName { get; set; }
		public string TapeId { get; set; }
		public string OatsId { get; set; }
		public string RefId { get; set; }
		public string Type { get; set; }
	}
}
