using Api.Controllers;
using Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Test
{
    public class TransactionControllerTest
    {
        private readonly TransactionController _controller;

        public TransactionControllerTest()
        {
            _controller = new TransactionController();
        }

        [Fact]
        public void Get_Returns_Ok()
        {
            // 1.Arrange

            // 2. Act
            var result = _controller.Get();

            // 3. Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Transaction>>(okResult.Value);
        }

    }
}
