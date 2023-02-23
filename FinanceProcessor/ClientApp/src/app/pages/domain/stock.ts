export interface SectorPerformance {
    type?: string;
    name?: string;
    performance?: number;
    lastUpdated?: string | Date;
  }

export interface Collection {
    symbol?: string;
    companyName?: string;
    primaryExchange?: string;
    calculationPrice?: string;
    open?: number;
    openTime?: string | Date;
    openSource?: string;
    close?: number;
    closeTime?: string | Date;
    closeSource?: string;
    high?: number;
    highTime?: string | Date;
    highSource?: string;
    low?: number;
    lowTime?: string | Date;
    lowSource?: string;
    latestPrice?: number;
    latestSource?: string;
    latestTime?: string | Date;
    latestUpdate?: string | Date;
    latestVolume?: number;
    iexRealtimePrice?: number;
    iexRealtimeSize?: number;
    iexLastUpdated?: number;
    delayedPrice?: number;
    delayedPriceTime?: string | Date;
    oddLotDelayedPrice?: number;
    oddLotDelayedPriceTime?: string | Date;
    extendedPrice?: number;
    extendedChange?: number;
    extendedChangePercent?: number;
    extendedPriceTime?: string | Date;
    previousClose?: number;
    previousVolume?: number;
    change?: number;
    changePercent?: number;
    volume?: number;
    iexMarketPercent?: number;
    iexVolume?: number;
    avgTotalVolume?: number;
    iexBidPrice?: number;
    iexBidSize?: number;
    iexAskPrice?: number;
    iexAskSize?: number;
    iexOpen?: number;
    iexOpenTime?: string | Date;
    iexClose?: number;
    iexCloseTime?: string | Date;
    marketCap?: number;
    peRatio?: number;
    week52High?: number;
    week52Low?: number;
    ytdChange?: number;
    lastTradeTime?: string | Date;
    isUSMarketOpen?: boolean;
    sector?: string;
}

export interface MarketVolume {
    mic?: string;
    tapeId?: string;
    venueName?: string;
    volume?: number;
    tapeA?: number;
    tapeB?: number;
    tapeC?: number;
    marketPercent?: number;
    lastUpdated?: string | Date;
  }

export interface BalanceSheet {
    symbol?: string;
    reportDate?: string | Date;
    fiscalDate?: string | Date;
    fiscalQuarter?: number;
    fiscalYear?: number;
    currency?: string;
    currentCash?: number;
    shortTermInvestments?: number;
    receivables?: number;
    inventory?: number;
    otherCurrentAssets?: number;
    currentAssets?: number;
    longTermInvestments?: number;
    propertyPlantEquipment?: number;
    goodwill?: number;
    intangibleAssets?: number;
    otherAssets?: number;
    totalAssets?: number;
    accountsPayable?: number;
    currentLongTermDebt?: number;
    otherCurrentLiabilities?: number;
    totalCurrentLiabilities?: number;
    longTermDebt?: number;
    otherLiabilities?: number;
    minorityInterest?: number;
    totalLiabilities?: number;
    commonStock?: number;
    retainedEarnings?: number;
    treasuryStock?: number;
    capitalSurplus?: number;
    shareholderEquity?: number;
    netTangibleAssets?: number;
    id?: string;
    key?: string;
    subkey?: string;
    date?: string | Date;
    updated?: string | Date;
  };

export interface BonusIssue {
    resultSecurityType: string;
    currency: string;
    lapsedPremium: string | Date;
    symbol: string;
    exDate: string | Date;
    recordDate: string | Date;
    paymentDate: string | Date;
    fromFactor: number;
    toFactor: number;
    ratio: number;
    description: string;
    flag: string;
    securityType: string;
    notes: string;
    figi: string;
    lastUpdated: string | Date;
    countryCode: string;
    parValue: number;
    parValueCurrency: string;
    refid: number;
    created: string | Date;
    id: string;
    source: string;
    key: string;
    subkey: string;
    date: string | Date;
    updated: string | Date;
}

export interface StockBook {
  quote: {
    symbol: string;
    companyName: string;
    primaryExchange: string;
    calculationPrice: string;
    open: number;
    openTime: number;
    openSource: string;
    close: number;
    closeTime: number;
    closeSource: string;
    high: number;
    highTime: number;
    highSource: string;
    low: number;
    lowTime: number;
    lowSource: string;
    latestPrice: number;
    latestSource: string;
    latestTime: string;
    latestUpdate: string | Date;
    latestVolume: number;
    iexRealtimePrice: number;
    iexRealtimeSize: number;
    iexLastUpdated: string | Date;
    delayedPrice: number;
    delayedPriceTime: number;
    oddLotDelayedPrice: number;
    oddLotDelayedPriceTime: number;
    extendedPrice: number;
    extendedChange: number;
    extendedChangePercent: number;
    extendedPriceTime: number;
    previousClose: number;
    previousVolume: number;
    change: number;
    changePercent: number;
    volume: number;
    iexMarketPercent: number;
    iexVolume: number;
    avgTotalVolume: number;
    iexBidPrice: number;
    iexBidSize: number;
    iexAskPrice: number;
    iexAskSize: number;
    iexOpen: number;
    iexOpenTime: string | Date;
    iexClose: number;
    iexCloseTime: string | Date;
    marketCap: number;
    peRatio: number;
    week52High: number;
    week52Low: number;
    ytdChange: number;
    lastTradeTime: string | Date;
    isUSMarketOpen: boolean;
    sector: string;
  },
  trades: [
    {
      symbol?: string;
      price: number;
      size: number;
      tradeId: number;
      isISO: boolean;
      isOddLot: boolean;
      isOutsideRegularHours: boolean;
      isSinglePriceCross: boolean;
      isTradeThroughExempt: boolean;
      timestamp: string | Date;
    }
  ],
  systemEvent: {
    systemEvent: string;
    timestamp: string | Date;
  },
  bids: [
    {
      price: number;
      size: number;
      timestamp: string | Date;
    }
  ],
  asks: [
    {
      price: number;
      size: number;
      timestamp: string | Date;
    }
  ]
}
export interface CashFlow {
  symbol: string;
  cashflow: {
    reportDate: string | Date;
    fiscalDate: string | Date;
    currency: string;
    netIncome: number;
    depreciation: number;
    changesInReceivables: number;
    changesInInventories: number;
    cashChange: number;
    cashFlow: number;
    capitalExpenditures: number;
    investments: number;
    investingActivityOther: number;
    totalInvestingCashFlows: number;
    dividendsPaid: number;
    netBorrowings: number;
    otherFinancingCashFlows: number;
    cashFlowFinancing: number;
    exchangeRateEffect: number;
    id: string;
    key: string;
    subkey: string;
    symbol: string;
    filingType: string;
    fiscalQuarter: number;
    fiscalYear: number;
    updated: string | Date;
  }[];
  id: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: string | Date;
}

