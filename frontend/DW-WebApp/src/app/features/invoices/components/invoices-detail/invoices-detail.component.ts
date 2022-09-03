import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AlertService } from 'src/app/shared/services/alert.service';
import { InvoicesService } from '../../services/invoices.service';
import { Invoice } from '../models/invoice';
import { InvoiceCustomer } from '../models/invoice-customer';
import { InvoiceDetail } from '../models/invoice-detail';
import { InvoiceDetailProduct } from '../models/invoice-detail-product';

@Component({
  selector: 'app-invoices-detail',
  templateUrl: './invoices-detail.component.html',
  styleUrls: ['./invoices-detail.component.css']
})
export class InvoicesDetailComponent {

  invoice: Invoice;
  customers: InvoiceCustomer[] = [];
  products: InvoiceDetailProduct[] = [];
  customerSelected: InvoiceCustomer;
  invoiceDetailCurrent: InvoiceDetail;

  get total(): number {
    return this.invoice.invoiceDetails.reduce((accumulator, obj) => {
      return accumulator + obj.subTotal;
    }, 0);
  }

  constructor(private router: Router,
              private invoicesService: InvoicesService,
              private alertService: AlertService) 
  {
    this.invoice = new Invoice();
    this.invoice.invoiceDetails = [];
    this.customerSelected = new InvoiceCustomer();
    this.invoiceDetailCurrent = new InvoiceDetail();
  }

  ngOnInit(): void {
    this.loadCustomers();
    this.loadProducts();
  }

  onSaveClick(): void {
    this.invoice.total = this.total;
    this.invoicesService.saveInvoice(this.invoice).subscribe({
      next: this.onSuccess.bind(this),
      error: ({ message }) => { this.onError(message) }
    });
  }

  onAddProductClick(): void {
    this.invoiceDetailCurrent.subTotal = this.invoiceDetailCurrent.productPrice * this.invoiceDetailCurrent.quantity;
    this.invoice.invoiceDetails.push(this.invoiceDetailCurrent);
    this.invoiceDetailCurrent = new InvoiceDetail();
  }

  onCustomerChanged(e: any): void {
    const customer = this.customers.find(x => x.id === e.value);
    this.customerSelected.identificationDocument = customer?.identificationDocument;
    this.customerSelected.phone = customer!.phone;
  }

  onProductChanged(e: any): void {
    if (!e.value) { return; }

    const product = this.products.find(x => x.id === e.value);
    this.invoiceDetailCurrent.productName = product!.name;
    this.invoiceDetailCurrent.productPrice = product!.price;
  }

  goToList(): void {
    this.router.navigate(['/ventas/listado']);
  }

  private onSuccess(): void {
    this.alertService.showSuccessMessage('El Producto se guardó con éxito');
    this.goToList();
  }

  private onError(error: string) {
    this.alertService.showErrorMessage(error);
  }

  private loadCustomers() : void {
    this.invoicesService.getCustomers().subscribe((datos) => {
      this.customers = datos;
    });
  }

  private loadProducts() : void {
    this.invoicesService.getProducts().subscribe((datos) => {
      this.products = datos;
    });
  }
}
