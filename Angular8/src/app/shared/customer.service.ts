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
  list: Customer[];
  customerList: Customer[];
   mylist:any = {};
  readonly rootURL= "http://localhost:8081/api";
  constructor(private http: HttpClient) { }

  createCustomer(formData : Customer){
    return this.http.post(this.rootURL+ '/Customer/CreateCustomer',formData);
  }

  // refreshList(){
  //   this.http.get(this.rootURL+'/Customer/GetCustomers')
  //   .toPromise().then(res => this.list = res as Customer[]);
  //   this.customerList= this.list;
  // }


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
