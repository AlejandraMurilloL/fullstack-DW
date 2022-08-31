import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { DxDrawerModule } from 'devextreme-angular/ui/drawer';
import { DxListModule } from 'devextreme-angular/ui/list';
import { DxToolbarModule } from 'devextreme-angular/ui/toolbar';
import { SidebarComponent } from './components/sidebar/sidebar.component';



@NgModule({
  declarations: [
    SidebarComponent
  ],
  imports: [
    CommonModule,
    DxToolbarModule,
    DxListModule,
    DxDrawerModule
  ],
  exports: [
    SidebarComponent
  ]
})
export class SharedModule { }
