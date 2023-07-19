import { Component } from '@angular/core';
import {AccountService} from "../_services/account.service";
import { Router } from '@angular/router';
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent {
  model: any = {};
  constructor(private accountService: AccountService, private router: Router ) {  }


  login() {
    console.log(this.model)
    this.accountService.login(this.model).subscribe(response => {
        console.log(response);
        this.accountService.login(this.model)
        this.router.navigateByUrl('');
      }
      , error => {
        console.log(error);
      });
  }

}

