import {Component, Input} from '@angular/core';
import {Movie} from "../../_models/movie";
import {Router} from "@angular/router";

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent {
  @Input() movie: Movie | undefined;

  constructor(private router: Router) { }
  goToMovieDetails() {
    this.router.navigate(['/movies/', this.movie?.id]);
  }
}
