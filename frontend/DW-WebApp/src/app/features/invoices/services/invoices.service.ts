import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Invoice } from '../components/models/invoice';
import { InvoiceCustomer } from '../components/models/invoice-customer';
import { InvoiceDetailProduct } from '../components/models/invoice-detail-product';
import { InvoiceList } from '../components/models/invoice-list';

@Injectable({
  providedIn: 'root'
})
export class InvoicesService {

  baseUrl: string = environment.API_URL;
  
  constructor(private http: HttpClient) { }

  getInvoices(): Observable<InvoiceList[]> {
    return this.http.get<InvoiceList[]>(`${this.baseUrl}/invoices`);
  }

  saveInvoice(invoice: Invoice): Observable<Invoice> {
    return this.http.post<Invoice>(`${this.baseUrl}/invoices`, invoice);
  }

  getCustomers(): Observable<InvoiceCustomer[]> {
    return this.http.get<InvoiceCustomer[]>(`${this.baseUrl}/customers`);
  }

  getProducts(): Observable<InvoiceDetailProduct[]> {
    return this.http.get<InvoiceDetailProduct[]>(`${this.baseUrl}/products`);
  }
}