export interface StockPrice {
  symbol: string;
  date: string;
  minute: string;
  high: number;
  low: number;
  open: number;
  close: number;
  average: number;
  volume: number;
  notional: number;
  numberOfTrades: number;
  changeOverTime: number;
  marketOpen: number;
  marketClose: number;
  marketHigh: number;
  marketLow: number;
  marketAverage: number;
  marketVolume: number;
  marketNotional: number;
  marketNumberOfTrades: number;
  marketChangeOverTime: number;
}

export interface IntradayPriceForMostPopularSymbols {
  SPY: StockPrice[],
  QQQ: StockPrice[],
  IWM: StockPrice[],
}

export interface Company {
  symbol: string;
  companyName: string;
  exchange: string;
  website: string;
  description: string;
  ceo: string;
  issueType: string;
  sector: string;
  primarySicCode: string;
  exployees: number;
  tags: string[];
  address: string;
  address2: string;
  state: string;
  city: string;
  zip: string;
  country: string;
  phone: string;
}

export interface CeoCompensation {
  symbol: string;
  name: string;
  companyName: string;
  location: string;
  salary: number;
  bonus: number;
  stockAwards: number;
  optionAwards: number;
  nonEquityIncentives: number;
  pensionAndDeferred: number;
  otherComp: number;
}

export interface DelayedQuote {
  symbol: string;
  delayedPrice: number;
  delayedSize: number;
  delayedPriceTime: string | Date;
  high: number;
  low: number;
  totalVolume: number;
  processedTime: string | Date;
}

export interface DistributionList {
  withdrawalFromDate: string | Date;
  withdrawalToDate: string | Date;
  electionDate: string | Date;
  minPrice: number;
  maxPrice: number;
  hasWithdrawalRights: number;
  symbol: string;
  exDate: string | Date;
  recordDate: string | Date;
  paymentDate: string | Date;
  fromFactor: number;
  toFactor: number;
  ratio: number;
  description: string;
  flag: string;
  securityType: string;
  notes: string;
  figi: string;
  lastUpdated: string | Date;
  countryCode: string;
  parValue: number;
  parValueCurrency: string;
  refid: number;
  created: string | Date;
  id: string;
  source: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: string | Date;
}

export interface Dividends {
  more?: boolean;
  announceDate: string | Date;
  currency: string;
  frequency: string;
  amount: number;
  netAmount: number;
  grossAmount: number;
  marker: string;
  taxRate: number;
  adrFee: number;
  coupon: number;
  declaredCurrencyCD: string;
  declaredGrossAmount: number;
  isCapitalGains: number;
  isNetInvestmentIncome: true;
  isDAP: number;
  isApproximate: true;
  fxDate: string | Date;
  secondPaymentDate: string | Date;
  secondExDate: string | Date;
  fiscalYearEndDate: string | Date;
  periodEndDate: string | Date;
  optionalElectionDate: string | Date;
  toDate: string | Date;
  registrationDate: string | Date;
  installmentPayDate: string | Date;
  declaredDate: string | Date;
  symbol: string;
  exDate: string | Date;
  recordDate: string | Date;
  paymentDate: string | Date;
  fromFactor: number;
  toFactor: number;
  ratio: number;
  description: string;
  flag: string;
  securityType: string;
  notes: string;
  figi: string;
  lastUpdated: string | Date;
  countryCode: string;
  parValue: number;
  parValueCurrency: string;
  refid: number;
  created: string | Date;
  id: string;
  source: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: string | Date;
}

export interface DividendsBasic {
  date: string | Date;
  updated: string | Date;
  exDate: string | Date;
  paymentDate: string | Date;
  recordDate: string | Date;
  declaredDate: string | Date;
  amount: number;
  id: string;
  key: string;
  subkey: string;
  refid: number;
  flag: string;
  currency: string;
  description: string;
  frequency: string;
  symbol: string;
}

export interface Financials {
  ebitda: number;
  accountsPayable: number;
  capitalSurplus: number;
  cashChange: number;
  cashFlow: number;
  cashFlowFinancing: number;
  changesInInventories: number;
  changesInReceivables: number;
  commonStock: number;
  costOfRevenue: number;
  currency: string;
  currentAssets: number;
  currentCash: number;
  currentDebt: number;
  currentLongTermDebt: number;
  depreciation: number;
  dividendsPaid: number;
  ebit: number;
  exchangeRateEffect: number;
  fiscalDate: string | Date;
  goodwill: number;
  grossProfit: number;
  incomeTax: number;
  intangibleAssets: number;
  interestIncome: number;
  inventory: number;
  investingActivityOther: number;
  investments: number;
  longTermDebt: number;
  longTermInvestments: number;
  minorityInterest: number;
  netBorrowings: number;
  netIncome: number;
  netIncomeBasic: number;
  netTangibleAssets: number;
  operatingExpense: number;
  operatingIncome: number;
  operatingRevenue: number;
  otherAssets: number;
  otherCurrentAssets: number;
  otherCurrentLiabilities: number;
  otherIncomeExpenseNet: number;
  otherLiabilities: number;
  pretaxIncome: number;
  propertyPlantEquipment: number;
  receivables: number;
  reportDate: string | Date;
  researchAndDevelopment: number;
  retainedEarnings: number;
  revenue: number;
  sellingGeneralAndAdmin: number;
  shareholderEquity: number;
  shortTermDebt: number;
  shortTermInvestments: number;
  symbol: string;
  totalAssets: number;
  totalCash: number;
  totalDebt: number;
  totalInvestingCashFlows: number;
  totalLiabilities: number;
  totalRevenue: number;
  treasuryStock: number;
  id: string;
  key: string;
  subkey: string;
  updated: string | Date;
  date: string | Date;
}

