using Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        [HttpGet("Get")]
        public IEnumerable<Transaction> Get()
        {
            return new List<Transaction>()
            {
                new Transaction()
                {
                    Id = new Guid(),
                    Description = "Test",
                    Value = 10,
                    Date = DateTime.Now
                }
            };
        }
    }
}
