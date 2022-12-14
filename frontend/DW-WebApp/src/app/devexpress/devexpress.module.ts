import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { DxButtonModule, DxDataGridModule, DxDateBoxModule, DxDrawerModule, DxListModule, DxNumberBoxModule, DxPopupModule, DxSelectBoxModule, DxTextBoxModule, DxToolbarModule, DxValidationSummaryModule } from 'devextreme-angular';



@NgModule({
  declarations: [],
  imports: [
    CommonModule, 
  ],
  exports: [
    DxToolbarModule,
    DxListModule,
    DxDrawerModule,
    DxDataGridModule,
    DxButtonModule,
    DxPopupModule,
    DxTextBoxModule,
    DxValidationSummaryModule,
    DxDateBoxModule,
    DxSelectBoxModule,
    DxNumberBoxModule
  ]
})
export class DevexpressModule { }
