import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {SigninComponent} from "./signin/signin.component";
import {RegisterComponent} from "./register/register.component";
import {HomeComponent} from "./home/home.component";
import {MovieListComponent} from "./movies/movie-list/movie-list.component";
import {MovieDetailComponent} from "./movies/movie-detail/movie-detail.component";
import {ListsComponent} from "./lists/lists.component";
import {AuthGuard} from "./_guards/auth.guard";

const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'movies', component: MovieListComponent },
      { path: 'movies/:id', component: MovieDetailComponent},
      { path: 'lists', component: ListsComponent },
    ]
  },
  { path: 'login', component: SigninComponent },
  { path: 'register', component: RegisterComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' }

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
