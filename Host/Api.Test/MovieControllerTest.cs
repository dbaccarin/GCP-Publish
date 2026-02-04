using Api.Controllers;
using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Test
{
    public class MovieControllerTest
    {
        private readonly MovieController _controller;
        private readonly Mock<IMovieRepository> _mockRepository;

        public MovieControllerTest()
        {
            _mockRepository = new Mock<IMovieRepository>();
            _controller = new MovieController(_mockRepository.Object);
        }

        [Fact]
        public async Task Get_Returns_Ok()
        {
            // 1.Arrange
            _mockRepository.Setup(x => x.GetMovies()).ReturnsAsync(new List<Movie>());

            // 2. Act
            var result = await _controller.Get();

            // 3. Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Movie>>(okResult.Value);
        }

    }
}
