import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Movie} from "../_models/movie";

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getRecommendedMovies() {
    // get userId from local storage
    const userId = JSON.parse(localStorage.getItem('user') || '{}').userId;

    return this.http.get<Movie[]>(this.baseUrl + `users/${userId}/recommended-movies`);
  }

  getMovieDetails(movieId: number) {
    return this.http.get<Movie>(this.baseUrl + 'movie/' + movieId);
  }

  addPosterPrefix(movieList: Movie[]) {
    // add to every member of movieList, at the attribute poster_path, the prefix of "https://image.tmdb.org/t/p/original"
    for (let movie of movieList) {
      if (movie.poster_path) {
        movie.poster_path = "https://image.tmdb.org/t/p/original" + movie.poster_path;
      }
    }
  }

}
