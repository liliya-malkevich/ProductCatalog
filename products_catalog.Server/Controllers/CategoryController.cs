using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_catalog.Server.Models;
using products_catalog.Server.Repositories;
using products_catalog.Server.Repositories.Impl;

namespace products_catalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        IBaseRepo<CategoryItem> _repo;
        public CategoryController(IBaseRepo<CategoryItem> catRepository)
        {
            _repo = catRepository;
        }

        [HttpGet(Name = "GetAllCategories")]
        public async Task<IEnumerable<CategoryItem>> Get()
        {
            return await _repo.Get();
        }

        [HttpGet("{Id}", Name = "GetCategory")]
        public async Task<IActionResult> Get(int Id)
        {
            CategoryItem item = await _repo.Get(Id);

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await _repo.Create(item);
            return CreatedAtRoute("GetCategory", new { id = item.Id }, item);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            CategoryItem currentItem = await _repo.Get(item.Id);
            if (currentItem == null)
            {
                return NotFound();
            }

            await _repo.Update(item);
            return CreatedAtRoute("GetCategory", new { id = item.Id }, item);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            CategoryItem deletedItem = await _repo.Delete(Id);

            if (deletedItem == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedItem);
        }
    }
}
