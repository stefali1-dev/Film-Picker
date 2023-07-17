import { Component } from '@angular/core';
import {NgModel} from "@angular/forms";
import {AccountService} from "../_services/account.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  model: any = {};
  registered = false;
  constructor(private accountService: AccountService) {

  }

  genres: Genre[] = [
    { id: 1, name: 'Action' },
    { id: 2, name: 'Comedy' },
    { id: 3, name: 'Drama' },
    { id: 4, name: 'Thriller' },
    { id: 5, name: 'Horror' },
    // Add more genres as needed
  ];

  movies: Movie[] = [
    { id: 1, name: 'The Shawshank Redemption' },
    { id: 2, name: 'The Godfather' },
    { id: 3, name: 'The Dark Knight' },
    { id: 4, name: 'The Godfather: Part II' },
    { id: 5, name: 'The Lord of the Rings: The Return of the King' },
    { id: 6, name: 'Pulp Fiction' },
  ];
  selectedGenres: Genre[] = [];
  selectedMovies: Movie[] = [];
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
  toggleMovie(movieId: number) {
    const index = this.selectedMovies.findIndex(movie => movie.id === movieId);
    if (index > -1) {
      this.selectedMovies.splice(index, 1);
    } else {
      const movie = this.movies.find(movie => movie.id === movieId);
      if (movie) {
        this.selectedMovies.push(movie);
      }
    }
  }

  register() {
    // get a list of ids from the selected genres
    this.model.favoriteGenresIds = this.selectedGenres.map(genre => genre.id);
    this.model.favoriteMoviesIds = this.selectedMovies.map(movie => movie.id);
    console.log(this.model)

    this.accountService.register(this.model).subscribe(response => {
      console.log(response);
      this.registered = true;
    }
    , error => {
      console.log(error);
    });
  }

  protected readonly NgModel = NgModel;
}
export interface Genre {
  id: number;
  name: string;
}
export interface Movie {
  id: number;
  name: string;
}
