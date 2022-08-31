import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvoicesDetailComponent } from './components/invoices-detail/invoices-detail.component';
import { InvoicesListComponent } from './components/invoices-list/invoices-list.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'detalles',
        component: InvoicesDetailComponent
      },
      {
        path: 'listado',
        component: InvoicesListComponent
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
export class InvoicesRoutingModule { }
