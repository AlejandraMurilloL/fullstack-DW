import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CustomerDetail } from '../models/customer-detail';
import { CustomerList } from '../models/customer-list';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  baseUrl: string = environment.API_URL;
  
  constructor(private http: HttpClient) { }

  getCustomers(): Observable<CustomerList[]> {
    return this.http.get<CustomerList[]>(`${this.baseUrl}/customers`);
  }

  getCustomer(customerId: number) : Observable<CustomerDetail> {
    return this.http.get<CustomerDetail>(`${this.baseUrl}/customers/${customerId}`);
  }

  saveCustomer(customer: CustomerDetail): Observable<CustomerDetail> {
    return customer.id && customer.id !== 0 ? this.putCustomer(customer) : this.postCustomer(customer);
  }

  deleteCustomer(customerId: number) : Observable<any> {
    return this.http.delete(`${this.baseUrl}/customers/${customerId}`);
  }

  private postCustomer(customer: CustomerDetail): Observable<CustomerDetail> {
    return this.http.post<CustomerDetail>(`${this.baseUrl}/customers`, customer);
  }

  private putCustomer(customer: CustomerDetail): Observable<CustomerDetail> {
    return this.http.put<CustomerDetail>(`${this.baseUrl}/customers`, customer);
  }
}
