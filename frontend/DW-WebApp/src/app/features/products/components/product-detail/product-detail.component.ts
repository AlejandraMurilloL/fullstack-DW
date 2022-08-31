import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import ArrayStore from 'devextreme/data/array_store';
import { switchMap } from 'rxjs';
import { Category } from '../../models/category';
import { ProductDetail } from '../../models/product-detail';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  data!: ArrayStore;
  product: ProductDetail;
  categories: Category[] = [];

  constructor(private router: Router,
              private activatedRoute: ActivatedRoute,
              private productsService: ProductsService) 
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
    this.productsService.saveProduct(this.product).subscribe(() => {
      this.router.navigate(['/productos/listado']);
    });
  }

  onBackClick(): void {
    this.router.navigate(['/productos/listado']);
  }

  private loadCategories() : void {
    this.productsService.getCategories().subscribe((datos) => {
      this.categories = datos;
      this.data = new ArrayStore({
        data: this.categories,
        key: 'id',
      });
    });
  }
}
