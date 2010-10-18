using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            var pubMovies = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.date_published.Year > year)
                    pubMovies.Add(movie);
            }
            return pubMovies;
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return match_production_studio(ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            var matchingMovies = new List<Movie>();
            
            matchingMovies.AddRange(match_production_studio(ProductionStudio.Pixar));
            matchingMovies.AddRange(match_production_studio(ProductionStudio.Disney));

            return matchingMovies;
        }

        private IEnumerable<Movie> match_production_studio(ProductionStudio studio)
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio == studio) 
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            var pixarMoviesNot = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar)
                    pixarMoviesNot.Add(movie);
            }
            return pixarMoviesNot;
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            var pubMovies = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                    pubMovies.Add(movie);
            }
            return pubMovies;
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            var kidsMovies = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.kids)
                    kidsMovies.Add(movie);
            }
            return kidsMovies;
        }

        public IEnumerable<Movie> all_action_movies()
        {
            var actionMovies = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.action)
                    actionMovies.Add(movie);
            }
            return actionMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            throw new NotImplementedException();
        }
    }
}