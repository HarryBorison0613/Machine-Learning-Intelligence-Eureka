namespace FinanceProcessor.MongoDB.Contracts
{
    public sealed class MongoOptions
    {
        public const string Mongo = "Mongo";

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}