using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class IsInGenre : Criteria<Movie>
    {
        Genre the_genre;

        public IsInGenre(Genre the_genre)
        {
            this.the_genre = the_genre;
        }

        public bool is_satisfied_by(Movie movie)
        {
            return movie.genre == the_genre;
        }
    }
}