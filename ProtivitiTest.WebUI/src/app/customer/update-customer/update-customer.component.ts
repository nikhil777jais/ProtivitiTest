import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Customer } from 'src/app/models/customer';
import { UpdateParams } from 'src/app/models/update-customer';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
	selector: 'app-update-customer',
	templateUrl: './update-customer.component.html',
	styleUrls: ['./update-customer.component.scss']
})
export class UpdateCustomerComponent implements OnInit {
	upadteCustomerForm: FormGroup = new FormGroup({});
	custmer!: Customer;
	customerId: string = '';
	constructor(private _fb: FormBuilder, private activatedRoute: ActivatedRoute, private customerService: CustomerService) {

	}

	ngOnInit(): void {
		this.initializeForm();
		this.activatedRoute.params.subscribe(params => {
			this.customerId = params['customerId'];
			this.customerService.getCustomerById(this.customerId).subscribe(customer => {
				this.custmer = customer;
				this.upadteCustomerForm.setValue({
					fullName: customer.fullName,
					dateOfBirth: customer.dateOfBirth
				});
			});
		});
	}

	initializeForm() {
		this.upadteCustomerForm = this._fb.group({
			fullName: ['', [Validators.required]],
			dateOfBirth: ['', [Validators.required]],
		});
	}


	onUpadte() {
		const customer: Customer = this.upadteCustomerForm.value;
		let data:UpdateParams[] = [];
		if(customer.fullName != this.custmer.fullName){
			let fullnm = {
				op:"replace",
				path:"/fullname",
				value:customer.fullName 
			}
			data.push(fullnm);
		}
		if(customer.dateOfBirth != this.custmer.dateOfBirth){
			let dob = {
				op:"replace",
				path:"/dateOfBirth",
				value: customer.dateOfBirth.toString()
			}
			data.push(dob);
		}
		if(data.length <= 0)
			return;
		this.customerService.updateCustomer(data, this.customerId).subscribe(cust => {
			this.custmer = cust
		});
	}

}