export interface ReportedFinancials {
  symbol?: string;
  id: string;
  source: string;
  key: string;
  subkey: string;
  date: number;
  updated: number;
  decreaseInUnrecognizedTaxBenefitsIsReasonablyPossible: number;
  formFiscalYear: number;
  version: string;
  periodStart: number;
  periodEnd: number;
  dateFiled: number;
  formFiscalQuarter: number;
  reportLink: string;
  otherAccruedLiabilitiesCurrent: number;
  otherAssetsCurrent: number;
  deferredFederalStateAndLocalTaxExpenseBenefit: number;
  otherAssetsNoncurrent: number;
  deferredForeignIncomeTaxExpenseBenefit: number;
  deferredIncomeTaxAssetsNet: number;
  deferredIncomeTaxesAndTaxCredits: number;
  deferredIncomeTaxExpenseBenefit: number;
  deferredIncomeTaxLiabilities: number;
  deferredIncomeTaxLiabilitiesNet: number;
  otherComprehensiveIncomeLossAvailableForSaleSecuritiesAdjustmentNetOfTax: number;
  otherComprehensiveIncomeLossAvailableForSaleSecuritiesTax: number;
  otherComprehensiveIncomeLossCashFlowHedgeGainLossAfterReclassificationAndTax: number;
  otherComprehensiveIncomeLossCashFlowHedgeGainLossAfterReclassificationTax: number;
  otherComprehensiveIncomeLossCashFlowHedgeGainLossBeforeReclassificationAfterTax: number;
  otherComprehensiveIncomeLossCashFlowHedgeGainLossReclassificationAfterTax: number;
  deferredTaxAssetsGross: number;
  deferredTaxAssetsLiabilitiesNet: number;
  deferredTaxAssetsNet: number;
  deferredTaxAssetsOperatingLossCarryforwards: number;
  deferredTaxAssetsOther: number;
  otherComprehensiveIncomeLossForeignCurrencyTransactionAndTranslationAdjustmentNetOfTax: number;
  otherComprehensiveIncomeLossNetOfTax: number;
  otherComprehensiveIncomeLossNetOfTaxPortionAttributableToParent: number;
  otherComprehensiveIncomeLossReclassificationAdjustmentFromAOCIForSaleOfSecuritiesNetOfTax: number;
  deferredTaxAssetsTaxCreditCarryforwardsOther: number;
  deferredTaxAssetsTaxDeferredExpenseCompensationAndBenefitsEmployeeBenefits: number;
  deferredTaxAssetsTaxDeferredExpenseCompensationAndBenefitsShareBasedCompensationCost: number;
  deferredTaxAssetsTaxDeferredExpenseReservesAndAccrualsOther: number;
  deferredTaxAssetsValuationAllowance: number;
  deferredTaxLiabilities: number;
  deferredTaxLiabilitiesGoodwillAndlongangibleAssetslongangibleAssets: number;
  deferredTaxLiabilitiesInvestments: number;
  deferredTaxLiabilitiesOther: number;
  deferredTaxLiabilitiesPropertyPlantAndEquipment: number;
  lossContingencyAccrualCarryingValueCurrent: number;
  definedContributionPlanCostRecognized: number;
  inventoryNet: number;
  employeeRelatedLiabilitiesCurrent: number;
  lossContingencyLossInPeriod: number;
  increaseDecreaseInIncomeTaxes: number;
  foreignCurrencyCashFlowHedgeGainLossToBeReclassifiedDuringNext12Months: number;
  accountsPayableCurrent: number;
  increaseDecreaseInOtherOperatingAssets: number;
  otherComprehensiveIncomeUnrealizedHoldingGainLossOnSecuritiesArisingDuringPeriodNetOfTax: number;
  employeeServiceShareBasedCompensationTaxBenefitFromCompensationExpense: number;
  foreignCurrencyTransactionGainLossBeforeTax: number;
  foreignCurrencyTransactionLossBeforeTax: number;
  accountsReceivableNetCurrent: number;
  contractWithCustomerLiabilityCurrent: number;
  contractWithCustomerLiabilityNoncurrent: number;
  contractWithCustomerLiabilityRevenueRecognized: number;
  assets: number;
  assetsCurrent: number;
  impairmentOfInvestments: number;
  incomeLossFromContinuingOperationsBeforeIncomeTaxesDomestic: number;
  incomeLossFromContinuingOperationsBeforeIncomeTaxesForeign: number;
  incomeLossFromContinuingOperationsBeforeIncomeTaxesMinoritylongerestAndIncomeLossFromEquityMethodInvestments: number;
  incomeTaxesPaidNet: number;
  incomeTaxesReceivable: number;
  incomeTaxExpenseBenefit: number;
  commercialPaper: number;
  commitmentsAndContingencies: number;
  marketableSecuritiesCurrent: number;
  commonStockCapitalSharesReservedForFutureIssuance: number;
  marketingAndAdvertisingExpense: number;
  preferredStockParOrStatedValuePerShare: number;
  preferredStockSharesAuthorized: number;
  preferredStockSharesIssued: number;
  preferredStockSharesOutstanding: number;
  derivativeAssetFairValueGrossLiability: number;
  derivativeAssetFairValueOffsetAgainstCollateralNetOfNotSubjectToMasterNettingArrangementPolicyElection: number;
  assetsNoncurrent: number;
  commonStockParOrStatedValuePerShare: number;
  commonStockSharesAuthorized: number;
  commonStockSharesIssued: number;
  commonStockSharesOutstanding: number;
  commonStocksIncludingAdditionalPaidInCapital: number;
  accruedIncomeTaxesCurrent: number;
  accruedIncomeTaxesNoncurrent: number;
  accruedLiabilitiesCurrent: number;
  increaseDecreaseInAccountsPayable: number;
  increaseDecreaseInAccountsReceivable: number;
  increaseDecreaseInAccruedLiabilities: number;
  convertiblePreferredStockNonredeemableOrRedeemableIssuerOptionValue: number;
  longTermDebt: number;
  longTermDebtAndCapitalLeaseObligations: number;
  comprehensiveIncomeNetOfTax: number;
  longTermDebtFairValue: number;
  longTermDebtMaturitiesRepaymentsOfPrincipalAfterYearFive: number;
  longTermDebtMaturitiesRepaymentsOfPrincipalInNextTwelveMonths: number;
  netCashProvidedByUsedInFinancingActivities: number;
  netCashProvidedByUsedInInvestingActivities: number;
  netCashProvidedByUsedInOperatingActivities: number;
  derivativeAssetNotOffsetPolicyElectionDeduction: number;
  derivativeAssets: number;
  entityPublicFloat: number;
  netIncomeLoss: number;
  increaseDecreaseInCollateralHeldUnderSecuritiesLending: number;
  increaseDecreaseInContractWithCustomerLiability: number;
  derivativeCollateralObligationToReturnCash: number;
  derivativeCollateralObligationToReturnSecurities: number;
  derivativeCollateralRightToReclaimCash: number;
  derivativeCollateralRightToReclaimSecurities: number;
  accumulatedDepreciationDepletionAndAmortizationPropertyPlantAndEquipment: number;
  paymentsForRepurchaseOfCommonStock: number;
  leaseAndRentalExpense: number;
  longTermDebtMaturitiesRepaymentsOfPrincipalInYearFive: number;
  longTermDebtMaturitiesRepaymentsOfPrincipalInYearFour: number;
  longTermDebtMaturitiesRepaymentsOfPrincipalInYearThree: number;
  longTermDebtMaturitiesRepaymentsOfPrincipalInYearTwo: number;
  longTermDebtNoncurrent: number;
  derivativeFairValueOfDerivativeAsset: number;
  derivativeFairValueOfDerivativeLiability: number;
  availableForSaleDebtSecuritiesAccumulatedGrossUnrealizedGainBeforeTax: number;
  availableForSaleDebtSecuritiesAccumulatedGrossUnrealizedLossBeforeTax: number;
  accumulatedOtherComprehensiveIncomeLossNetOfTax: number;
  proceedsFromCollectionOfNotesReceivable: number;
  proceedsFromDebtNetOfIssuanceCosts: number;
  longangibleAssetsNetExcludingGoodwill: number;
  unrecognizedTaxBenefits: number;
  unrecognizedTaxBenefitsDecreasesResultingFromPriorPeriodTaxPositions: number;
  unrecognizedTaxBenefitsDecreasesResultingFromSettlementsWithTaxingAuthorities: number;
  unrecognizedTaxBenefitsIncomeTaxPenaltiesAndlongerestAccrued: number;
  unrecognizedTaxBenefitsIncreasesResultingFromCurrentPeriodTaxPositions: number;
  unrecognizedTaxBenefitsIncreasesResultingFromPriorPeriodTaxPositions: number;
  availableForSaleSecuritiesDebtMaturitiesAfterFiveThroughTenYearsFairValue: number;
  availableForSaleSecuritiesDebtMaturitiesAfterOneThroughFiveYearsFairValue: number;
  availableForSaleSecuritiesDebtMaturitiesAfterTenYearsFairValue: number;
  equityMethodInvestments: number;
  capitalLeasedAssetsGross: number;
  capitalLeaseObligationsNoncurrent: number;
  proceedsFromMinorityShareholders: number;
  proceedsFromPaymentsForSecuritiesPurchasedUnderAgreementsToResell: number;
  derivativeLiabilities: number;
  derivativeLiabilityFairValueGrossAsset: number;
  derivativeLiabilityFairValueOffsetAgainstCollateralNetOfNotSubjectToMasterNettingArrangementPolicyElection: number;
  derivativeLiabilityNotOffsetPolicyElectionDeduction: number;
  equitySecuritiesFvNiGainLoss: number;
  equitySecuritiesFvNiRealizedGainLoss: number;
  equitySecuritiesFvNiUnrealizedGainLoss: number;
  availableForSaleSecuritiesDebtMaturitiesWithinOneYearFairValue: number;
  availableForSaleSecuritiesDebtSecurities: number;
  proceedsFromSaleAndMaturityOfMarketableSecurities: number;
  proceedsFromSaleAndMaturityOfOtherInvestments: number;
  paymentsToAcquireMarketableSecurities: number;
  paymentsToAcquireOtherInvestments: number;
  paymentsToAcquirePropertyPlantAndEquipment: number;
  equitySecuritiesWithoutReadilyDeterminableFairValueAmount: number;
  equitySecuritiesWithoutReadilyDeterminableFairValueDownwardPriceAdjustmentAnnualAmount: number;
  equitySecuritiesWithoutReadilyDeterminableFairValueDownwardPriceAdjustmentCumulativeAmount: number;
  equitySecuritiesWithoutReadilyDeterminableFairValueUpwardPriceAdjustmentAnnualAmount: number;
  equitySecuritiesWithoutReadilyDeterminableFairValueUpwardPriceAdjustmentCumulativeAmount: number;
  cashAndCashEquivalentsAtCarryingValue: number;
  cashAndCashEquivalentsFairValueDisclosure: number;
  cashAndCashEquivalentsPeriodIncreaseDecrease: number;
  cashCashEquivalentsAndShortTermInvestments: number;
  purchaseObligation: number;
  adjustmentsToAdditionalPaidInCapitalSharebasedCompensationRequisiteServicePeriodRecognitionValue: number;
  noncontrollinglongerestIncreaseFromSaleOfParentEquitylongerest: number;
  liabilities: number;
  liabilitiesAndStockholdersEquity: number;
  liabilitiesCurrent: number;
  proceedsFromSaleOfPropertyPlantAndEquipment: number;
  longerestCostsCapitalized: number;
  longerestExpense: number;
  generalAndAdministrativeExpense: number;
  propertyPlantAndEquipmentGross: number;
  propertyPlantAndEquipmentNet: number;
  allocatedShareBasedCompensationExpense: number;
  costMethodInvestments: number;
  costMethodInvestmentsFairValueDisclosure: number;
  longerestIncomeOther: number;
  longerestPaidNet: number;
  sellingAndMarketingExpense: number;
  goodwill: number;
  goodwillAcquiredDuringPeriod: number;
  allowanceForDoubtfulAccountsReceivableCurrent: number;
  nonoperatingIncomeExpense: number;
  stockholdersEquity: number;
  goodwillImpairmentLoss: number;
  goodwillTransfers: number;
  goodwillTranslationAndPurchaseAccountingAdjustments: number;
  finiteLivedlongangibleAssetsAccumulatedAmortization: number;
  finiteLivedlongangibleAssetsAmortizationExpenseAfterYearFive: number;
  finiteLivedlongangibleAssetsAmortizationExpenseNextTwelveMonths: number;
  finiteLivedlongangibleAssetsAmortizationExpenseYearFive: number;
  finiteLivedlongangibleAssetsAmortizationExpenseYearFour: number;
  finiteLivedlongangibleAssetsAmortizationExpenseYearThree: number;
  finiteLivedlongangibleAssetsAmortizationExpenseYearTwo: number;
  finiteLivedlongangibleAssetsGross: number;
  finiteLivedlongangibleAssetsNet: number;
  earningsPerShareBasic: number;
  earningsPerShareDiluted: number;
  revenueFromContractWithCustomerExcludingAssessedTax: number;
  ociBeforeReclassificationsNetOfTaxAttributableToParent: number;
  effectiveIncomeTaxRateContinuingOperations: number;
  effectiveIncomeTaxRateReconciliationAtFederalStatutoryIncomeTaxRate: number;
  effectiveIncomeTaxRateReconciliationChangeInDeferredTaxAssetsValuationAllowance: number;
  effectiveIncomeTaxRateReconciliationChangeInEnactedTaxRate: number;
  effectiveIncomeTaxRateReconciliationForeignIncomeTaxRateDifferential: number;
  costOfRevenue: number;
  effectiveIncomeTaxRateReconciliationNondeductibleExpenseShareBasedCompensationCost: number;
  effectiveIncomeTaxRateReconciliationOtherAdjustments: number;
  effectiveIncomeTaxRateReconciliationTaxCreditsResearch: number;
  retainedEarningsAccumulatedDeficit: number;
  costsAndExpenses: number;
  repaymentsOfDebtAndCapitalLeaseObligations: number;
  effectOfExchangeRateOnCashAndCashEquivalents: number;
  cumulativeEffectOfNewAccountingPrincipleInPeriodOfAdoption: number;
  currentFederalStateAndLocalTaxExpenseBenefit: number;
  operatingIncomeLoss: number;
  unrecognizedTaxBenefitsThatWouldImpactEffectiveTaxRate: number;
  stockIssuedDuringPeriodValueNewIssues: number;
  stockRepurchasedAndRetiredDuringPeriodValue: number;
  currentForeignTaxExpenseBenefit: number;
  currentIncomeTaxExpenseBenefit: number;
  operatingLeasesFutureMinimumPaymentsDue: number;
  operatingLeasesFutureMinimumPaymentsDueCurrent: number;
  operatingLeasesFutureMinimumPaymentsDueInFiveYears: number;
  operatingLeasesFutureMinimumPaymentsDueInFourYears: number;
  operatingLeasesFutureMinimumPaymentsDuelonghreeYears: number;
  operatingLeasesFutureMinimumPaymentsDuelongwoYears: number;
  operatingLeasesFutureMinimumPaymentsDueThereafter: number;
  operatingLeasesFutureMinimumPaymentsReceivable: number;
  operatingLeasesFutureMinimumPaymentsReceivableCurrent: number;
  operatingLeasesFutureMinimumPaymentsReceivableInFiveYears: number;
  operatingLeasesFutureMinimumPaymentsReceivableInFourYears: number;
  operatingLeasesFutureMinimumPaymentsReceivablelonghreeYears: number;
  operatingLeasesFutureMinimumPaymentsReceivablelongwoYears: number;
  operatingLeasesFutureMinimumPaymentsReceivableThereafter: number;
  debtAndEquitySecuritiesGainLoss: number;
  variablelongerestEntityConsolidatedAssetsPledged: number;
  variablelongerestEntityConsolidatedLiabilitiesNoRecourse: number;
  researchAndDevelopmentExpense: number;
  debtInstrumentUnamortizedDiscount: number;
  debtSecuritiesAvailableForSaleRealizedLoss: number;
  debtSecuritiesAvailableForSaleUnrealizedLossPosition: number;
  debtSecuritiesAvailableForSaleUnrealizedLossPositionAccumulatedLoss: number;
  debtSecuritiesAvailableForSaleContinuousUnrealizedLossPositionLessThan12MonthsAccumulatedLoss: number;
  debtSecuritiesAvailableForSaleContinuousUnrealizedLossPositionLessThan12Months: number;
  debtSecuritiesAvailableForSaleContinuousUnrealizedLossPosition12MonthsOrLongerAccumulatedLoss: number;
  debtSecuritiesAvailableForSaleContinuousUnrealizedLossPosition12MonthsOrLonger: number;
  debtSecuritiesAvailableForSaleRealizedGain: number;
  debtSecuritiesRealizedGainLoss: number;
  shareBasedCompensation: number;
  taxCreditCarryforwardAmount: number;
  otherLiabilitiesNoncurrent: number;
  otherLongTermInvestments: number;
  otherNoncashIncomeExpense: number;
  otherNonoperatingIncomeExpense: number;
  reclassificationFromAociCurrentPeriodNetOfTaxAttributableToParent: number;
}

