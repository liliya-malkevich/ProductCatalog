using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using products_catalog.Server.Models;
using products_catalog.Server.Repositories;

namespace products_catalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        IBaseRepo<Product> _repo;
        public ProductController(IBaseRepo<Product> productRepository)
        {
            _repo = productRepository;
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _repo.Get();
        }

        [HttpGet("{Id}", Name = "GetProduct")]
        public async Task<IActionResult> Get(int Id)
        {
            Product item = await _repo.Get(Id);

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await _repo.Create(item);
            return CreatedAtRoute("GetProduct", new { id = item.Id }, item);
        }

        [HttpPut("{Id:int}")]
        public async Task<IActionResult> Update(int Id, [FromBody] Product item)
        {
            if (item == null || item.Id != Id)
            {
                return BadRequest();
            }

            Product currentItem = await _repo.Get(Id);
            if (currentItem == null)
            {
                return NotFound();
            }

            await _repo.Update(item);
            return RedirectToRoute("GetAllProducts");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            Product deletedItem = await _repo.Delete(Id);

            if (deletedItem == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedItem);
        }
    }
}
