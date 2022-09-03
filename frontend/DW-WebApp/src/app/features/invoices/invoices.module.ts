import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { DevexpressModule } from '../../devexpress/devexpress.module';
import { InvoiceDetailsListComponent } from './components/invoice-details-list/invoice-details-list.component';
import { InvoicesDetailComponent } from './components/invoices-detail/invoices-detail.component';
import { InvoicesListComponent } from './components/invoices-list/invoices-list.component';
import { InvoicesRoutingModule } from './invoices-routing.module';


@NgModule({
  declarations: [
    InvoicesDetailComponent,
    InvoicesListComponent,
    InvoiceDetailsListComponent
  ],
  imports: [
    CommonModule,
    InvoicesRoutingModule,
    DevexpressModule
  ]
})
export class InvoicesModule { }
