import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/shared/customer.service';
import { Customer } from 'src/app/shared/customer.model';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  customers : Customer[];
  constructor(private service : CustomerService, private toastr: ToastrService) { }

  ngOnInit() {
    this.getCustomerList();
  }

  getCustomerList() {
    this.service
    .getCustomers()
    .subscribe((data:any) => {
      console.log(data);
      this.customers = data;
    });
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteCustomer(id).subscribe(res => {
        this.service.getCustomers();
        this.toastr.warning('Deleted successfully', 'customer. Register');
        this.ngOnInit();
      });
    }
  }

}
