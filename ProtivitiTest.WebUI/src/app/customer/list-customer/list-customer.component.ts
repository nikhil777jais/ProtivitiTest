import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Customer } from 'src/app/models/customer';

@Component({
    selector: 'app-list-customer',
    templateUrl: './list-customer.component.html',
    styleUrls: ['./list-customer.component.scss']
})
export class ListCustomerComponent {
    @Input() customers: Customer[] = [];
    @Output() onUpdateCustomer = new EventEmitter<Customer>();

    constructor(

    ) { }

    ngOnInit(): void {

    }

    onEdit(index: number) {
        this.onUpdateCustomer.next(this.customers[index]);
    }
}
