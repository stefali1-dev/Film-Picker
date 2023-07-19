import { Component } from '@angular/core';
import {NgModel} from "@angular/forms";
import {AccountService} from "../_services/account.service";
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  genres: Genre[] = [
    { id: 28, name: 'Action' },
    { id: 12, name: 'Adventure' },
    { id: 16, name: 'Animation' },
    { id: 35, name: 'Comedy' },
    { id: 80, name: 'Crime' },
    { id: 99, name: 'Documentary' },
    { id: 18, name: 'Drama' },
    { id: 10751, name: 'Family' },
    { id: 14, name: 'Fantasy' },
    { id: 36, name: 'History' },
    { id: 27, name: 'Horror' },
    { id: 10402, name: 'Music' },
    { id: 9648, name: 'Mystery' },
    { id: 10749, name: 'Romance' },
    { id: 878, name: 'Science Fiction' },
    { id: 10770, name: 'TV Movie' },
    { id: 53, name: 'Thriller' },
    { id: 10752, name: 'War' },
    { id: 37, name: 'Western' }
  ];
  selectedGenres: Genre[] = [];
  containerHeight = 200; // Specify the desired height in pixels

  toggleGenre(genreId: number) {
    const index = this.selectedGenres.findIndex(genre => genre.id === genreId);
    if (index > -1) {
      this.selectedGenres.splice(index, 1);
    } else {
      const genre = this.genres.find(genre => genre.id === genreId);
      if (genre) {
        this.selectedGenres.push(genre);
      }
    }
  }

  paragraphs: string[] = [];
  movieName: string = '';

  addParagraph(text: string) {
    this.paragraphs.push(text);
  }

  model: any = {};
  registered = true;
  retypedPassword = '';
  constructor(private accountService: AccountService, private router: Router) {

  }

  searchMovie() {
    // TODO: send a request to the server to search for the movie
    this.addParagraph("da")
    this.addParagraph("da")
    this.addParagraph("da")
  }
  register() {

    if(this.model.password !== this.retypedPassword){
      console.log("Passwords do not match")
      return;
    }

    // get a list of ids from the selected genres
    this.model.favoriteGenresIds = [];
    this.model.favoriteMoviesIds = [];
    console.log(this.model)

    this.accountService.register(this.model).subscribe(response => {
      console.log(response);
      this.registered = true;
    }
    , error => {
      console.log(error);
    });


  }

  submitTastes() {
    // TODO: send the selected genres and movies to the server
  }

  protected readonly NgModel = NgModel;
}

export interface Genre {
  id: number;
  name: string;
}
