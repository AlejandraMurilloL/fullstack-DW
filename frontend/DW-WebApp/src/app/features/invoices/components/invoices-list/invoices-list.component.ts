import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { InvoicesService } from '../../services/invoices.service';
import { InvoiceList } from '../models/invoice-list';

@Component({
  selector: 'app-invoices-list',
  templateUrl: './invoices-list.component.html',
  styleUrls: ['./invoices-list.component.css']
})
export class InvoicesListComponent {

  invoices: InvoiceList[] = [];

  constructor(private invoicesService: InvoicesService,
              private router: Router) 
  { 
  }

  ngOnInit(): void {
    this.loadDatos();
  }
  
  loadDatos() {
    this.invoicesService.getInvoices().subscribe((datos) => {
      this.invoices = datos;
    });
  }

  onToolbarPreparing(e: any): void {
    e.toolbarOptions.items.unshift({
      location: 'after',
      widget: 'dxButton',
      options: {
        icon: 'add',
        hint: 'Nuevo',
        type: 'success',
        onClick: this.onNewClick.bind(this),
      },
    });
  }

  onNewClick(): void {
    this.router.navigate(['/ventas/nuevo']);
  }
}
