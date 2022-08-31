import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { InvoicesDetailComponent } from './components/invoices-detail/invoices-detail.component';
import { InvoicesListComponent } from './components/invoices-list/invoices-list.component';
import { InvoicesRoutingModule } from './invoices-routing.module';


@NgModule({
  declarations: [
    InvoicesDetailComponent,
    InvoicesListComponent
  ],
  imports: [
    CommonModule,
    InvoicesRoutingModule
  ]
})
export class InvoicesModule { }
