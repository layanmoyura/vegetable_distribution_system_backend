using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_platform_for_vegetables.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_platform_for_vegetables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFuncController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public CustomerFuncController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet("customerveg")]
        public async Task<ActionResult<IEnumerable<Vegetable>>> Getbook()
        {
            return await _context.Vegetables.ToListAsync();
        }

        [HttpPost("customerorder")]
        public async Task<ActionResult<Order>> PostOrder(Order order )
        {
            try
            {

               
                var Entity = await _context.VegetableStocks.FindAsync(order.VegetableStocksId);
                
               
                {
                    Entity.Amount = Entity.Amount - order.required_amount_kg;


                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();
                    return StatusCode(202);

                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("farmer/{id}")]
        public async Task<ActionResult<IEnumerable<Farmer>>> Getfamerk(int id)
        {
            return await _context.Farmers.Where(s => s.FarmerId.Equals(id)).ToListAsync();
        }


        //by category
        [HttpGet("customervegetablestockbycat/{bycategory}")]
        public async Task<ActionResult<IEnumerable<VegetableStock>>> Getvegestock(int bycategory)
        {
            return await _context.VegetableStocks.Where(s => s.VegetablesId == bycategory).ToListAsync();
        }

        //all products
        [HttpGet("customervegetablestockall")]
        public async Task<ActionResult<IEnumerable<VegetableStock>>> Getallstock()
        {
            return await _context.VegetableStocks.ToListAsync();
        }



        [HttpPost("customerpayment")]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            try
            {
                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        [HttpPut("customerdetedit")]

        public async Task<ActionResult> Update(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }
            try
            {
                var Entity = await _context.Customers.FindAsync(id);
                if (!string.IsNullOrEmpty(customer.FirstName)) { Entity.FirstName = customer.FirstName; }
                if (!string.IsNullOrEmpty(customer.LastName)) { Entity.LastName = customer.LastName; }
                if (!string.IsNullOrEmpty(customer.Living_City)) { Entity.Living_City = customer.Living_City; }
                if (!string.IsNullOrEmpty(customer.Profile_Photo)) { Entity.Profile_Photo = customer.Profile_Photo; }

                await _context.SaveChangesAsync();
                return StatusCode(202);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }


        
        [HttpGet("getcustomeredit/{id}")]
        public async Task<ActionResult<IEnumerable<Customer>>> Getcusdetails(int id)
        {
            return await _context.Customers.Where(s => s.CustomerId.Equals(id)).ToListAsync();
        }

        






    }
}

