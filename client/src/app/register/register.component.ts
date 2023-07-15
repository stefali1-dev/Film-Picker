import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  genres: Genre[] = [
    { id: 1, name: 'Action' },
    { id: 2, name: 'Comedy' },
    { id: 3, name: 'Drama' },
    { id: 4, name: 'Thriller' },
    { id: 5, name: 'Horror' },
    // Add more genres as needed
  ];
  selectedGenres: Genre[] = [];

  movies: Movie[] = [
    { id: 1, name: 'The Shawshank Redemption' },
    { id: 2, name: 'The Godfather' },
    { id: 3, name: 'The Dark Knight' },
    { id: 4, name: 'The Godfather: Part II' },
    { id: 5, name: 'The Lord of the Rings: The Return of the King' },
    { id: 6, name: 'Pulp Fiction' },
  ];
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

  submit() {
    console.log(this.selectedGenres);
    console.log(this.selectedMovies);
  }
}
export interface Genre {
  id: number;
  name: string;
}
export interface Movie {
  id: number;
  name: string;
}
