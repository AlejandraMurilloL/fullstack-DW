import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { DxButtonModule, DxDataGridModule, DxDrawerModule, DxListModule, DxPopupModule, DxTextBoxModule, DxToolbarModule } from 'devextreme-angular';



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
    DxTextBoxModule
  ]
})
export class DevexpressModule { }
