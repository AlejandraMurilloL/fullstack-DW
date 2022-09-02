import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { confirm } from 'devextreme/ui/dialog';
import { AlertService } from '../../../../shared/services/alert.service';
import { CustomerList } from '../../models/customer-list';
import { CustomersService } from '../../services/customers.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  customers: CustomerList[] = [];

  constructor(private customersService: CustomersService,
              private alertService: AlertService,
              private router: Router) 
  { 
  }

  ngOnInit(): void {
    this.loadDatos();
  }
  
  loadDatos() {
    this.customersService.getCustomers().subscribe((datos) => {
      this.customers = datos;
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
    this.router.navigate(['/clientes/nuevo']);
  }

  onEditClick(item: any): void {
    this.router.navigate(['/clientes/editar', item.id]);
  }

  onRemoveClick(data: any): void {
    let result = confirm("<i>¿Está seguro de que desea eliminar el Cliente seleccionado?</i>", "Advertencia");
    result.then((dialogResult) => {
        if (dialogResult) { this.deleteCustomer(data.id); }
    });
  }

  private deleteCustomer(customerId: number): void {
    this.customersService.deleteCustomer(customerId).subscribe({
      next: this.onSuccess.bind(this),
      error: ({ error }) => { this.onError(error) }           
    });
  }

  private onSuccess() {
    this.alertService.showSuccessMessage('El Cliente se elimino con éxito')
    this.loadDatos();
  }

  private onError(error: any) {
    this.alertService.showErrorMessage(error.message);
  }

}