export interface AdvancedFundamentals {
  accountsPayable: number;
  accountsPayableTurnover: number;
  accountsReceivable: number;
  accountsReceivableTurnover: number;
  asOfDate: string;
  assetsCurrentCash: number;
  assetsCurrentCashRestricted: number;
  assetsCurrentDeferredCompensation: number;
  assetsCurrentDeferredTax: number;
  assetsCurrentDiscontinuedOperations: number;
  assetsCurrentInvestments: number;
  assetsCurrentLeasesOperating: number;
  assetsCurrentLoansNet: number;
  assetsCurrentOther: number;
  assetsCurrentSeparateAccounts: number;
  assetsCurrentUnadjusted: number;
  assetsFixed: number;
  assetsFixedDeferredCompensation: number;
  assetsFixedDeferredTax: number;
  assetsFixedDiscontinuedOperations: number;
  assetsFixedLeasesOperating: number;
  assetsFixedOperatingDiscontinuedOperations: number;
  assetsFixedOperatingSubsidiaryUnconsolidated: number;
  assetsFixedOreo: number;
  assetsFixedOther: number;
  assetsFixedUnconsolidated: number;
  assetsUnadjusted: number;
  capex: number;
  capexAcquisition: number;
  capexMaintenance: number;
  cashConversionCycle: number;
  cashFlowFinancing: number;
  cashFlowInvesting: number;
  cashFlowOperating: number;
  cashFlowShareRepurchase: number;
  cashLongTerm: number;
  cashOperating: number;
  cashPaidForIncomeTaxes: number;
  cashPaidForInterest: number;
  cashRestricted: number;
  chargeAfterTax: number;
  chargeAfterTaxDiscontinuedOperations: number;
  chargesAfterTaxOther: number;
  cik: string;
  creditLossProvision: number;
  dataGenerationDate: string;
  daysInAccountsPayable: number;
  daysInInventory: number;
  daysInRevenueDeferred: number;
  daysRevenueOutstanding: number;
  debtFinancial: number;
  debtShortTerm: number;
  depreciationAndAmortizationAccumulated: number;
  depreciationAndAmortizationCashFlow: number;
  dividendsPreferred: number;
  dividendsPreferredRedeemableMandatorily: number;
  earningsRetained: number;
  ebitReported: number;
  ebitdaReported: number;
  equityShareholder: number;
  equityShareholderOther: number;
  equityShareholderOtherDeferredCompensation: number;
  equityShareholderOtherEquity: number;
  equityShareholderOtherMezzanine: number;
  expenses: number;
  expensesAcquisitionMerger: number;
  expensesCompensation: number;
  expensesDepreciationAndAmortization: number;
  expensesDerivative: number;
  expensesDiscontinuedOperations: number;
  expensesDiscontinuedOperationsReits: number;
  expensesEnergy: number;
  expensesForeignCurrency: number;
  expensesInterest: number;
  expensesInterestFinancials: number;
  expensesInterestMinority: number;
  expensesLegalRegulatoryInsurance: number;
  expensesNonOperatingCompanyDefinedOther: number;
  expensesNonOperatingOther: number;
  expensesNonOperatingSubsidiaryUnconsolidated: number;
  expensesNonRecurringOther: number;
  expensesOperating: number;
  expensesOperatingOther: number;
  expensesOperatingSubsidiaryUnconsolidated: number;
  expensesOreo: number;
  expensesOreoReits: number;
  expensesOtherFinancing: number;
  expensesRestructuring: number;
  expensesSga: number;
  expensesStockCompensation: number;
  expensesWriteDown: number;
  ffo: number;
  figi: string;
  filingDate: string;
  filingType: string;
  fiscalQuarter: number;
  fiscalYear: number;
  goodwillAmortizationCashFlow: number;
  goodwillAmortizationIncomeStatement: number;
  goodwillAndIntangiblesNetOther: number;
  goodwillNet: number;
  incomeFromOperations: number;
  incomeNet: number;
  incomeNetPerRevenue: number;
  incomeNetPerWabso: number;
  incomeNetPerWabsoSplitAdjusted: number;
  incomeNetPerWabsoSplitAdjustedYoyDeltaPercent: number;
  incomeNetPerWadso: number;
  incomeNetPerWadsoSplitAdjusted: number;
  incomeNetPerWadsoSplitAdjustedYoyDeltaPercent: number;
  incomeNetPreTax: number;
  incomeNetYoyDelta: number;
  incomeOperating: number;
  incomeOperatingDiscontinuedOperations: number;
  incomeOperatingOther: number;
  incomeOperatingSubsidiaryUnconsolidated: number;
  incomeOperatingSubsidiaryUnconsolidatedAfterTax: number;
  incomeTax: number;
  incomeTaxCurrent: number;
  incomeTaxDeferred: number;
  incomeTaxDiscontinuedOperations: number;
  incomeTaxOther: number;
  incomeTaxRate: number;
  interestMinority: number;
  inventory: number;
  inventoryTurnover: number;
  liabilities: number;
  liabilitiesCurrent: number;
  liabilitiesNonCurrentAndInterestMinorityTotal: number;
  liabilitiesNonCurrentDebt: number;
  liabilitiesNonCurrentDeferredCompensation: number;
  liabilitiesNonCurrentDeferredTax: number;
  liabilitiesNonCurrentDiscontinuedOperations: number;
  liabilitiesNonCurrentLeasesOperating: number;
  liabilitiesNonCurrentLongTerm: number;
  liabilitiesNonCurrentOperatingDiscontinuedOperations: number;
  liabilitiesNonCurrentOther: number;
  nibclDeferredCompensation: number;
  nibclDeferredTax: number;
  nibclDiscontinuedOperations: number;
  nibclLeasesOperating: number;
  nibclOther: number;
  nibclRestructuring: number;
  nibclRevenueDeferred: number;
  nibclRevenueDeferredTurnover: number;
  nibclSeparateAccounts: number;
  oci: number;
  periodEndDate: string;
  ppAndENet: number;
  pricePerEarnings: number;
  pricePerEarningsPerRevenueYoyDeltaPercent: number;
  profitGross: number;
  profitGrossPerRevenue: number;
  researchAndDevelopmentExpense: number;
  reserves: number;
  reservesInventory: number;
  reservesLifo: number;
  reservesLoanLoss: number;
  revenue: number;
  revenueCostOther: number;
  revenueIncomeInterest: number;
  revenueOther: number;
  revenueSubsidiaryUnconsolidated: number;
  salesCost: number;
  sharesIssued: number;
  sharesOutstandingPeDateBs: number;
  sharesTreasury: number;
  stockCommon: number;
  stockPreferred: number;
  stockPreferredEquity: number;
  stockPreferredMezzanine: number;
  stockTreasury: number;
  symbol: string;
  wabso: number;
  wabsoSplitAdjusted: number;
  wadso: number;
  wadsoSplitAdjusted: number;
  id: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: string | Date;
}

