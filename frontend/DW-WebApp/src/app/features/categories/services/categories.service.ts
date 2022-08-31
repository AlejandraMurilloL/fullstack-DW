import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CategoryDetail } from '../models/category-detail';
import { CategoryList } from '../models/category-list';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  baseUrl: string = environment.API_URL;
  
  constructor(private http: HttpClient) { }

  getCategories(): Observable<CategoryList[]> {
    return this.http.get<CategoryList[]>(`${this.baseUrl}/categories`);
  }

  getCategory(categoryId: number) : Observable<CategoryDetail> {
    return this.http.get<CategoryDetail>(`${this.baseUrl}/categories/${categoryId}`);
  }

  saveCategory(category: CategoryDetail): Observable<CategoryDetail> {
    return category.id && category.id !== 0 ? this.putCategory(category) : this.postCategory(category);
  }

  deleteCategory(categoryId: number) : Observable<any> {
    return this.http.delete(`${this.baseUrl}/categories/${categoryId}`);
  }

  private postCategory(category: CategoryDetail): Observable<CategoryDetail> {
    return this.http.post<CategoryDetail>(`${this.baseUrl}/categories`, category);
  }

  private putCategory(category: CategoryDetail): Observable<CategoryDetail> {
    return this.http.put<CategoryDetail>(`${this.baseUrl}/categories`, category);
  }
}
