import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryDetailComponent } from './components/category-detail/category-detail.component';
import { CategoryListComponent } from './components/category-list/category-list.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'nuevo',
        component: CategoryDetailComponent
      },
      {
        path: 'editar/:id',
        component: CategoryDetailComponent
      },
      {
        path: 'listado',
        component: CategoryListComponent
      },
      {
        path: '**',
        redirectTo: 'listado'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriesRoutingModule { }
