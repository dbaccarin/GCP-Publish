using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController(IMovieRepository movieRepository) : Controller
    {
        private readonly IMovieRepository _movieRepository = movieRepository;

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Movie> result =
                    await _movieRepository.GetMovies();

                return Ok(result);
            }
            catch (Exception)
            {
                throw new Exception("An error has occurred");
            }
        }
    }
}
