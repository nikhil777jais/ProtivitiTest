import { Component, Input, OnInit } from '@angular/core';
import { CustomerService } from '../services/customer.service';
import { Customer } from '../models/customer';

@Component({
    selector: 'app-customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
    customers: Customer[] = [];

    constructor(private customerSerivce: CustomerService) {

    }

    ngOnInit(): void {
        this.customerSerivce.getCustomers().subscribe({
            next: (customers: Customer[]) => {
                this.customers = customers;                    
            },
        })
    }

    CostomerCreation(customer: Customer){
        this.customers = [customer, ...this.customers]
    }
}
