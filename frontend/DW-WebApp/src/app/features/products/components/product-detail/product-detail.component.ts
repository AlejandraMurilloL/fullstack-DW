import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs';
import { AlertService } from '../../../../shared/services/alert.service';
import { Category } from '../../models/category';
import { ProductDetail } from '../../models/product-detail';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  product: ProductDetail;
  categories: Category[] = [];

  constructor(private router: Router,
              private activatedRoute: ActivatedRoute,
              private productsService: ProductsService,
              private alertService: AlertService) 
  {
    this.product = new ProductDetail();
    this.product.category = new Category();
  }

  ngOnInit(): void {
    this.loadCategories();
    if (!this.router.url.includes('editar')) {
      return;
    }

    this.activatedRoute.params
      .pipe(
        switchMap(({ id }) => this.productsService.getProduct(id))
      )
      .subscribe(product => this.product = product);
  }

  onSaveClick(): void {
    this.productsService.saveProduct(this.product).subscribe({
      next: this.onSuccess.bind(this),
      error: ({ message }) => { this.onError(message) }
    });
  }

  goToList(): void {
    this.router.navigate(['/productos/listado']);
  }

  onCategoryChange() : void {
    const category = this.categories.find(x => x.id == this.product.category.id);
    this.product.category.name = category!.name;
  }

  private onSuccess(): void {
    this.alertService.showSuccessMessage('El Producto se guardó con éxito');
    this.goToList();
  }

  private onError(error: string) {
    this.alertService.showErrorMessage(error);
  }

  private loadCategories() : void {
    this.productsService.getCategories().subscribe((datos) => {
      this.categories = datos;
    });
  }
}
