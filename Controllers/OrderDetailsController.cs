﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using appspbox.Models;
using appspbox.context;

namespace appspbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly productDbContext _context;

        public OrderDetailsController(productDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetail()
        {
            return await _context.OrderDetail.ToListAsync();
        }

        // GET: api/OrderDetails1/5
        /*[HttpGet("{id}")]
         public async Task<ActionResult<OrderDetail>> GetOrderDetail(int id)
         {
             var orderDetail = await _context.OrderDetail.FindAsync(id);

             if (orderDetail == null)
             {
                 return NotFound();
             }

             return orderDetail;
         }*/

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(int id)
        {
       

            var orderDetail = from orderdetail in _context.Set<OrderDetail>().Where(orderdetail => orderdetail.orderId == id)
                        join  orders in _context.Set<Orders>()
                            on orderdetail.orderId equals orders.orderId
                            join product in _context.Set<Product>()
                            on orderdetail.productId equals product.productId
                            join provider in _context.Set<Provider>()
                            on orders.providerId equals provider.providerId
                        
                        select new { orders.Fecha, product.name , provider.direction};

            return Ok(orderDetail); 
        }




        // PUT: api/OrderDetails1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailId)
            {
                return BadRequest();
            }

            _context.Entry(orderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(id))
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

        // POST: api/OrderDetails1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetail.Add(orderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderDetail", new { id = orderDetail.OrderDetailId }, orderDetail);
        }

        // DELETE: api/OrderDetails1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var orderDetail = await _context.OrderDetail.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _context.OrderDetail.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetail.Any(e => e.OrderDetailId == id);
        }
    }
}
