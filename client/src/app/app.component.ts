import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Film Picker';
  users: any;
  constructor(private http:HttpClient) {

  }
  ngOnInit(): void {
    this.http.get('https://localhost:5005/api/users').subscribe({
      next: response => this.users = response,
      error: err => console.log(err),
      complete: () => console.log('Request completed')
    })
  }

}