export interface InsiderRoster {
  symbol?: string;
  entityName: string;
  position: number;
  reportDate: string | Date;
}

export interface InsiderSummary {
  fullName: string;
  netTransacted: number;
  reportedTitle: string;
  symbol: string;
  totalBought: number;
  totalSold: number;
  id: string;
  key: string;
  subkey: string;
  updated: string | Date;
}

export interface InsiderTransaction {
  conversionOrExercisePrice: number;
  directIndirect: string;
  effectiveDate: string | Date;
  filingDate: string | Date;
  fullName: string;
  is10b51: boolean;
  postShares: number;
  reportedTitle: string;
  symbol: string;
  transactionCode: string;
  transactionDate: string | Date;
  transactionPrice: number;
  transactionShares: number;
  transactionValue: number;
  id: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: string | Date;
  tranPrice: number;
  tranShares: number;
  tranValue: number;
}

export interface IntradayPrice {
  symbol: string;
  date: string;
  minute: string;
  label: string;
  high: number;
  low: number;
  open: number;
  close: number;
  average: number;
  volume: number;
  notional: number;
  numberOfTrades: number;
  changeOverTime: number;
  marketOpen: number;
  marketClose: number;
  marketHigh: number;
  marketLow: number;
  marketAverage: number;
  marketVolume: number;
  marketNotional: number;
  marketNumberOfTrades: number;
  marketChangeOverTime: number;
}

