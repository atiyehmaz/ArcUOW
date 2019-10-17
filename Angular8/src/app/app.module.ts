import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerComponent } from './customers/customer/customer.component';
import { CustomerListComponent } from './customers/customer-list/customer-list.component';
import { CustomerService } from './shared/customer.service';
import {FormsModule} from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { RouterModule, Routes} from '@angular/router';
import { DepositsComponent } from './deposits/deposits.component';
import { DepositListComponent } from './deposits/deposit-list/deposit-list.component';
import { RegisterDepositComponent } from './deposits/register-deposit/register-deposit.component';


@NgModule({
  declarations: [
    AppComponent,
    CustomersComponent,
    CustomerComponent,
    CustomerListComponent,
    DepositsComponent,
    DepositListComponent,
    RegisterDepositComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([]),
    ToastrModule.forRoot()
  ],
  providers: [CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
