import { Customer } from './customer.model';

export class FinancialSummaryMonth {

    constructor() { }

    id: string;
    customerId: string;
    customer: Customer;
    month: number;
    year: number;
    storeRevenue: number;
    marketplaceRevenue: number;
    totalOrders: number;
    totalItemsSold: number;
    paidOrders: number;
    visitors: number;
    pageViews: number;
    adsInvestment: number;
}
