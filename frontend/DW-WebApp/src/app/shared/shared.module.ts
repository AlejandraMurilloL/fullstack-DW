import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { DevexpressModule } from '../devexpress/devexpress.module';
import { SidebarComponent } from './components/sidebar/sidebar.component';



@NgModule({
  declarations: [
    SidebarComponent
  ],
  imports: [
    CommonModule,
    DevexpressModule
  ],
  exports: [
    SidebarComponent
  ]
})
export class SharedModule { }
