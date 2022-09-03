import { Component, Input } from '@angular/core';
import { InvoiceDetailList } from '../models/invoice-detail-list';

@Component({
  selector: 'app-invoice-details-list',
  templateUrl: './invoice-details-list.component.html',
  styleUrls: ['./invoice-details-list.component.css']
})
export class InvoiceDetailsListComponent {

  @Input() invoiceDetails: InvoiceDetailList[] = [];

}
