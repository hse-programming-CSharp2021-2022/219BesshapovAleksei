using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskProducts.Models;

namespace TaskProducts.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>() {
            new Product { Id = 1, Name = "Notebook", Price = 100000 },
            new Product { Id = 2, Name = "Car", Price = 2000000 },
            new Product { Id = 3, Name = "Apple", Price = 30 } };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!Products.Exists(el => el.Id == id))
            {
                return NotFound("Товара с таким id нет");
            }
            Products.Remove(Products.SingleOrDefault(p => p.Id == id));
            return Ok("Товар удален");
        }

        private int NextProductId
        {
            get
            {
                return Products.Count == 0 ? 1 : Products.Max(x => x.Id) + 1;
            }
        }


        [HttpGet("GetNextProductId")]
        public int GetNextProductId()
        {
            return NextProductId;
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.Id = NextProductId;
            Products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPost("AddProduct")]
        public IActionResult PostBody([FromBody] Product product)
        {
            return Post(product);
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Product storedProduct = Products.SingleOrDefault(p => p.Id == product.Id);
            if (storedProduct == null)
            {
                return NotFound();
            }
            storedProduct.Name = product.Name;
            storedProduct.Price = product.Price;
            return Ok(storedProduct);
        }

        [HttpPut("UpdateProduct")]
        public IActionResult PutBody([FromBody] Product product)
        {
            return Put(product);
        }
    }
}