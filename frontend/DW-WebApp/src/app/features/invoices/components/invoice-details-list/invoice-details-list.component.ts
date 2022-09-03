import { Component, Input, OnInit } from '@angular/core';
import { InvoiceDetailList } from '../models/invoice-detail-list';

@Component({
  selector: 'app-invoice-details-list',
  templateUrl: './invoice-details-list.component.html',
  styleUrls: ['./invoice-details-list.component.css']
})
export class InvoiceDetailsListComponent implements OnInit {

  @Input() invoiceDetails: InvoiceDetailList[] = [];
  
  constructor() { }

  ngOnInit(): void {
    console.log(this.invoiceDetails);
  }

}
