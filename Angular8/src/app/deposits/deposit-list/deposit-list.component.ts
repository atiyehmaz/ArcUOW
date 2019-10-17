import { Component, OnInit } from '@angular/core';
import { DepositService } from 'src/app/shared/deposit.service';
import { Deposit } from 'src/app/shared/deposit.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-deposit-list',
  templateUrl: './deposit-list.component.html',
  styleUrls: ['./deposit-list.component.css']
})
export class DepositListComponent implements OnInit {

  deposits: Deposit;
  constructor(private service : DepositService, private toastr: ToastrService) { }

  ngOnInit() {
    this.getDepositList();
  }

  getDepositList() {
    this.service
    .getDeposits()
    .subscribe((data:any) => {
      console.log(data);
      this.deposits = data;
    });
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteDeposit(id).subscribe(res => {
        this.service.getDeposits();
        this.toastr.warning('Deleted successfully', 'deposit. Register');
        this.ngOnInit();
      });
    }
  }


}