export interface LargestTrade {
  symbol?: string;
  price: number;
  size: number;
  time: number;
  timeLabel: string;
  venue: string;
  venueName: string;
}

export interface DividendsForecast {
  adjustedAmount: number;
  amount: number;
  currency: string;
  declaredDate: string | Date;
  disbursementAmount: number;
  disbursementType: string;
  exDate: string | Date;
  fiscalYear: string;
  fiscalYearEndDate: string | Date;
  frequency: string;
  fxDate: string | Date;
  lastChange: string | Date;
  marker: string;
  name: string;
  nonTaxedAmount: number;
  paymentDate: string | Date;
  periodEndDate: string | Date;
  position: number;
  recordDate: string | Date;
  recordUpdated: string | Date;
  sharesHeld: number;
  sharesReceived: number;
  status: string;
  symbol: string;
  id: string;
  key: string;
  subKey: string;
  netAmount: number;
  date: string | Date;
  updated: string | Date;
}

export interface OpenClosePrice {
  symbol?: string;
  open: number;
  close: number;
  high: number;
  low: number;
}

export interface PreviousDayPrice {
  symbol?: string;
  date: string | Date;
  minute: string;
  close: number;
  high: number;
  low: number;
  open: number;
  volume: number;
  id: string;
  key: string;
  subkey: string;
  updated: string | Date;
  changeOverTime: number;
  marketChangeOverTime: number;
  uOpen: number;
  uClose: number;
  uHigh: number;
  uLow: number;
  uVolume: number;
  fOpen: number;
  fClose: number;
  fHigh: number;
  fLow: number;
  fVolume: number;
  label: string;
  change: number;
  changePercent: number;
}

export interface ReturnOfCapital {
  withdrawalFromDate: string | Date;
  withdrawalToDate: string | Date;
  electionDate: string | Date;
  cashBack: number;
  hasWithdrawalRights: number;
  currency: string;
  symbol: string;
  exDate: string | Date;
  recordDate: string | Date;
  paymentDate: string | Date;
  fromFactor: number;
  toFactor: number;
  ratio: number;
  description: string;
  flag: string;
  securityType: string;
  notes: string;
  figi: string;
  lastUpdated: string | Date;
  countryCode: string;
  parValue: number;
  parValueCurrency: string;
  refid: number;
  created: string | Date;
  id: string;
  source: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: string | Date;
}

