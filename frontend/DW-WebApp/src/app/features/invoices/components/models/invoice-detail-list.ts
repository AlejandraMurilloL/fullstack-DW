import { InvoiceDetailProduct } from './invoice-detail-product';

export class InvoiceDetailList {
    invoiceId!: number;
    product!: InvoiceDetailProduct;
    quantity!: number;
    subTotal!: number;
}