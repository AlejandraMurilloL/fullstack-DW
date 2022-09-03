import { InvoiceCustomer } from './invoice-customer';
import { InvoiceDetailList } from './invoice-detail-list';

export class InvoiceList {
    customer!: InvoiceCustomer;
    num?: string;
    date?: Date;
    total!: number;
    invoiceDetails!: InvoiceDetailList[];
}