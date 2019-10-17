import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/Rx';
import { from, Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Deposit } from './deposit.model';

@Injectable({
  providedIn: 'root'
})
export class DepositService {

  formData: Deposit;
  readonly rootURL= "http://localhost:8081/api";

  constructor(private http: HttpClient) { }

  createDeposit(formData : Deposit){
    return this.http.post(this.rootURL+ '/Deposit/CreateDeposit',formData);
  }

  getDeposits() {
    return this.http.get(this.rootURL+'/Deposit/GetDeposits')
         .pipe(
           map((data : Deposit[]) => {
            return data;
            }), catchError( error=> {
            return throwError ("somthing wrong");
            })
          );
     }

     deleteDeposit(id : number){
       return this.http.get(this.rootURL+'/Deposit/DeleteDeposit?id='+id);
     }

}
