import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../models/customer';
import { UpdateParams } from '../models/update-customer';
import { catchError } from 'rxjs/internal/operators/catchError';
import { BehaviorSubject, throwError } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class CustomerService {

	customers$:BehaviorSubject<Customer[]> = new BehaviorSubject<Customer[]>([]);
	
	constructor(
		private http: HttpClient
	) { }

	getCustomers() {
		return this.http.get<Customer[]>(
			environment.apiUrl + '/api/customers'
		).pipe(
			catchError(error => {
				return throwError(error);
			})
		);
	}

	getCustomerById(id: string) {
		return this.http.get<Customer>(
			environment.apiUrl + '/api/customers/' + id
		).pipe(
			catchError(error => {
				return throwError(error);
			})
		);
	}

	getCustomersByAge(age: number) {
		return this.http.get<Customer[]>(
			environment.apiUrl + '/api/customers/' + age
		).pipe(
			catchError(error => {
				return throwError(error);
			})
		);
	}

	addCustomer(customer: Customer) {
		return this.http.post<Customer>(
			environment.apiUrl + '/api/customers',
			{
				fullName: customer.fullName,
				dateOfBirth: customer.dateOfBirth
			}
		).pipe(
			catchError(error => {
				return throwError(error);
			})
		)
	}

	updateCustomer(customerUpdateParams: UpdateParams[], id: string) {
		return this.http.patch<Customer>(
			environment.apiUrl + '/api/customers/'+id,
			customerUpdateParams
		).pipe(
			catchError(error => {
				return throwError(error);
			})
		)
	}
}
