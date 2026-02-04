using Api.Models;
using MongoDB.Driver;

namespace Api.Repositories
{
    public class MovieRepository(IMongoClient client) : IMovieRepository
    {
        private readonly IMongoClient _client = client;

        public async Task<List<Movie>> GetMovies()
        {
            IMongoCollection<Movie> movieCollection = _client.GetDatabase("sample_mflix").GetCollection<Movie>("movies");

            var filter = Builders<Movie>.Filter.Empty;

            var result = await movieCollection.Find(filter).ToListAsync();

            return result;
        }
    }
}
