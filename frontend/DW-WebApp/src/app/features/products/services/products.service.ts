import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDetail } from '../models/product-detail';
import { ProductList } from '../models/product-list';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  baseUrl: string = 'https://localhost:5001/api';
  
  constructor(private http: HttpClient) { }

  getProducts(): Observable<ProductList[]> {
    return this.http.get<ProductList[]>(`${this.baseUrl}/products`);
  }

  getProduct(productId: number) : Observable<ProductDetail> {
    return this.http.get<ProductDetail>(`${this.baseUrl}/products/${productId}`);
  }

  saveProduct(product: ProductDetail): Observable<ProductDetail> {
    return product.id && product.id !== 0 ? this.putProduct(product) : this.postProduct(product);
  }

  deleteProduct(categoryId: number) : Observable<any> {
    return this.http.delete(`${this.baseUrl}/products/${categoryId}`);
  }

  private postProduct(product: ProductDetail): Observable<ProductDetail> {
    return this.http.post<ProductDetail>(`${this.baseUrl}/products`, product);
  }

  private putProduct(product: ProductDetail): Observable<ProductDetail> {
    return this.http.put<ProductDetail>(`${this.baseUrl}/products`, product);
  }
}
