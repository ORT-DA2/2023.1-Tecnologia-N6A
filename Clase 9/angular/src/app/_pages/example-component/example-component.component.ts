import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/_services/movies/movie.service';
import { Movie } from 'src/app/_types/movie';

@Component({
  selector: 'example-component',
  templateUrl: './example-component.component.html',
  styleUrls: []
})
export class ExampleComponent implements OnInit {
  movies: Movie[] = [];
  showLoadedMovies: boolean = false;

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
  }

  public callBackend() {
    this.movieService.getAllMovies().subscribe(movies => {
      this.movies = movies;
      this.showLoadedMovies = true;
      console.warn('Llegaron las movies', movies);
    }, error => {
      console.error(error)
    })
  }
}
