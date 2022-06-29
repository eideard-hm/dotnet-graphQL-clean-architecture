using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Context;
using Inventory.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService service;

        public ProductController()
        {
            service = CreateService();
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return Ok(await service.GetAllAsync());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            return Ok(await service.GetByIdAsync(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            await service.Add(product);
            return Ok(new { message = "El Producto se ha insertado corractamente" });
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Product product)
        {
            await service.Edit(product);
            return Ok(new { message = "El Producto de ha actualizado correctamente!" });
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);
            return Ok(new { message = $"El producto con id: {id} se ha eliminado satisfactoriamente !" });
        }

        private static ProductService CreateService()
        {
            InventoryContext db = new();
            ProductRepository repository = new(db);
            return new(repository);
        }
    }
}
