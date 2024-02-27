using Microsoft.AspNetCore.Mvc;
using MediatR;
using HackerNewsAPI.Models;

namespace HackerNewsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> GetBestStories([FromQuery] int n)
        {
            try
            {
                var stories = await _mediator.Send(new GetBestNewsStoriesRequest(n));
                return Ok(stories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}