export interface RightToPurchase {
  subscriptionStart: string | Date;
  subscriptionEnd: string | Date;
  issuePrice: number;
  resultSecurityType: string;
  isOverSubscription: boolean;
  currency: string;
  symbol: string;
  exDate: string | Date;
  recordDate: string | Date;
  paymentDate: string | Date;
  fromFactor: number;
  toFactor: number;
  ratio: number;
  description: string;
  flag: string;
  securityType: string;
  notes: string;
  figi: string;
  lastUpdated: string | Date;
  countryCode: string;
  parValue: number;
  parValueCurrency: string;
  refid: number;
  created: string | Date;
  id: string;
  source: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: string | Date;
}

export interface SecurityReclassification {
  resultSecurityType: string;
  symbol: string;
  exDate: string | Date;
  recordDate: string | Date;
  paymentDate: string | Date;
  fromFactor: number;
  toFactor: number;
  ratio: number;
  description: string;
  flag: string;
  securityType: string;
  notes: string;
  figi: string;
  lastUpdated: string | Date;
  countryCode: string;
  parValue: number;
  parValueCurrency: string;
  refid: number;
  created: string | Date;
  id: string;
  source: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: string | Date;
}

export interface RightsIssue {
  subscriptionStartDate: string | Date;
  subscriptionEndDate: string | Date;
  tradeStartDate: string | Date;
  tradeEndDate: string | Date;
  splitDate: string | Date;
  resultSecurityType: string;
  currency: string;
  issuePrice: number;
  lapsedPremium: number;
  isOverSubscription: true;
  symbol: string;
  exDate: string | Date;
  recordDate: string | Date;
  paymentDate: string | Date;
  fromFactor: number;
  toFactor: number;
  ratio: number;
  description: string;
  flag: string;
  securityType: string;
  notes: string;
  figi: string;
  lastUpdated: string | Date;
  countryCode: string;
  parValue: number;
  parValueCurrency: string;
  refid: number;
  created: string | Date;
  id: string;
  source: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: 0
}

export interface Spinoff {
  withdrawalFromDate: string | Date;
  withdrawalToDate: string | Date;
  electionDate: string | Date;
  effectiveDate: string | Date;
  minPrice: number;
  maxPrice: number;
  hasWithdrawalRights: number;
  currency: string;
  symbol: string;
  exDate: string | Date;
  recordDate: string | Date;
  paymentDate: string | Date;
  fromFactor: number;
  toFactor: number;
  ratio: number;
  description: string;
  flag: string;
  securityType: string;
  notes: string;
  figi: string;
  lastUpdated: string | Date;
  countryCode: string;
  parValue: number;
  parValueCurrency: string;
  refid: number;
  created: string | Date;
  id: string;
  source: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: string | Date;
}

 export interface HistoricalPrice {
  symbol?: string;
  date?: string | Date;
  minute?: string;
  close?: number;
  high?: number;
  low?: number;
  open?: number;
  volume?: number;
  id?: string;
  key?: string;
  subkey?: string;
  updated?: string | Date;
  changeOverTime?: number;
  marketChangeOverTime?: number;
  uOpen?: number;
  uClose?: number;
  uHigh?: number;
  uLow?: number;
  uVolume?: number;
  fOpen?: number;
  fClose?: number;
  fHigh?: number;
  fLow?: number;
  fVolume?: number;
  label?: string | Date;
  change?: number;
  changePercent?: number;
 }

export interface IncomeStatement {
  symbol?: string;
  reportDate: string | Date;
  fiscalDate: string | Date;
  fiscalQuarter: number;
  fiscalYear: number;
  currency: string;
  totalRevenue: number;
  costOfRevenue: number;
  grossProfit: number;
  researchAndDevelopment: number;
  sellingGeneralAndAdmin: number;
  operatingExpense: number;
  operatingIncome: number;
  otherIncomeExpenseNet: number;
  ebit: number;
  interestIncome: number;
  pretaxIncome: number;
  incomeTax: number;
  minorityInterest: number;
  netIncome: number;
  netIncomeBasic: number;
}

export interface SplitsBasic {
  declaredDate: string | Date;
  description: string;
  exDate: string | Date;
  date: string | Date;
  fromFactor: number;
  ratio: number;
  refid: number;
  symbol: string;
  toFactor: number;
  id: string;
  key: string;
  subkey: string;
  updated: string | Date;
}

export interface UpcomingEvent {
  ipos: IPO[],
  earnings: Earning[],
  dividends: DividendsBasic[],
  splits: SplitsBasic[],
}

export interface IPO {
  rawData: RawData[];
  viewData: ViewData[];
  lastUpdate: string | Date;
}

export interface RawData {
  symbol: string;
  companyName: string;
  expectedDate: string | Date;
  leadUnderwriters: string[];
  underwriters: string[];
  companyCounsel: string[];
  underwriterCounsel: string[];
  auditor: string;
  market: string;
  cik: string;
  address: string;
  city: string;
  state: string;
  zip: string;
  phone: string;
  ceo: string;
  employees: number;
  url: string;
  status: string;
  sharesOffered: number;
  priceLow: number;
  priceHigh: number;
  offerAmount: number;
  totalExpenses: number;
  sharesOverAlloted: number;
  shareholderShares: number;
  sharesOutstanding: number;
  lockupPeriodExpiration: string;
  quietPeriodExpiration: string;
  revenue: number;
  netIncome: number;
  totalAssets: number;
  totalLiabilities: number;
  stockholderEquity: number;
  companyDescription: string;
  businessDescription: string;
  useOfProceeds: string;
  competition: string;
  amount: number;
  percentOffered: string;
}

export interface ViewData {
  company: string;
  symbol: string;
  price: string;
  shares: string;
  amount: string;
  float: string;
  percent: string;
  market: string;
  expected: string;
  quote: {
    latestPrice: number;
    changePercent: number;
  }
}

export interface Earning {
  symbol: string;
  reportDate: string | Date;
}

