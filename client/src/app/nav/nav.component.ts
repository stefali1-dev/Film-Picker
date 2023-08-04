import { Component } from '@angular/core';
import {AccountService} from "../_services/account.service";
import {Observable, of} from "rxjs";
import {User} from "../_models/user";
import {MoviesService} from "../_services/movies.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {

  constructor(public accountService: AccountService, private movieService: MoviesService, private router: Router) {  }
  ngOnInit(): void {
  }
  logout() {
    this.accountService.logout();
  }

  getRandomMovieId(): number {
    let movieId = -1;
    this.movieService.getRecommendedMovies().subscribe(response => {
      // pick a random item in response
      const randomIndex = Math.floor(Math.random() * response.length);
      const randomMovie = response[randomIndex];
      movieId = randomMovie.id;


    }, error => {
      console.log(error);
    });
    // unsubscribe from the observable
    this.movieService.getRecommendedMovies().subscribe().unsubscribe();
    return movieId;
  }
  pickRandomRecommendedMovie() {
    this.movieService.getRecommendedMovies().subscribe(response => {
      // pick a random item in response
      const randomIndex = Math.floor(Math.random() * response.length);
      const randomMovie = response[randomIndex];
      this.router.navigate(['/movies/', randomMovie.id]);


    }, error => {
      console.log(error);
    });
    // unsubscribe from the observable
    this.movieService.getRecommendedMovies().subscribe().unsubscribe();
  }
}
