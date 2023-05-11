using Domain.Dtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepositoryService _postRepositoryService;

        public PostsController(IPostRepositoryService postRepositoryService)
        {
            _postRepositoryService = postRepositoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPosts()
        {
            var posts = await _postRepositoryService.GetAll();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPostById(int id)
        {
            var post = await _postRepositoryService.GetById(id);

            if (post == null) { return NotFound(); }

            return Ok(post);
        }

        [HttpPost]
        public ActionResult CreatePost([FromBody] CreatePostDto dto)
        {
            var id = _postRepositoryService.Add(dto);
            if (id == null) { return BadRequest("Failed to create"); }
            return Ok(id);
        }

        [HttpPut]
        public ActionResult UpdatePost(PostDto dto)
        {
            var result = _postRepositoryService.Update(dto);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeletePost(int id)
        {
            var result = _postRepositoryService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
