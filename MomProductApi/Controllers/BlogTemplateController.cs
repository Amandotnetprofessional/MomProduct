using Microsoft.AspNetCore.Mvc;
using MomProduct.Model;
using MomProduct.Service.Interface;

namespace MomProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogTemplateController : ControllerBase
    {
        private readonly IBlogTemplateService _blogTemplateService;

        public BlogTemplateController(IBlogTemplateService blogTemplateService)
        {
            _blogTemplateService = blogTemplateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogTemplates()
        {
            var blogTemplates = await _blogTemplateService.GetAllAsync();
            return Ok(blogTemplates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogTemplateById(int id)
        {
            var blogTemplate = await _blogTemplateService.GetByIdAsync(id);
            if (blogTemplate == null) return NotFound();
            return Ok(blogTemplate);
        }

        [HttpPost]
        public async Task<IActionResult> AddBlogTemplate(BlogTemplate blogTemplate)
        {
            await _blogTemplateService.AddAsync(blogTemplate);
            return CreatedAtAction(nameof(GetBlogTemplateById), new { id = blogTemplate.Id }, blogTemplate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogTemplate(int id, BlogTemplate blogTemplate)
        {
            if (id != blogTemplate.Id) return BadRequest();
            await _blogTemplateService.UpdateAsync(blogTemplate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogTemplate(int id)
        {
            await _blogTemplateService.DeleteAsync(id);
            return NoContent();
        }
    }
}
