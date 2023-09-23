import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BehaviorSubject, map} from "rxjs";
import {User} from "../_models/user";
import {Movie} from "../_models/movie";
import {environment} from "../../environments/environment.prod";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl =  environment.apiUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  constructor(private http: HttpClient) { }
  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model);
  }
  login(model: any) {
    // return this.http.post(this.baseUrl + 'account/login', model);
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if(user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }
  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  searchMovie(movieName: string) {
    return this.http.get<Movie[]>(this.baseUrl + 'movie/search/' + movieName);

  }

  updateTastes(tastesModel: any) {
    // get userId from local storage
    const userId = JSON.parse(localStorage.getItem('user') || '{}').userId;
    return this.http.put(this.baseUrl + `users/${userId}/tastes`, tastesModel);
  }
}
