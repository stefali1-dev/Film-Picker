import { Component } from '@angular/core';
import {AccountService} from "../_services/account.service";
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent {
  model: any = {};
  constructor(private accountService: AccountService) {  }


  login() {
    console.log(this.model)
    this.accountService.login(this.model).subscribe(response => {
        console.log(response);
        this.accountService.signedIn = true;
      }
      , error => {
        console.log(error);
      });
    console.log(this.accountService.signedIn)
  }

  logout() {
    this.accountService.signedIn = false;
  }
}

