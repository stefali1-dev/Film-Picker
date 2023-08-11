import { Component } from '@angular/core';
import {NgModel} from "@angular/forms";
import {AccountService} from "../_services/account.service";
import { Router } from '@angular/router';
import {Movie} from "../_models/movie";


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
  registered = false;
  retypedPassword = '';
  constructor(private accountService: AccountService, private router: Router) {

  }

  movieList: Movie[] = [];
  selectedMovies: Set<Movie> = new Set();
  searchMovie() {
    this.accountService.searchMovie(this.movieName).subscribe(response => {
      this.movieList = response;

      // add to every member of movieList, at the attribute poster_path, the prefix of "https://image.tmdb.org/t/p/original"
      for (let movie of this.movieList) {
        if (movie.poster_path) {
          movie.poster_path = "https://image.tmdb.org/t/p/original" + movie.poster_path;
        }
      }

    }, error => {
      console.log(error);
    });
  }

  selectMovie(movie: Movie) {
    this.selectedMovies.add(movie);
    this.clearResults();
  }

  clearResults() {
    this.movieList = [];
    this.movieName = '';
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
      this.registered = true;
      // login now
      this.accountService.login(this.model).subscribe(response => {
        console.log("Registered and logged in");
      }, error => {
        console.log(error);
      });
    }
    , error => {
      console.log(error);
    });


  }

  tastesModel: any = {};
  submitTastes() {
    this.tastesModel.FavoriteGenresIds = this.selectedGenres.map(genre => genre.id);
    this.tastesModel.FavoriteMoviesIds = Array.from(this.selectedMovies).map(movie => movie.id);

    this.accountService.updateTastes(this.tastesModel).subscribe(response => {
      console.log(response);
      this.router.navigateByUrl('');
    },error => {
      console.log(error);
    });
  }

  protected readonly NgModel = NgModel;


}

export interface Genre{
  id: number;
  name: string;
}
