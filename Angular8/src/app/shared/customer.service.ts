import { Injectable } from '@angular/core';
import { Customer } from './customer.model';
import { HttpClient } from '@angular/common/http';
import 'rxjs/Rx'
 import { from, Observable, throwError } from 'rxjs';
 import { map, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  formData: Customer;
  readonly rootURL= "http://localhost:8081/api";

  constructor(private http: HttpClient) { }

  createCustomer(formData : Customer){
    return this.http.post(this.rootURL+ '/Customer/CreateCustomer',formData);
  }

  getCustomers() {
    return this.http.get(this.rootURL+'/Customer/GetCustomers')
         .pipe(
           map((data : Customer[]) => {
            return data;
            }), catchError( error=> {
            return throwError ("somthing wrong");
            })
          );
     }

     deleteCustomer(id : number){
       return this.http.get(this.rootURL+'/Customer/DeleteCustomer?id='+id);
     }


}
