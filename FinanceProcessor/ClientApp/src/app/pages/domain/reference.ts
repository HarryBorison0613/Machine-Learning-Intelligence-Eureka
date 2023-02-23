export interface Symbol {
    symbol?: string;
    exchange?: string;
    name?: string;
    date?: string | Date;
    type?: string;
    iexId?: string;
    region?: string;
    currency?: string;
    isEnabled?: true;
    figi?: string;
    cik?: string;
}