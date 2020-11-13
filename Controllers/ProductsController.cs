using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IGSService.Data;
using IGSService.Models;
using System.Web.Http.Controllers;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;




namespace IGSService.Controllers
{
     [Route("v1")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGSServiceContext _context;

        public ProductsController(IGSServiceContext context)
        {
            _context = context;

        }

       // GET: v1/Products
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
             
            return Ok(new ApiOkResponse(await _context.Products.ToListAsync()));
        }

        // POST: v1/Product
        [HttpPost("product")]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get" +
                "Products", new { id = products.ProductCode }, Ok(new ApiOkResponse(products)));
        }


        // GET: v1/Product/1
        [HttpGet("product/{id}")]        

        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);
           

            if (products == null)
            {
                return NotFound(new ApiResponse(404, "Unknow Product ID"));
            }

            return Ok(new ApiOkResponse(products));
        }

        // PUT: v1/Product/1       
        [HttpPut("product/{id}")]

        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (!ProductsExists(id))
            {
                return NotFound(new ApiResponse(404, "Unknow Product ID "));

            }
           var existingProduct = _context.Products.First(x => x.ProductCode == id);
            if(products.Name != null) 
            {
                existingProduct.Name = products.Name;
            }
            if (products.Price != 0)
            {
                existingProduct.Price = products.Price;
            }


            try
            {
                
                _context.Update(existingProduct);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound(new ApiResponse(404, "Unknow Product ID "));

                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       
        // DELETE: v1/Products/5
        [HttpDelete("product/{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound(new ApiResponse(404, "Unknow Product ID "));
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return Ok(new ApiOkResponse(products));

        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductCode == id);
        }
    }
}
