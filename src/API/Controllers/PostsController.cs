using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPosts()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPostById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult CreatePost(CreatePostDto dto) 
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdatePost(PostDto dto) 
        { 
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeletePost(PostDto dto)
        {
            return Ok();
        }
    }
}
