const { env } = require("process");

const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_URLS
  ? env.ASPNETCORE_URLS.split(";")[0]
  : "http://localhost:23728";

const PROXY_CONFIG = [
  {
    context: [
      "/CeoCompensation",
      "/CorporateActions",
      "/Crypto",
      "/MarketInfo",
      "/News",
      "/_configuration",
      "/Payment",
      "/References",
      "/StockFundamentals",
      "/StockPrices",
      "/StockProfiles",
      "/StockResearch",
      "/User",
      "/Batch",
      "/ForexCurrencies",
      "/Treasuries",
      "/Commodities",
      "/EconomicData",
      "/Options",
      "/InvestorsExchangeData"
    ],
    target: target,
    secure: false,
    headers: {
      Connection: "Keep-Alive",
    },
  },
];

module.exports = PROXY_CONFIG;
