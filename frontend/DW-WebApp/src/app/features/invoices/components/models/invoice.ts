import { InvoiceDetail } from './invoice-detail';

export class Invoice {
    customerId!: number;
    num?: string;
    date?: Date;
    total!: number;
    invoiceDetails!: InvoiceDetail[];
}