export interface FundamentalValuation {
  accountsPayableTurnover: number;
  accountsReceivableTurnover: number;
  altmanZScore: number;
  asOfDate: string;
  assetsToEquity: number;
  assetTurnover: number;
  bbgCompositeTicker: string;
  bookValuePerShare: number;
  cashConversionCycle: number;
  cik: string;
  companyName: string;
  companyStatusCurrent: string;
  currentRatio: number;
  dataGenerationDate: string | Date;
  dataType: string;
  daysInAccountsPayable: number;
  daysInInventory: number;
  daysInRevenueDeferred: number;
  daysRevenueOutstanding: number;
  debtToAssets: number;
  debtToCapitalization: number;
  debtToEbitda: number;
  debtToEquity: number;
  dividendPerShare: number;
  dividendYield: number;
  earningsYield: number;
  ebitdaGrowth: number;
  ebitdaMargin: number;
  ebitdaReported: number;
  ebitGrowth: number;
  ebitReported: number;
  ebitToInterestExpense: number;
  ebitToRevenue: number;
  enterpriseValue: number;
  evToEbit: number;
  evToEbitda: number;
  evToFcf: number;
  evToInvestedCapital: number;
  evToNopat: number;
  evToOcf: number;
  evToSales: number;
  expenseOperating: number;
  fcfYield: number;
  figi: string;
  filingDate: string;
  filingType: string;
  fiscalQuarter: number;
  fiscalYear: number;
  fixedAssetTurnover: number;
  freeCashFlow: number;
  freeCashFlowGrowth: number;
  freeCashFlowToRevenue: number;
  goodwillTotal: number;
  incomeNetPerWabso: number;
  incomeNetPerWabsoSplitAdjusted: number;
  incomeNetPerWabsoSplitAdjustedYoyDeltaPercent: number;
  incomeNetPerWadso: number;
  incomeNetPerWadsoSplitAdjusted: number;
  incomeNetPerWadsoSplitAdjustedYoyDeltaPercent: number;
  incomeNetPreTax: number;
  interestBurden: number;
  interestMinority: number;
  inventoryTurnover: number;
  investedCapital: number;
  investedCapitalGrowth: number;
  investedCapitalTurnover: number;
  leverage: number;
  marketCapPeriodEnd: number;
  netDebt: number;
  netDebtToEbitda: number;
  netIncomeGrowth: number;
  netIncomeToRevenue: number;
  netWorkingCapital: number;
  netWorkingCapitalGrowth: number;
  nibclRevenueDeferredTurnover: number;
  nopat: number;
  nopatGrowth: number;
  nopatMargin: number;
  operatingCashFlowGrowth: number;
  operatingCashFlowInterestCoverage: number;
  operatingCfToRevenue: number;
  operatingIncome: number;
  operatingIncomeToRevenue: number;
  operatingReturnOnAssets: number;
  periodEndDate: string | Date;
  ppAndENet: number;
  preferredEquityToCapital: number;
  pretaxIncomeMargin: number;
  priceAccountingPeriodEnd: number;
  priceDateAccountingPeriodEnd: string;
  priceToRevenue: number;
  profitGrossToRevenue: number;
  pToBv: number;
  pToE: number;
  quickRatio: number;
  researchDevelopmentToRevenue: number;
  returnOnAssets: number;
  returnOnEquity: number;
  revenueGrowth: number;
  roce: number;
  roic: number;
  scexhid: number;
  secid: number;
  sgaToRevenue: number;
  stockExchange: string;
  symbol: string;
  taxBurden: number;
  ticker: string;
  totalCapital: number;
  totalDebt: number;
  updateReason: string;
  wabso: number;
  wabsoSplitAdjusted: number;
  wadso: number;
  wadsoSplitAdjusted: number;
  workingCapitalTurnover: number;
  id: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: string | Date;
}

export interface FundOwnership {
  symbol: string;
  adjHolding: number;
  adjMv: number;
  entityProperName: string;
  report_date: string | Date;
  reportedHolding: number;
  reportedMv: number;
  id: string;
  source: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: string | Date;
}

export interface InstitutionalOwnership {
  symbol: string;
  id: string;
  adjHolding: number;
  adjMv: number;
  entityProperName: string;
  reportDate: string | Date;
  filingDate: string | Date;
  reportedHolding: number;
  date: string | Date;
  updated: string | Date;
}

export interface Split {
  splitType: string;
  oldParValue: number;
  oldParValueCurrency: string;
  symbol: string;
  exDate: string | Date;
  recordDate: string | Date;
  paymentDate: string | Date;
  fromFactor: number;
  toFactor: number;
  ratio: number;
  description: string;
  flag: string;
  securityType: string;
  notes: string;
  figi: string;
  lastUpdated: string | Date;
  countryCode: string;
  parValue: number;
  parValueCurrency: string;
  refid: number;
  created: string | Date;
  id: string;
  source: string;
  key: string;
  subkey: string;
  date: string | Date;
  updated: string | Date;
}

export interface VolumeByVenue {
  symbol?: string;
  volume: number;
  venue: string;
  venueName: string;
  marketPercent: number;
  avgMarketPercent: number;
  date: string | Date;
}

export interface AdvancedStat {
  totalCash: number;
  currentDebt: number;
  revenue: number;
  grossProfit: number;
  totalRevenue: number;
  ebitda: number;
  revenuePerShare: number;
  revenuePerEmployee: number;
  debtToEquity: number;
  profitMargin: number;
  enterpriseValue: number;
  enterpriseValueToRevenue: number;
  priceToSales: number;
  priceToBook: number;
  forwardPERatio: number;
  pegRatio: number;
  peHigh: number;
  peLow: number;
  week52highDate: string | Date;
  week52lowDate: string | Date;
  putCallRatio: number;
  companyName: string,
  marketcap: number;
  week52high: number;
  week52low: number;
  week52change: number;
  sharesOutstanding: number;
  symbol: string,
  avg10Volume: number;
  avg30Volume: number;
  day200MovingAvg: number;
  day50MovingAvg: number;
  employees: number;
  ttmEPS: number;
  ttmDividendRate: number;
  dividendYield: number;
  nextDividendDate: string | Date;
  exDividendDate: string | Date;
  peRatio: number;
  beta: number;
  maxChangePercent: number;
  year5ChangePercent: number;
  year2ChangePercent: number;
  year1ChangePercent: number;
  ytdChangePercent: number;
  month6ChangePercent: number;
  month3ChangePercent: number;
  month1ChangePercent: number;
  day30ChangePercent: number;
  day5ChangePercent: number;
}

export interface KeyStat {
  companyName: string;
  marketcap: number;
  week52high: number;
  week52low: number;
  week52change: number;
  sharesOutstanding: number;
  symbol: string;
  avg10Volume: number;
  avg30Volume: number;
  day200MovingAvg: number;
  day50MovingAvg: number;
  employees: number;
  ttmEPS: number;
  ttmDividendRate: number;
  dividendYield: number;
  nextDividendDate: string | Date,
  exDividendDate: string | Date,
  peRatio: number;
  beta: number;
  maxChangePercent: number;
  year5ChangePercent: number;
  year2ChangePercent: number;
  year1ChangePercent: number;
  ytdChangePercent: number;
  month6ChangePercent: number;
  month3ChangePercent: number;
  month1ChangePercent: number;
  day30ChangePercent: number;
  day5ChangePercent: number;
}

export interface TechnicalIndicator {
  indicator: string[];
  chart: Chart[],
}

export interface Chart {
  additionalProp1: string;
  additionalProp2: string;
  additionalProp3: string;
}

export interface IpoCalendar {
  currentPrice: number;
  filedDate: string | Date;
  firstDayClose: number;
  status: string;
  companyName: string;
  lockupPeriod: string;
  managers: string;
  offeringDate: string | Date;
  offerPrice: number;
  priceRangeHigh: number;
  priceRangeLow: number;
  quietperiod: string;
  returnValue: number;
  shares: number;
  symbol: string;
  updated: string | Date;
  volume: number;
}

export interface Logo{
  url: string;
}
