import { Component } from '@angular/core';
import {AccountService} from "../_services/account.service";
import { Router } from '@angular/router';
import {ToastrService} from "ngx-toastr";
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent {
  model: any = {};
  constructor(private accountService: AccountService, private router: Router, private toastr: ToastrService) {  }


  login() {
    console.log(this.model)
    this.accountService.login(this.model).subscribe(response => {
        console.log(response);
        this.accountService.login(this.model)
        this.router.navigateByUrl('/movies');
      }
      , error => {
        console.log(error);
        this.toastr.error(error.error);
      });
  }

}

