import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/shared/customer.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CustomerListComponent } from '../customer-list/customer-list.component';
import { AfterViewInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  constructor(private service: CustomerService, private toastr: ToastrService,
              private router: Router) { }

  // @ViewChild(CustomerListComponent, {static: false})
  // private CustomerListComponent: CustomerListComponent;

  ngOnInit() {
    this.resetForm();

  }

  resetForm(form? : NgForm){
    if(form != null)
     {
       form.resetForm();
     }

   this.service.formData= {
        Id : null,
        FirstName : '',
        LastName : '',
        Email : '',
        Address : '',
        PhoneNumber : ''
   }
}

  onSubmit(form : NgForm){
    this.insertRecord(form);
  }

  insertRecord(form : NgForm){
     this.service.createCustomer(form.value).subscribe(res=> {
     this.toastr.success("ثبت با موفقیت انجام شد.",'ثبت مشتری');
     this.resetForm(form);
     });
  }

}
