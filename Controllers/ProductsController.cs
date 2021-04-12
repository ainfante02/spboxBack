using appspbox.context;

using appspbox.Models;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace appspbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly productDbContext _context;
        private readonly IMapper mapper;
        
        public ProductsController(productDbContext context , IMapper mapper )
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {

            


             return await _context.Product.ToListAsync();

        }

        // GET: api/Products/5
        //  [HttpGet("{id}")]
        // public async Task<ActionResult<Product>> GetProduct(int id)
        //  {

        //   var product = await _context.Product.FindAsync(id);

        //    if (product == null)
        //  {
        //  return NotFound();
        //  }
        //   return product;
        //}


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = _context.Product;
                 //.Where(x => x.orderId == id);


            // Product product =await _context.Product.FindAsync(id);

            // if (product == null)
            // {
            //     return NotFound();
            // }
            return  Ok(product);

        }
       
        /*[HttpGet("product/{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {


            Negocio opNegocio = new Negocio();
            var s = opNegocio._contexto.Orders;
           
            return s;

        }*/
        

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.productId)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Products
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = product.productId }, product);
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Product.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return _context.Product.Any(e => e.productId == id);
    }
}
}
