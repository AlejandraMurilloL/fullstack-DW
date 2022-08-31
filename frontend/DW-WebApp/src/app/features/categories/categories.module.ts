import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { DevexpressModule } from 'src/app/devexpress/devexpress.module';

import { CategoriesRoutingModule } from './categories-routing.module';
import { CategoryDetailComponent } from './components/category-detail/category-detail.component';
import { CategoryListComponent } from './components/category-list/category-list.component';


@NgModule({
  declarations: [
    CategoryDetailComponent,
    CategoryListComponent
  ],
  imports: [
    CommonModule,
    CategoriesRoutingModule,
    DevexpressModule
  ]
})
export class CategoriesModule { }
