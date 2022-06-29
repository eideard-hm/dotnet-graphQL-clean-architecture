using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Context;
using Inventory.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService service;

        public CategoryController()
        {
            service = CreateService();
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            return Ok(await service.GetAllAsync());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            return Ok(await service.GetByIdAsync(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            await service.Add(category);
            return Ok(new { message = $"La categoría '{category.Name}' se ha creado correctamente !" });
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Category category)
        {
            await service.Edit(category);
            return Ok(new { message = $"La categoría '{category.Name}' se ha actualizado satisfactoriamente!" });
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);
            return Ok();
        }

        private static CategoryService CreateService()
        {
            InventoryContext db = new();
            CategoryRepository repository = new(db);
            return new CategoryService(repository);
        }
    }
}
