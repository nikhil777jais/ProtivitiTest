import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Customer } from 'src/app/models/customer';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
	selector: 'app-add-customer',
	templateUrl: './add-customer.component.html',
	styleUrls: ['./add-customer.component.scss']
})
export class AddCustomerComponent implements OnInit {
	customerForm: FormGroup = new FormGroup({});
	@Output() onCustomerCreation = new EventEmitter<Customer>();
	
	constructor(private _fb: FormBuilder, private customerService: CustomerService) {

	}

	ngOnInit(): void {
		this.initializeForm();
	}

	initializeForm() {
		this.customerForm = this._fb.group({
			fullName: ['', [Validators.required]],
			dateOfBirth: ['', [Validators.required]],
		});
	}

	onSubmit() {
		const customer: Customer = this.customerForm.value;
		this.customerService.addCustomer(customer).subscribe(
			{
				next: (customer: Customer) => { 
					this.onCustomerCreation.emit(customer);
				},
				error: (err) => {
					console.log("Some error occured")
				},
				complete: () => { },
			}
		)
	}
}
