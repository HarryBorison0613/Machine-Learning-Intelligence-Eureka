using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceProcessor.MongoDB.Contracts.Entities
{
	public class Symbol
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		[BsonIgnoreIfDefault]
		public string Id { get; set; }
		public string SymbolId { get; set; }
		public string Exchange { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public string Type { get; set; }
		public string IexId { get; set; }
		public string Region { get; set; }
		public string Currency { get; set; }
		public bool IsEnabled { get; set; }
		public string Figi { get; set; }
		public string Cik { get; set; }
	}
}
