import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { DevExtremeModule } from 'devextreme-angular';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductsRoutingModule } from './products-routing.module';


@NgModule({
  declarations: [
    ProductListComponent,
    ProductDetailComponent
  ],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    DevExtremeModule
  ]
})
export class ProductsModule { }
