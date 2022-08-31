import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { DevExtremeModule } from 'devextreme-angular';
import { CustomerDetailComponent } from './components/customer-detail/customer-detail.component';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { CustomersRoutingModule } from './customers-routing.module';


@NgModule({
  declarations: [
    CustomerDetailComponent,
    CustomerListComponent
  ],
  imports: [
    CommonModule,
    CustomersRoutingModule,
    DevExtremeModule
  ]
})
export class CustomersModule { }
