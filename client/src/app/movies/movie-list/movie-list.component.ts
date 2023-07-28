import { Component } from '@angular/core';
import {Movie} from "../../_models/movie";
import {MoviesService} from "../../_services/movies.service";

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent {

  movieList: Movie[] = []

  constructor(private movieService: MoviesService) { }

  ngOnInit(): void {
    this.loadMovieList();
  }

  loadMovieList() {
    this.movieService.getRecommendedMovies().subscribe(response => {
      this.movieList = response;
      // add poster
      this.movieService.addPosterPrefix(this.movieList);
      console.log(this.movieList)

    }, error => {
      console.log(error);
    });
  }
}
