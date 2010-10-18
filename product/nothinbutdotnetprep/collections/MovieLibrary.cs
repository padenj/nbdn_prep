using System;
using System.Collections.Generic;

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
            foreach (var movie in movies ) yield return movie;
        }

        public void add(Movie movie)
        {
            bool exists = false;
            foreach (var movie1 in movies)
            {
                if (movie1.title == movie.title)
                {exists = true;
                    break;
                }
            }
            if (!movies.Contains(movie) && !exists) 
                movies.Add(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        
        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            List<Movie> pixarMovies = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar)
                   pixarMovies.Add(movie);
            }
            return pixarMovies;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            List<Movie> pixarAndDisney = all_movies_published_by_pixar() as List<Movie>;
            
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Disney)
                    pixarAndDisney.Add(movie);
            }
            return pixarAndDisney;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            List<Movie> pixarMoviesNot = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar)
                    pixarMoviesNot.Add(movie);
            }
            return pixarMoviesNot;
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            List<Movie> pubMovies = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.date_published.Year > year)
                    pubMovies.Add(movie);
            }
            return pubMovies;
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            List<Movie> pubMovies = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                    pubMovies.Add(movie);
            }
            return pubMovies;
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            List<Movie> kidsMovies = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.kids)
                    kidsMovies.Add(movie);
            }
            return kidsMovies;
        }

        public IEnumerable<Movie> all_action_movies()
        {
            List<Movie> actionMovies = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.action)
                    actionMovies.Add(movie);
            }
            return actionMovies;
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