import { Component } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MoviesService} from "../../_services/movies.service";
import {Movie} from "../../_models/movie";

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent {
  id: number | undefined;
  movie: Movie | undefined;

  constructor(private route: ActivatedRoute, private movieService: MoviesService) {
  }

  ngOnInit(): void {
    this.setId();
    this.route.queryParams.subscribe(params => {
      // Handle the logic here when query parameters change
      if (this.id) {

        this.movieService.getMovieDetails(this.id).subscribe(response => {
          console.log(response);
          this.movie = response;
          this.movie.poster_path = "https://image.tmdb.org/t/p/original" + this.movie.poster_path;
        }, error => {
          console.log(error);
        });
      }
    });
  }

  setId() {
    // Accessing the 'id' parameter from the route
    this.route.params.subscribe(params => {
      this.id = +params['id']; // Use '+' to convert it to a number if needed
    });
  }
}
