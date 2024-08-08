using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_catalog.Server.Models;
using products_catalog.Server.Repositories;
using products_catalog.Server.Repositories.Impl;

namespace products_catalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryConrtroller : Controller
    {
        IBaseRepo<CategoryItem> _repo;
        public CategoryConrtroller(IBaseRepo<CategoryItem> catRepository)
        {
            _repo = catRepository;
        }

        [HttpGet(Name = "GetAllCategories")]
        public IEnumerable<CategoryItem> Get()
        {
            return _repo.Get();
        }

        [HttpGet("{Id}", Name = "GetCategory")]
        public IActionResult Get(int Id)
        {
            CategoryItem item = _repo.Get(Id);

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Create(item);
            return CreatedAtRoute("GetCategory", new { id = item.Id }, item);
        }

        [HttpPut("{Id:int}")]
        public IActionResult Update(int Id, [FromBody] CategoryItem item)
        {
            if (item == null || item.Id != Id)
            {
                return BadRequest();
            }

            CategoryItem currentItem = _repo.Get(Id);
            if (currentItem == null)
            {
                return NotFound();
            }

            _repo.Update(item);
            return RedirectToRoute("GetAllCategories");
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            CategoryItem deletedItem = _repo.Delete(Id);

            if (deletedItem == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedItem);
        }
    }
}
