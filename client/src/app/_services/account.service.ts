import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';
  private _signedIn: boolean = false;
  constructor(private http: HttpClient) { }

  get signedIn(): boolean {
    return this._signedIn;
  }

  set signedIn(value: boolean) {
    this._signedIn = value;
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model);
  }
  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model);
  }
}
