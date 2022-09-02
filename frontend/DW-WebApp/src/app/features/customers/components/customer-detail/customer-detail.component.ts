import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs';
import { AlertService } from '../../../../shared/services/alert.service';
import { CustomerDetail } from '../../models/customer-detail';
import { CustomersService } from '../../services/customers.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {

  customer: CustomerDetail;

  constructor(private router: Router,
              private activatedRoute: ActivatedRoute,
              private customersService: CustomersService,
              private alertService: AlertService) 
  {
    this.customer = new CustomerDetail();
    this.customer.identificationDocument = '';
    this.customer.adress = '';
    this.customer.email = '';
  }

  ngOnInit(): void {
    if (!this.router.url.includes('editar')) {
      return;
    }

    this.activatedRoute.params
      .pipe(
        switchMap(({ id }) => this.customersService.getCustomer(id))
      )
      .subscribe(customer => this.customer = customer);
  }

  onDateOfBirthChanged(e: any): void {
    this.customer.dateOfBirth = e.value;
  }

  onSaveClick(): void {
    this.customersService.saveCustomer(this.customer).subscribe({
      next: this.onSuccess.bind(this),
      error: ({ message }) => { this.onError(message) }
    });
  }

  goToList(): void {
    this.router.navigate(['/clientes/listado']);
  }

  private onSuccess(): void {
    this.alertService.showSuccessMessage('El Cliente se guardó con éxito');
    this.goToList();
  }

  private onError(error: string) {
    this.alertService.showErrorMessage(error);
  }
}
