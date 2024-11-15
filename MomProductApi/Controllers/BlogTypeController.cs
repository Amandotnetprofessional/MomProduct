using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MomProduct.Model;
using MomProduct.Service.Interface;

namespace MomProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogTypeController : ControllerBase
    {
        private readonly IBlogTypeService _blogTypeService;

        public BlogTypeController(IBlogTypeService blogTypeRepository)
        {
            _blogTypeService = blogTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogType()
        {
            var blogTypes = await _blogTypeService.GetAllAsync();
            return Ok(blogTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogTypeById(int id)
        {
            var blogType = await _blogTypeService.GetByIdAsync(id);
            if (blogType == null) return NotFound();
            return Ok(blogType);
        }

        [HttpPost]
        public async Task<IActionResult> AddBlogType(BlogType blogType)
        {
            await _blogTypeService.AddAsync(blogType);
            return CreatedAtAction(nameof(GetBlogTypeById), new { id = blogType.Id }, blogType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogType(int id, BlogType blogType)
        {
            if (id != blogType.Id) return BadRequest();
            await _blogTypeService.UpdateAsync(blogType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogType(int id)
        {
            await _blogTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
