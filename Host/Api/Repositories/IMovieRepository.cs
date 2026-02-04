using Api.Models;

namespace Api.Repositories
{
    public interface IMovieRepository
    {
        public Task<List<Movie>> GetMovies();

    }
}
