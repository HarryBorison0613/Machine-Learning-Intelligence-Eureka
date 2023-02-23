namespace FinanceProcessor.Core.Models
{
	public class DeepDto
	{
		public string Symbol { get; set; }
		public decimal MarketPercent { get; set; }
		public int Volume { get; set; }
		public decimal LastSalePrice { get; set; }
		public int LastSaleSize { get; set; }
		public long LastSaleTime { get; set; }
		public long LastUpdated { get; set; }
		public List<BidDto> Bids { get; set; }
		public List<AskDto> Asks { get; set; }
		public DeepSystemEventDto SystemEvent { get; set; }
		public DeepTradingStatusDto TradingStatus { get; set; }
		public DeepOperationalHaltStatusDto OpHaltStatus { get; set; }
		public DeepShortSalePriceTestStatusDto SsrStatus { get; set; }
		public DeepSecurityEventDto SecurityEvent { get; set; }
		public List<DeepTradeDto> Trades { get; set; }
		public List<DeepTradeDto> TradeBreaks { get; set; }
		public DeepAuctionDto Auction { get; set; }
	}
}
