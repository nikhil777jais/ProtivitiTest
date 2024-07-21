import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { AddCustomerComponent } from './add-customer/add-customer.component';
import { ListCustomerComponent } from './list-customer/list-customer.component';
import { CustomerComponent } from './customer.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SvgPipe } from './svg.pipe';


@NgModule({
  declarations: [
    AddCustomerComponent,
    ListCustomerComponent,
    CustomerComponent,
    SvgPipe
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    ReactiveFormsModule,
  ]
})
export class CustomerModule { }
