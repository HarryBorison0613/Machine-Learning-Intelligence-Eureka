import { Component, OnInit } from "@angular/core";

export interface RouteInfo {
  path: string;
  title: string;
  type: string;
  icontype: string;
  rtlTitle: string;
  collapse?: string;
  isCollapsed?: boolean;
  isCollapsing?: any;
  children?: ChildrenItems[];
}

export interface ChildrenItems {
  path: string;
  title: string;
  smallTitle?: string;
  rtlTitle: string;
  rtlSmallTitle?: string;
  type?: string;
  collapse?: string;
  children?: ChildrenItems2[];
  isCollapsed?: boolean;
}
export interface ChildrenItems2 {
  path?: string;
  smallTitle?: string;
  rtlSmallTitle?: string;
  title?: string;
  rtlTitle: string;
  type?: string;
}
//Menu Items
export const ROUTES: RouteInfo[] = [
  {
    path: "/stocks-equities",
    title: "Stocks Equities",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "stocks-equities",
    rtlTitle: "الأسهم الأسهم",
    isCollapsed: true,
    children: [
      {
        path: "balance-sheet",
        rtlTitle: "ورقة التوازن",
        rtlSmallTitle: "و",
        title: "Balance Sheet",
        type: "link",
        smallTitle: "BS"
      },
      {
        path: "bonus-issue",
        rtlTitle: "إصدار أسهم منحة",
        rtlSmallTitle: "إ",
        title: "Bonus Issue",
        type: "link",
        smallTitle: "BI"
      },
      {
        path: "book",
        rtlTitle: "احجز",
        rtlSmallTitle: "ا",
        title: "Book",
        type: "link",
        smallTitle: "Bk"
      },
      {
        path: "cash-flow",
        rtlTitle: "نقد متدفق",
        rtlSmallTitle: "ن",
        title: "Cash Flow",
        type: "link",
        smallTitle: "CF"
      },
      {
        path: "ceo-compensation",
        rtlTitle: "تعويض الرئيس التنفيذي",
        rtlSmallTitle: "ت",
        title: "CEO compensation",
        type: "link",
        smallTitle: "CEO"
      },
      {
        path: "charts",
        rtlTitle: "الرسوم البيانية",
        rtlSmallTitle: "ا",
        title: "Charts",
        type: "link",
        smallTitle: "Cht"
      },
      {
        path: "collections",
        rtlTitle: "المجموعات",
        rtlSmallTitle: "ا",
        title: "Collections",
        type: "link",
        smallTitle: "Col"
      },
      {
        path: "company",
        rtlTitle: "شركة",
        rtlSmallTitle: "ش",
        title: "Company",
        type: "link",
        smallTitle: "Com"
      },
      {
        path: "delayed-quote",
        rtlTitle: "اقتباس متأخر",
        rtlSmallTitle: "ام",
        title: "Delayed Quote",
        type: "link",
        smallTitle: "DQ"
      },
      {
        path: "distribution",
        rtlTitle: "توزيع",
        rtlSmallTitle: "ت",
        title: "Distribution",
        type: "link",
        smallTitle: "Dis"
      },
      {
        path: "dividends",
        rtlTitle: "أرباح",
        rtlSmallTitle: "أ",
        title: "Dividends",
        type: "link",
        smallTitle: "Div"
      },
      {
        path: "dividends-basic",
        rtlTitle: "أرباح",
        rtlSmallTitle: "أ",
        title: "Dividends(basic)",
        type: "link",
        smallTitle: "Div(b)"
      },
      {
        path: "dividends-forecast-alpha",
        rtlTitle: "توقعات توزيعات الأرباح",
        rtlSmallTitle: "ت",
        title: "Dividends Forecast",
        type: "link",
        smallTitle: "DF(a)"
      },
      {
        path: "financials-as-reported",
        rtlTitle: "المالية كما ذكرت",
        rtlSmallTitle: "ا",
        title: "Financials As Reported",
        type: "link",
        smallTitle: "FAR"
      },
      {
        path: "financials",
        rtlTitle: "المالية",
        rtlSmallTitle: "ا",
        title: "Financials",
        type: "link",
        smallTitle: "Fin"
      },
      {
        path: "fundamentals",
        rtlTitle: "الأساسيات",
        rtlSmallTitle: "ا",
        title: "Fundamentals",
        type: "link",
        smallTitle: "Fun"
      },
      {
        path: "fundamental-valuations-alpha",
        rtlTitle: "أساسيات التقييم",
        rtlSmallTitle: "أ",
        title: "Fundamentals Valuations",
        type: "link",
        smallTitle: "FV(a)"
      },
      {
        path: "fund-ownership",
        rtlTitle: "أساسيات التقييم",
        rtlSmallTitle: "أ",
        title: "Fund Ownership",
        type: "link",
        smallTitle: "FO"
      },
      {
        path: "historical-prices",
        rtlTitle: "الأسعار التاريخية",
        rtlSmallTitle: "أ",
        title: "Historical Prices",
        type: "link",
        smallTitle: "H-Pri"
      },
      {
        path: "income-statement",
        rtlTitle: "قوائم الدخل",
        rtlSmallTitle: "ق",
        title: "Income Statement",
        type: "link",
        smallTitle: "IStat"
      },
      {
        path: "insider-roster",
        rtlTitle: "قائمة المطلعين",
        rtlSmallTitle: "ق",
        title: "Insider Roster",
        type: "link",
        smallTitle: "IRst"
      },
      {
        path: "insider-summary",
        rtlTitle: "ملخص من الداخل",
        rtlSmallTitle: "م",
        title: "Insider Summary",
        type: "link",
        smallTitle: "ISum"
      },
      {
        path: "insider-transactions",
        rtlTitle: "معاملات المطلعين",
        rtlSmallTitle: "م",
        title: "Insider Transactions",
        type: "link",
        smallTitle: "ITrans"
      },
      {
        path: "institutional-ownership",
        rtlTitle: "معاملات المطلعين",
        rtlSmallTitle: "م",
        title: "Institutional Ownership",
        type: "link",
        smallTitle: "IO"
      },
      {
        path: "intraday-prices",
        rtlTitle: "أسعار لحظية",
        rtlSmallTitle: "أ",
        title: "Intraday prices",
        type: "link",
        smallTitle: "IP"
      },
      {
        path: "ipo-calendar-beta",
        rtlTitle: "تقويم الاكتتاب",
        rtlSmallTitle: "ت",
        title: "IPO Calendar",
        type: "link",
        smallTitle: "IC(b)"
      },
      {
        path: "largest-trades",
        rtlTitle: "أكبر التداولات",
        rtlSmallTitle: "ت",
        title: "Largest Trades",
        type: "link",
        smallTitle: "LT"
      },
      {
        path: "list",
        rtlTitle: "قائمة",
        rtlSmallTitle: "ق",
        title: "List",
        type: "link",
        smallTitle: "L"
      },
      {
        path: "market-volume-us",
        rtlTitle: "حجم السوق",
        rtlSmallTitle: "ح",
        title: "Market Volume(U.S.)",
        type: "link",
        smallTitle: "MV"
      },
      {
        path: "markets",
        rtlTitle: "الأسواق",
        rtlSmallTitle: "ا",
        title: "Markets",
        type: "link",
        smallTitle: "M"
      },
      {
        path: "ohlc",
        rtlTitle: "الأسواق",
        rtlSmallTitle: "ا",
        title: "OHLC",
        type: "link",
        smallTitle: "OHLC"
      },
      {
        path: "peer-groups",
        rtlTitle: "مجموعات الأقران",
        rtlSmallTitle: "م",
        title: "Peer Groups",
        type: "link",
        smallTitle: "PG"
      },
      {
        path: "previous-day-price",
        rtlTitle: "سعر اليوم السابق",
        rtlSmallTitle: "س",
        title: "Previous Day Price",
        type: "link",
        smallTitle: "PDP"
      },
      {
        path: "price-only",
        rtlTitle: "سعر اليوم السابق",
        rtlSmallTitle: "س",
        title: "Price Only",
        type: "link",
        smallTitle: "PO"
      },
      {
        path: "quote",
        rtlTitle: "يقتبس",
        rtlSmallTitle: "ي",
        title: "Quote",
        type: "link",
        smallTitle: "Q"
      },
      {
        path: "relevant-stocks",
        rtlTitle: "الأسهم ذات الصلة",
        rtlSmallTitle: "ي",
        title: "Relevant Stocks",
        type: "link",
        smallTitle: "RS(d)"
      },
      {
        path: "return-of-capital",
        rtlTitle: "اعودة رأس المال",
        rtlSmallTitle: "ي",
        title: "Return of Capital",
        type: "link",
        smallTitle: "RoC"
      },
      {
        path: "right-to-purchase",
        rtlTitle: "حق الشراء",
        rtlSmallTitle: "ي",
        title: "Right to Purchase",
        type: "link",
        smallTitle: "RtP"
      },
      {
        path: "rights-issue",
        rtlTitle: "إصدار الحقوق",
        rtlSmallTitle: "ي",
        title: "Rights Issue",
        type: "link",
        smallTitle: "RI"
      },
      {
        path: "sector-performance",
        rtlTitle: "أداء القطاع",
        rtlSmallTitle: "ي",
        title: "Sector Performance",
        type: "link",
        smallTitle: "SP"
      },
      {
        path: "security-reclassification",
        rtlTitle: "إعادة تصنيف الأمان",
        rtlSmallTitle: "ي",
        title: "Security Reclassification",
        type: "link",
        smallTitle: "SR"
      },
      {
        path: "security-swap",
        rtlTitle: "مقايضة الأمان",
        rtlSmallTitle: "ي",
        title: "Security Swap",
        type: "link",
        smallTitle: "SS"
      },
      {
        path: "spinoff",
        rtlTitle: "تدور خارج",
        rtlSmallTitle: "ي",
        title: "Spinoff",
        type: "link",
        smallTitle: "Spi"
      },
      {
        path: "splits",
        rtlTitle: "انشقاقات",
        rtlSmallTitle: "ي",
        title: "Splits",
        type: "link",
        smallTitle: "Spl"
      },
      {
        path: "splits-basic",
        rtlTitle: "انشقاقات",
        rtlSmallTitle: "ي",
        title: "Splits(Basic)",
        type: "link",
        smallTitle: "Spl(b)"
      },
      {
        path: "stats",
        rtlTitle: "احصائيات",
        rtlSmallTitle: "ي",
        title: "Stats",
        type: "link",
        smallTitle: "Stats"
      },
      {
        path: "stats-basic",
        rtlTitle: "احصائيات",
        rtlSmallTitle: "ي",
        title: "Stats(Basic)",
        type: "link",
        smallTitle: "Stats(b)"
      },
      {
        path: "technical-indicators",
        rtlTitle: "المؤشرات الفنية",
        rtlSmallTitle: "ي",
        title: "Technical Indicators",
        type: "link",
        smallTitle: "TI"
      },
      {
        path: "upcoming-events",
        rtlTitle: "الأحداث القادمة",
        rtlSmallTitle: "ي",
        title: "Upcoming Events",
        type: "link",
        smallTitle: "UE"
      },
      {
        path: "volume-by-venue",
        rtlTitle: "الحجم حسب المكان",
        rtlSmallTitle: "ي",
        title: "Volume by Venue",
        type: "link",
        smallTitle: "VbV"
      },
    ]
  },
  {
    path: "/news",
    title: "News",
    type: "sub",
    icontype: "tim-icons",
    collapse: "news",
    rtlTitle: "لوحة القيادة",
    isCollapsed: true,
    children: [
      {
        path: "intraday-news",
        rtlTitle: " أخبار اليوم ",
        rtlSmallTitle: "ع ",
        title: "Intraday News",
        type: "link",
        smallTitle: "INews"
      },
      {
        path: "historical-news",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "Historical News",
        type: "link",
        smallTitle: "HN"
      },
      {
        path: "streaming-news",
        rtlTitle: "تدفق الأخبار ",
        rtlSmallTitle: " ت",
        title: "Streaming News",
        type: "link",
        smallTitle: "SN"
      }
    ]
  },
  {
    path: "/cryptocurrency",
    title: "Cryptocurrency",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "cryptocurrency",
    rtlTitle: "عملة مشفرة",
    isCollapsed: true,
    children: [
      {
        path: "cryptocurrency-book",
        rtlTitle: " كتاب العملات المشفرة ",
        rtlSmallTitle: "ع ",
        title: "Cryptocurrency Book",
        type: "link",
        smallTitle: "CB"
      },
      {
        path: "cryptocurrency-events",
        rtlTitle: "أحداث العملات المشفرة",
        rtlSmallTitle: "ص",
        title: "Cryptocurrency Events",
        type: "link",
        smallTitle: "CE"
      },
      {
        path: "cryptocurrency-price",
        rtlTitle: "سعر العملة المشفرة ",
        rtlSmallTitle: " ت",
        title: "Cryptocurrency Price",
        type: "link",
        smallTitle: "CP"
      },
      {
        path: "cryptocurrency-quote",
        rtlTitle: "اقتباس العملة المشفرة",
        rtlSmallTitle: " شع",
        title: "Cryptocurrency Quote",
        type: "link",
        smallTitle: "CQ"
      }
    ]
  },
  {
    path: "/forex-currencies",
    title: "Forex/Currencies",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "forex-currencies",
    rtlTitle: "الفوركس / العملات",
    isCollapsed: true,
    children: [
      {
        path: "real-time-streaming",
        rtlTitle: " البث في الوقت الحقيقي ",
        rtlSmallTitle: "ع ",
        title: "Real-Time Streaming",
        type: "link",
        smallTitle: "R-TS"
      },
      {
        path: "latest-currency-rates",
        rtlTitle: "أحدث أسعار العملات ",
        rtlSmallTitle: "ص",
        title: "Latest Currency Rates",
        type: "link",
        smallTitle: "LCR"
      },
      {
        path: "currency-conversion",
        rtlTitle: "تحويل العملات ",
        rtlSmallTitle: " ت",
        title: "Currency Conversion",
        type: "link",
        smallTitle: "CC"
      },
      {
        path: "historical-daily",
        rtlTitle: "التاريخية اليومية",
        rtlSmallTitle: " شع",
        title: "Historical Daily",
        type: "link",
        smallTitle: "HD"
      }
    ]
  },
  {
    path: "/options",
    title: "Options",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "options",
    rtlTitle: "خيارات",
    isCollapsed: true,
    children: [
      {
        path: "end-of-day-options",
        rtlTitle: "خيارات نهاية اليوم",
        rtlSmallTitle: " شع",
        title: "End of Day Options",
        type: "link",
        smallTitle: "EoDO"
      }
    ]
  },
  {
    path: "/futures",
    title: "Futures",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "futures",
    rtlTitle: "العقود الآجلة",
    isCollapsed: true,
    children: [
      {
        path: "end-of-day-futures-beta",
        rtlTitle: "العقود الآجلة لنهاية اليوم",
        rtlSmallTitle: " شع",
        title: "End of Day Futures(Beta)",
        type: "link",
        smallTitle: "EoDF"
      }
    ]
  },
  {
    path: "/treasuries",
    title: "Treasuries",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "treasuries",
    rtlTitle: " سندات الخزانة",
    isCollapsed: true,
    children: [
      {
        path: "daily-treasury-rates",
        rtlTitle: "العقود الآجلة لنهاية اليوم",
        rtlSmallTitle: " شع",
        title: "Daily Treasury Rates",
        type: "link",
        smallTitle: "DTR"
      }
    ]
  },
  {
    path: "/commodities",
    title: "Commodities",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "commodities",
    rtlTitle: "  السلع",
    isCollapsed: true,
    children: [
      {
        path: "oil-prices",
        rtlTitle: "أسعار النفط",
        rtlSmallTitle: " شع",
        title: "Oil Prices",
        type: "link",
        smallTitle: "OP"
      },
      {
        path: "natural-gas-price",
        rtlTitle: " سعر الغاز الطبيعي",
        rtlSmallTitle: " شع",
        title: "Natural Gas Price",
        type: "link",
        smallTitle: "NGP"
      },
      {
        path: "heating-oil-prices",
        rtlTitle: " سعر الغاز الطبيعي",
        rtlSmallTitle: " شع",
        title: "Heating Oil Prices",
        type: "link",
        smallTitle: "HOP"
      },
      {
        path: "jet-fuel-prices",
        rtlTitle: "أسعار وقود الطائرات",
        rtlSmallTitle: " شع",
        title: "Jet Fuel Prices",
        type: "link",
        smallTitle: "JFP"
      },
      {
        path: "diesel-price",
        rtlTitle: "سعر الديزل",
        rtlSmallTitle: " شع",
        title: "Diesel Price",
        type: "link",
        smallTitle: "DP"
      },
      {
        path: "gas-prices",
        rtlTitle: "أسعار الغاز",
        rtlSmallTitle: " شع",
        title: "Gas Prices",
        type: "link",
        smallTitle: "GP"
      },
      {
        path: "propane-prices",
        rtlTitle: "أسعار البروبان",
        rtlSmallTitle: " شع",
        title: "Propane Prices",
        type: "link",
        smallTitle: "PP"
      },
    ]
  },
  {
    path: "/economic-data",
    title: "Economic Data",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "economic-data",
    rtlTitle: "بيانات اقتصاديه",
    isCollapsed: true,
    children: [
      {
        path: "consumer-price-index",
        rtlTitle: "الرقم القياسي لأسعار المستهلك",
        rtlSmallTitle: " شع",
        title: "Consumer Price Index",
        type: "link",
        smallTitle: "CPI"
      },
      {
        path: "federal-fund-rates",
        rtlTitle: "معدلات الصندوق الفيدرالي",
        rtlSmallTitle: " شع",
        title: "Federal Fund Rates",
        type: "link",
        smallTitle: "FFR"
      },
      {
        path: "real-gdp",
        rtlTitle: "الناتج المحلي الإجمالي الحقيقي",
        rtlSmallTitle: " شع",
        title: "Real GDP",
        type: "link",
        smallTitle: "RGDP"
      },
      {
        path: "institutional-money-funds",
        rtlTitle: "صناديق الأموال المؤسسية",
        rtlSmallTitle: " شع",
        title: "Institutional Money Funds",
        type: "link",
        smallTitle: "IMF"
      },
      {
        path: "initial-claims",
        rtlTitle: "المطالبات الأولية",
        rtlSmallTitle: " شع",
        title: "Initial Claims",
        type: "link",
        smallTitle: "IC"
      },
      {
        path: "industrial-production-index",
        rtlTitle: "مؤشر الإنتاج الصناعي",
        rtlSmallTitle: " شع",
        title: "Industrial Production Index",
        type: "link",
        smallTitle: "IPI"
      },
      {
        path: "total-housing-starts",
        rtlTitle: "مجموع بدايات الإسكان",
        rtlSmallTitle: " شع",
        title: "Total Housing Starts",
        type: "link",
        smallTitle: "THS"
      },
      {
        path: "total-payrolls",
        rtlTitle: "مجموع الرواتب",
        rtlSmallTitle: " شع",
        title: "Total Payrolls",
        type: "link",
        smallTitle: "TP"
      },
      {
        path: "total-vehicle-sales",
        rtlTitle: "إجمالي مبيعات المركبات",
        rtlSmallTitle: " شع",
        title: "Total Vehicle Sales",
        type: "link",
        smallTitle: "TVS"
      },
      {
        path: "retail-money-funds",
        rtlTitle: "صناديق أموال التجزئة",
        rtlSmallTitle: " شع",
        title: "Retail Money Funds",
        type: "link",
        smallTitle: "RMF"
      },
      {
        path: "unemployment-rate",
        rtlTitle: "معدل البطالة",
        rtlSmallTitle: " شع",
        title: "Unemployment Rate",
        type: "link",
        smallTitle: "UR"
      },
      {
        path: "us-recession-probabilities",
        rtlTitle: "احتمالات الركود الأمريكي",
        rtlSmallTitle: " شع",
        title: "US Recession Probabilities",
        type: "link",
        smallTitle: "URP"
      },
    ]
  },
  {
    path: "/rates",
    title: "Rates",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "rates",
    rtlTitle: " معدلات ",
    isCollapsed: true,
    children: [
      {
        path: "cd-rates",
        rtlTitle: "أسعار القرص المضغوط",
        rtlSmallTitle: " شع",
        title: "CD Rates",
        type: "link",
        smallTitle: "CD"
      },
      {
        path: "credit-card-interest-rate",
        rtlTitle: "معدل الفائدة على بطاقة الائتمان",
        rtlSmallTitle: " شع",
        title: "Credit Card Interest Rate",
        type: "link",
        smallTitle: "CCIR"
      }
    ]
  },
  {
    path: "/mortgage",
    title: "Mortgage",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "rates",
    rtlTitle: "القرض العقاري",
    isCollapsed: true,
    children: [
      {
        path: "mortgage-rates",
        rtlTitle: "معدلات الرهن العقاري",
        rtlSmallTitle: " شع",
        title: "Mortgage Rates",
        type: "link",
        smallTitle: "MR"
      },
    ]
  },
  {
    path: "/reference-data",
    title: "Reference Data",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "reference-data",
    rtlTitle: "البيانات المرجعية",
    isCollapsed: true,
    children: [
      {
        path: "search",
        rtlTitle: "يبحث",
        rtlSmallTitle: " شع",
        title: "Search",
        type: "link",
        smallTitle: "S"
      },
      {
        path: "symbols",
        rtlTitle: "حرف او رمز",
        rtlSmallTitle: " شع",
        title: "Symbols",
        type: "link",
        smallTitle: "S"
      },
      {
        path: "iex-symbols",
        rtlTitle: "رموز IEX",
        rtlSmallTitle: " شع",
        title: "IEX Symbols",
        type: "link",
        smallTitle: "IEXS"
      },
      // {
      //   path: "options-symbols",
      //   rtlTitle: "رموز الخيارات",
      //   rtlSmallTitle: " شع",
      //   title: "Options Symbols",
      //   type: "link",
      //   smallTitle: "OpsS"
      // },
      {
        path: "international-symbols",
        rtlTitle: "الرموز الدولية",
        rtlSmallTitle: " شع",
        title: "International Symbols",
        type: "link",
        smallTitle: "IntS"
      },
      {
        path: "mutual-fund-symbols",
        rtlTitle: "رموز صندوق الاستثمار",
        rtlSmallTitle: " شع",
        title: "Mutual Fund Symbols",
        type: "link",
        smallTitle: "MFS"
      },
      {
        path: "cryptocurrency-symbols",
        rtlTitle: "رموز العقود الآجلة",
        rtlSmallTitle: " شع",
        title: "Cryptocurrency Symbols",
        type: "link",
        smallTitle: "CS"
      },
      {
        path: "fx-symbols",
        rtlTitle: "رموز العقود الآجلة",
        rtlSmallTitle: " شع",
        title: "FX Symbols",
        type: "link",
        smallTitle: "FXS"
      },
      {
        path: "futures-symbols",
        rtlTitle: "رموز العقود الآجلة",
        rtlSmallTitle: " شع",
        title: "Futures Symbols",
        type: "link",
        smallTitle: "FutS"
      },
      {
        path: "otc-symbols",
        rtlTitle: "التبادل الدولي",
        rtlSmallTitle: " شع",
        title: "OTC Symbols",
        type: "link",
        smallTitle: "OTCS"
      },
      {
        path: "us-exchanges",
        rtlTitle: "التبادل الدولي",
        rtlSmallTitle: " شع",
        title: "U.S. Exchanges",
        type: "link",
        smallTitle: "U.S.E"
      },
      {
        path: "international-exchanges",
        rtlTitle: "التبادل الدولي",
        rtlSmallTitle: " شع",
        title: "International Exchangs",
        type: "link",
        smallTitle: "IntE"
      },
      {
        path: "isin-mapping",
        rtlTitle: "خرائط ISIN",
        rtlSmallTitle: " شع",
        title: "ISIN Mapping",
        type: "link",
        smallTitle: "ISINM"
      },
      {
        path: "ric-mapping",
        rtlTitle: "رسم الخرائط",
        rtlSmallTitle: " شع",
        title: "RIC Mapping",
        type: "link",
        smallTitle: "RICM"
      },
      {
        path: "figi-mapping",
        rtlTitle: "FIGI Mapping",
        rtlSmallTitle: " شع",
        title: "FIGI Mapping",
        type: "link",
        smallTitle: "FIGIM"
      },
      {
        path: "sectors",
        rtlTitle: "القطاعات",
        rtlSmallTitle: " شع",
        title: "Sectors",
        type: "link",
        smallTitle: "Sect"
      },
      {
        path: "tags",
        rtlTitle: "العلامات",
        rtlSmallTitle: " شع",
        title: "Tags",
        type: "link",
        smallTitle: "Tags"
      },
      {
        path: "us-holidays-and-trading-dates",
        rtlTitle: "عطلات الولايات المتحدة وتواريخ التداول",
        rtlSmallTitle: " شع",
        title: "U.S. Holidays and Trading Dates",
        type: "link",
        smallTitle: "Tags"
      },
    ]
  },
  {
    path: "/investors-exchange-data",
    title: "Investors Exchange Data",
    type: "sub",
    icontype: "",
    collapse: "rates",
    rtlTitle: "بيانات تبادل المستثمرين",
    isCollapsed: true,
    children: [
      // {
      //   path: "deep",
      //   rtlTitle: "",
      //   rtlSmallTitle: " شع",
      //   title: "DEEP",
      //   type: "link",
      //   smallTitle: "DEEP"
      // },
      {
        path: "deep-auction",
        rtlTitle: "السعر الرسمي العميق",
        rtlSmallTitle: " شع",
        title: "DEEP Auction",
        type: "link",
        smallTitle: "DA"
      },
      {
        path: "deep-book",
        rtlTitle: "السعر الرسمي العميق",
        rtlSmallTitle: " شع",
        title: "DEEP Book",
        type: "link",
        smallTitle: "DB"
      },
      {
        path: "deep-operational-halt-status",
        rtlTitle: "السعر الرسمي العميق",
        rtlSmallTitle: " شع",
        title: "DEEP Operational Halt Status",
        type: "link",
        smallTitle: "DOP"
      },
      {
        path: "deep-official-price",
        rtlTitle: "السعر الرسمي العميق",
        rtlSmallTitle: " شع",
        title: "DEEP Official Price",
        type: "link",
        smallTitle: "DOP"
      },
      {
        path: "deep-security-event",
        rtlTitle: "حدث أمان عميق",
        rtlSmallTitle: " شع",
        title: "DEEP Security Event",
        type: "link",
        smallTitle: "DSE"
      },
      {
        path: "deep-short-sale-price-test-status",
        rtlTitle: "حالة اختبار سعر البيع على المكشوف العميق",
        rtlSmallTitle: " شع",
        title: "DEEP Short Sale Price Test Status",
        type: "link",
        smallTitle: "DSSPTS"
      },
      {
        path: "deep-system-event",
        rtlTitle: "حدث نظام DEEP",
        rtlSmallTitle: " شع",
        title: "DEEP System Event",
        type: "link",
        smallTitle: "DSE"
      },
      {
        path: "deep-trades",
        rtlTitle: "الصفقات العميقة",
        rtlSmallTitle: " شع",
        title: "DEEP Trades",
        type: "link",
        smallTitle: "DT"
      },
      {
        path: "deep-trade-break",
        rtlTitle: "كسر التجارة العميقة",
        rtlSmallTitle: " شع",
        title: "DEEP Trade Break",
        type: "link",
        smallTitle: "DTB"
      },
      {
        path: "deep-trading-status",
        rtlTitle: "حالة التداول العميقة",
        rtlSmallTitle: " شع",
        title: "DEEP Trading Status",
        type: "link",
        smallTitle: "DTS"
      },
      {
        path: "last",
        rtlTitle: "آخر",
        rtlSmallTitle: " شع",
        title: "Last",
        type: "link",
        smallTitle: "L"
      },
      {
        path: "tops",
        rtlTitle: "القمم",
        rtlSmallTitle: " شع",
        title: "TOPS",
        type: "link",
        smallTitle: "TOPS"
      },
    ]
  },
  {
    path: "/audit-analytics",
    title: "Audit Analytics",
    type: "sub",
    icontype: "tim-icons",
    collapse: "audit-analytics",
    rtlTitle: "لوحة القيادة",
    isCollapsed: true,
    children: [
      {
        path: "aa-director",
        rtlTitle: " أخبار اليوم ",
        rtlSmallTitle: "ع ",
        title: "Audit Analytics Director and Officer Changes",
        type: "link",
        smallTitle: "AAD"
      },
      {
        path: "aa-accounting",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "Audit Analytics Accounting Quality and Risk Matrix",
        type: "link",
        smallTitle: "AAA"
      },
    ]
  },
  {
    path: "/brain-company",
    title: "BRAIN Company",
    type: "sub",
    icontype: "tim-icons",
    collapse: "brain-company",
    rtlTitle: "لوحة القيادة",
    isCollapsed: true,
    children: [
      {
        path: "bs-2-day-ml",
        rtlTitle: " أخبار اليوم ",
        rtlSmallTitle: "ع ",
        title: "BRAIN Company's 2 Day Machine Learning Estimated Return Ranking",
        type: "link",
        smallTitle: "BC2"
      },
      {
        path: "bs-3-day-ml",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "BRAIN Company's 3 Day Machine Learning Estimated Return Ranking",
        type: "link",
        smallTitle: "BC3"
      },
      {
        path: "bs-5-day-ml",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "BRAIN Company's 5 Day Machine Learning Estimated Return Ranking",
        type: "link",
        smallTitle: "BC5"
      },
      {
        path: "bs-7-day-si",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "BRAIN Company's 7 Day Sentiment Indicator",
        type: "link",
        smallTitle: "BC7"
      },
      {
        path: "bs-10-day-ml",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "BRAIN Company's 10 Day Machine Learning Estimated Return Ranking",
        type: "link",
        smallTitle: "BC10"
      },
      {
        path: "bs-21-day-ml",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "BRAIN Company's 21 Day Machine Learning Estimated Return Ranking",
        type: "link",
        smallTitle: "BC21"
      },
      {
        path: "bs-30-day-si",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "BRAIN Company's 30 Day Sentiment Indicator",
        type: "link",
        smallTitle: "BC30"
      },
      {
        path: "bs-lm-quarterly-annualy",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "BRAIN Company's Language Metrics on Company Filings (Quarterly and Annual)",
        type: "link",
        smallTitle: "BCD"
      },
      {
        path: "bs-lm-annual-only",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "BRAIN Company's Language Metrics on Company Filings (Annual Only)",
        type: "link",
        smallTitle: "BCD"
      },
      {
        path: "bs-differences-quarterly-annual",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "BRAIN Company's Differences in Language Metircs on Company Filings (Quarterly and Annual) From Prior Period",
        type: "link",
        smallTitle: "BCD"
      },
      {
        path: "bs-differences-annual",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "BRAIN Company's Differences in Language Metircs on Company Annual Filings From Prior Year",
        type: "link",
        smallTitle: "BCD"
      },
    ]
  },
  {
    path: "/city-falcon",
    title: "City Falcon",
    type: "sub",
    icontype: "tim-icons",
    collapse: "city-falcon",
    rtlTitle: "لوحة القيادة",
    isCollapsed: true,
    children: [
      {
        path: "city-falcon-news",
        rtlTitle: " أخبار اليوم ",
        rtlSmallTitle: "ع ",
        title: "City Falcon News",
        type: "link",
        smallTitle: "CFN"
      },
      {
        path: "city-falcon-streaming-news",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "City Falcon Streaming News",
        type: "link",
        smallTitle: "CFSN"
      },
    ]
  },
  {
    path: "/extract-alpha",
    title: "ExtractAlpha",
    type: "sub",
    icontype: "tim-icons",
    collapse: "extract-alpha",
    rtlTitle: "لوحة القيادة",
    isCollapsed: true,
    children: [
      {
        path: "cross-asset-model-1",
        rtlTitle: " أخبار اليوم ",
        rtlSmallTitle: "ع ",
        title: "Cross-Asset-Model-1",
        type: "link",
        smallTitle: "CAM1"
      },
      {
        path: "esg-cfpb-complaints",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "ESG CFPB Complaints",
        type: "link",
        smallTitle: "ECC"
      },
      {
        path: "esg-dol-visa-applications",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "ESG DOL Visa Applications",
        type: "link",
        smallTitle: "EDVA"
      },
      {
        path: "esg-epa-enforcements",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "ESG EPA Enforcements",
        type: "link",
        smallTitle: "EEE"
      },
      {
        path: "esg-epa-milestones",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "ESG EPA Milestones",
        type: "link",
        smallTitle: "EEM"
      },
      {
        path: "esg-fec-individual-campaign-contributions",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "ESG FEC Individual Campaign Contributions",
        type: "link",
        smallTitle: "EFI"
      },
      {
        path: "esg-osha-inspections",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "ESG OSHA Inspections",
        type: "link",
        smallTitle: "EOI"
      },
      {
        path: "esg-senate-lobbying",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "ESG Senate Lobbying",
        type: "link",
        smallTitle: "ESL"
      },
      {
        path: "esg-usa-spending",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "ESG USA Spending",
        type: "link",
        smallTitle: "EUS"
      },
      {
        path: "esg-uspto-patent-applications",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "ESG USPTO Patent Applications",
        type: "link",
        smallTitle: "EUPA"
      },
      {
        path: "esg-uspto-patent-grants",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "ESG USPTO Patent Grants",
        type: "link",
        smallTitle: "EUPG"
      },
      {
        path: "tactical-model-1",
        rtlTitle: "أخبار تاريخية ",
        rtlSmallTitle: "ص",
        title: "Tactical Model 1",
        type: "link",
        smallTitle: "TM1"
      },
    ]
  },
  {
    path: "/fraud-factors",
    title: "Fraud Factors",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "fraud-factors",
    rtlTitle: "خيارات",
    isCollapsed: true,
    children: [
      {
        path: "non-timely-filings",
        rtlTitle: "خيارات نهاية اليوم",
        rtlSmallTitle: " شع",
        title: "Non-Timely Filings",
        type: "link",
        smallTitle: "NTF"
      }
    ]
  },
  {
    path: "/kavout",
    title: "Kavout",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "kavout",
    rtlTitle: "خيارات",
    isCollapsed: true,
    children: [
      {
        path: "k-score-for-us-equities",
        rtlTitle: "خيارات نهاية اليوم",
        rtlSmallTitle: " شع",
        title: "K Score For US Equities",
        type: "link",
        smallTitle: "KSUS"
      },
      {
        path: "k-score-for-china-a-shares",
        rtlTitle: "خيارات نهاية اليوم",
        rtlSmallTitle: " شع",
        title: "K Score For China A-Shares",
        type: "link",
        smallTitle: "KSCh"
      }
    ]
  },
  {
    path: "/new-constructs",
    title: "New Constructs",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "new-constructs",
    rtlTitle: "خيارات",
    isCollapsed: true,
    children: [
      {
        path: "new-constructs-report",
        rtlTitle: "خيارات نهاية اليوم",
        rtlSmallTitle: " شع",
        title: "New Constructs Report",
        type: "link",
        smallTitle: "NCR"
      }
    ]
  },
  {
    path: "/precision-alpha",
    title: "Precision alpha",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "precision-alpha",
    rtlTitle: "خيارات",
    isCollapsed: true,
    children: [
      {
        path: "precision-alpha-price-dynamics",
        rtlTitle: "خيارات نهاية اليوم",
        rtlSmallTitle: " شع",
        title: "Precision Alpha Price Dynamics",
        type: "link",
        smallTitle: "PAPD"
      }
    ]
  },
  {
    path: "/refinitiv",
    title: "Refinitiv",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "refinitiv",
    rtlTitle: "خيارات",
    isCollapsed: true,
    children: [
      {
        path: "analyst-recommendations",
        rtlTitle: "خيارات نهاية اليوم",
        rtlSmallTitle: " شع",
        title: "Analyst Recommendations",
        type: "link",
        smallTitle: "AR"
      },
      {
        path: "earnings",
        rtlTitle: "خيارات نهاية اليوم",
        rtlSmallTitle: " شع",
        title: "Earnings",
        type: "link",
        smallTitle: "Earn"
      },
      {
        path: "estimates",
        rtlTitle: "خيارات نهاية اليوم",
        rtlSmallTitle: " شع",
        title: "Estimates",
        type: "link",
        smallTitle: "Estm"
      },
      {
        path: "price-target",
        rtlTitle: "خيارات نهاية اليوم",
        rtlSmallTitle: " شع",
        title: "Price Target",
        type: "link",
        smallTitle: "PT"
      },
    ]
  },
  {
    path: "/stock-twits",
    title: "Stocktwits",
    type: "sub",
    icontype: "tim-icons ",
    collapse: "stock-twits",
    rtlTitle: "خيارات",
    isCollapsed: true,
    children: [
      {
        path: "social-sentiment",
        rtlTitle: "خيارات نهاية اليوم",
        rtlSmallTitle: " شع",
        title: "Social Sentiment",
        type: "link",
        smallTitle: "SS"
      }
    ]
  },
  {
    path: "/phase-2",
    title: "Phase 2",
    type: "sub",
    icontype: "tim-icons icon-molecule-40",
    collapse: "phase-2",
    isCollapsed: true,
    rtlTitle: "المرحلة الثانية",
    children: [
      {
        path: "multilevel",
        title: "MARKET DASHBOARD",
        type: "sub",
        collapse: "markets-dashboard",
        rtlTitle: "لوحة القيادة",
        isCollapsed: true,
        smallTitle: "MD",
        children: [
          {
            path: "market-stocks",
            rtlTitle: " التسعير ",
            rtlSmallTitle: "ع ",
            title: "Stocks",
            type: "link",
            smallTitle: "S"
          },
          {
            path: "market-options",
            rtlTitle: "دعم رتل ",
            rtlSmallTitle: "ص",
            title: "Options",
            type: "link",
            smallTitle: "O"
          },
          {
            path: "market-darkpool",
            rtlTitle: "الجدول الزمني ",
            rtlSmallTitle: " ت",
            title: "DarkPool",
            type: "link",
            smallTitle: "DP"
          },
          {
            path: "market-crypto",
            rtlTitle: "ملف تعريفي للمستخدم",
            rtlSmallTitle: " شع",
            title: "Crypto",
            type: "link",
            smallTitle: "C"
          }
        ]
      },
      {
        path: "multilevel",
        title: "TICKER DASHBOARD",
        type: "sub",
        collapse: "ticker",
        rtlTitle: "لوحة القيادة",
        isCollapsed: true,
        smallTitle: "TD",
        children: [
          {
            path: "ticker-stocks",
            rtlTitle: " التسعير ",
            rtlSmallTitle: "ع ",
            title: "Stocks",
            type: "link",
            smallTitle: "S"
          },
          {
            path: "ticker-options",
            rtlTitle: "دعم رتل ",
            rtlSmallTitle: "ص",
            title: "Options",
            type: "link",
            smallTitle: "O"
          },
          {
            path: "ticker-darkpool",
            rtlTitle: "الجدول الزمني ",
            rtlSmallTitle: " ت",
            title: "DarkPool",
            type: "link",
            smallTitle: "DP"
          },
          {
            path: "ticker-crypto",
            rtlTitle: "ملف تعريفي للمستخدم",
            rtlSmallTitle: " شع",
            title: "Crypto",
            type: "link",
            smallTitle: "C"
          }
        ]
      },
      {
        path: "multilevel",
        title: "FLOW",
        type: "sub",
        collapse: "flow",
        rtlTitle: "لوحة القيادة",
        isCollapsed: true,
        smallTitle: "F",
        children: [
          {
            path: "flow-liveoptions",
            rtlTitle: " التسعير ",
            rtlSmallTitle: "ع ",
            title: "Live Options Flow",
            type: "link",
            smallTitle: "LOF"
          },
          {
            path: "flow-trady",
            rtlTitle: "دعم رتل ",
            rtlSmallTitle: "ص",
            title: "Trady Flow",
            type: "link",
            smallTitle: "TF"
          },
          {
            path: "flow-line",
            rtlTitle: "الجدول الزمني ",
            rtlSmallTitle: " ت",
            title: "Flowline",
            type: "link",
            smallTitle: "FL"
          }
        ]
      },
      {
        path: "multilevel",
        title: "SWING AI",
        type: "sub",
        collapse: "swing-AI",
        rtlTitle: "لوحة القيادة",
        isCollapsed: true,
        smallTitle: "SwAI",
        children: [
          {
            path: "prophet",
            rtlTitle: " التسعير ",
            rtlSmallTitle: "ع ",
            title: "Prophet",
            type: "link",
            smallTitle: "P"
          },
          {
            path: "cryptonite",
            rtlTitle: "الجدول الزمني ",
            rtlSmallTitle: " ت",
            title: "Cryptonite",
            type: "link",
            smallTitle: "Cr"
          }
        ]
      },
      {
        path: "multilevel",
        title: "INTRADAY AI",
        type: "sub",
        collapse: "intraday-AI",
        rtlTitle: "لوحة القيادة",
        isCollapsed: true,
        smallTitle: "InAI",
        children: [
          {
            path: "bullseye",
            rtlTitle: " التسعير ",
            rtlSmallTitle: "ع ",
            title: "Bullseye",
            type: "link",
            smallTitle: "BE"
          },
        ]
      },
      {
        path: "multilevel",
        title: "SCANNER",
        type: "sub",
        collapse: "scanner",
        rtlTitle: "لوحة القيادة",
        isCollapsed: true,
        smallTitle: "Scan",
        children: [
          {
            path: "scany",
            rtlTitle: " التسعير ",
            rtlSmallTitle: "ع ",
            title: "Scany",
            type: "link",
            smallTitle: "S"
          },
          {
            path: "flash",
            rtlTitle: "دعم رتل ",
            rtlSmallTitle: "ص",
            title: "Flash",
            type: "link",
            smallTitle: "F"
          },
          {
            path: "opintra",
            rtlTitle: "الجدول الزمني ",
            rtlSmallTitle: " ت",
            title: "Opintra",
            type: "link",
            smallTitle: "O"
          },
          {
            path: "cryptoscan",
            rtlTitle: "ملف تعريفي للمستخدم",
            rtlSmallTitle: " شع",
            title: "Crypto Scan",
            type: "link",
            smallTitle: "CS"
          }
        ]
      },
      {
        path: "multilevel",
        title: "INVESTING",
        type: "sub",
        collapse: "investing",
        rtlTitle: "لوحة القيادة",
        isCollapsed: true,
        smallTitle: "Inv",
        children: [
          {
            path: "AIportofolios",
            rtlTitle: " التسعير ",
            rtlSmallTitle: "ع ",
            title: "AI Portfolios",
            type: "link",
            smallTitle: "AP"
          },
        ]
      },
      {
        path: "multilevel",
        title: "RESEARCH",
        type: "sub",
        collapse: "research",
        rtlTitle: "لوحة القيادة",
        isCollapsed: true,
        smallTitle: "Res",
        children: [
          {
            path: "polytics",
            rtlTitle: " التسعير ",
            rtlSmallTitle: "ع ",
            title: "Polytics",
            type: "link",
            smallTitle: "PO"
          },
          {
            path: "hedgies",
            rtlTitle: "دعم رتل ",
            rtlSmallTitle: "ص",
            title: "Hedgies",
            type: "link",
            smallTitle: "H"
          },
          {
            path: "peekaboo",
            rtlTitle: "الجدول الزمني ",
            rtlSmallTitle: " ت",
            title: "Peekaboo",
            type: "link",
            smallTitle: "PE"
          },
          {
            path: "chatter",
            rtlTitle: "ملف تعريفي للمستخدم",
            rtlSmallTitle: " شع",
            title: "CHATTER",
            type: "link",
            smallTitle: "C"
          }
        ]
      },
      {
        path: "multilevel",
        title: "COMPLEX TOOLS",
        type: "sub",
        collapse: "complex-tools",
        rtlTitle: "لوحة القيادة",
        isCollapsed: true,
        smallTitle: "CT",
        children: [
          {
            path: "gambit",
            rtlTitle: " التسعير ",
            rtlSmallTitle: "ع ",
            title: "Gambit",
            type: "link",
            smallTitle: "G"
          },
          {
            path: "yinyang",
            rtlTitle: "دعم رتل ",
            rtlSmallTitle: "ص",
            title: "Yinyang",
            type: "link",
            smallTitle: "YY"
          },
          {
            path: "backtester",
            rtlTitle: "الجدول الزمني ",
            rtlSmallTitle: " ت",
            title: "Back Tester",
            type: "link",
            smallTitle: "BT"
          },
          {
            path: "tradytics-AI",
            rtlTitle: "ملف تعريفي للمستخدم",
            rtlSmallTitle: " شع",
            title: "Tradytics AI",
            type: "link",
            smallTitle: "TAI"
          }
        ]
      },
      {
        path: "multilevel",
        title: "HELP",
        type: "sub",
        collapse: "help",
        rtlTitle: "لوحة القيادة",
        isCollapsed: true,
        smallTitle: "H",
        children: [
          {
            path: "performance",
            rtlTitle: " التسعير ",
            rtlSmallTitle: "ع ",
            title: "Performance",
            type: "link",
            smallTitle: "P"
          },
          {
            path: "watchlist",
            rtlTitle: "دعم رتل ",
            rtlSmallTitle: "ص",
            title: "Watchlist",
            type: "link",
            smallTitle: "W"
          },
          {
            path: "discordbots",
            rtlTitle: "الجدول الزمني ",
            rtlSmallTitle: " ت",
            title: "Discord Bots",
            type: "link",
            smallTitle: "DB"
          },
          {
            path: "education",
            rtlTitle: "ملف تعريفي للمستخدم",
            rtlSmallTitle: " شع",
            title: "Education",
            type: "link",
            smallTitle: "E"
          },
          {
            path: "faqs",
            rtlTitle: "ملف تعريفي للمستخدم",
            rtlSmallTitle: " شع",
            title: "FAQs",
            type: "link",
            smallTitle: "F"
          },
        ]
      },
    ]
  }
];

@Component({
  selector: "app-sidebar",
  templateUrl: "./sidebar.component.html",
  styleUrls: ["./sidebar.component.css"]
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() {}

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
}
