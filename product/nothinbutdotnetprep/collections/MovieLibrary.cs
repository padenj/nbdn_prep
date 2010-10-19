using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;
using nothinbutdotnetprep.infrastructure.searching;

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

        private IEnumerable<Movie> all_movies_matching(Predicate<Movie> criteria)
        {
            return movies.all_items_matching(new AnonymousCriteria<Movie>(criteria));
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return all_movies_matching(movie => movie.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            return all_movies_matching(x => x.date_published.Year >= startingYear && x.date_published.Year < endingYear);
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return all_movies_matching(x => x.genre == Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return all_movies_matching(x => x.genre == Genre.action);
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