import { Component } from '@angular/core';
import {AccountService} from "../_services/account.service";
import {Observable, of} from "rxjs";
import {User} from "../_models/user";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {

  constructor(public accountService: AccountService) {  }
  ngOnInit(): void {
  }
  logout() {
    this.accountService.logout();
  }
}
