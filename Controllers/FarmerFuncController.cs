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

    public class FarmerFuncController : Controller
    {
        private readonly DatabaseContext _context;
        public FarmerFuncController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost("addstock")]
        public async Task<ActionResult<VegetableStock>> PostOrder(VegetableStock stock)
        {
            try
            {
                var veg = await _context.Vegetables.FindAsync(stock.VegetablesId);

                if(veg.Max_control_price_country > stock.Farmers_price_per_kg)
                {
                    _context.VegetableStocks.Add(stock);
                    await _context.SaveChangesAsync();

                    return StatusCode(201);
                }

                else
                {
                    return StatusCode(411);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<ActionResult> Update(int id, Farmer farmer)
        {
            if (id != farmer.FarmerId)
            {
                return BadRequest();
            }
            try
            {
                var Entity = await _context.Farmers.FindAsync(id);
                if (!string.IsNullOrEmpty(farmer.Name)) { Entity.Name = farmer.Name; }
                if (!string.IsNullOrEmpty(farmer.Living_city)) { Entity.Living_city = farmer.Living_city; }
                if (!string.IsNullOrEmpty(farmer.Bank)) { Entity.Bank = farmer.Bank; }
                if (!string.IsNullOrEmpty(farmer.Profile_Photo)) { Entity.Profile_Photo = farmer.Profile_Photo; }
                if(!string.IsNullOrEmpty(farmer.Account_no)) { Entity.Account_no = farmer.Account_no; }
                if(!string.IsNullOrEmpty(farmer.NIC_No)){ Entity.NIC_No = farmer.NIC_No; }

                await _context.SaveChangesAsync();
                return StatusCode(202);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        private bool FarmerExists(int id)
        {
            return _context.Farmers.Any(e => e.FarmerId == id);
        }



        [HttpGet("getfarmeredit/{id}")]
        public async Task<ActionResult<IEnumerable<Farmer>>> Getfarmdetails(int id)
        {
            return await _context.Farmers.Where(s => s.FarmerId.Equals(id)).ToListAsync();
        }

        [HttpGet("getfarmerorder/{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> Getfarmorder(int id)

        {
            
            return await _context.Orders.Where(s => s.FarmerId.Equals(id) && s.Supplied_or_not==false).ToListAsync();
        }

        [HttpGet("getfarmerprod/{id}")]
        public async Task<ActionResult<IEnumerable<VegetableStock>>> Getfarmprods(int id)
        {
            return await _context.VegetableStocks.Where(s => s.FarmerId.Equals(id)).ToListAsync();
        }

        [HttpDelete("delprod/{id}")]
        public async Task<IActionResult> Deleteprod(int id)
        {
            var veg = await _context.VegetableStocks.FindAsync(id);

            _context.VegetableStocks.Remove(veg);
            await _context.SaveChangesAsync();

            return StatusCode(202);
        }



       

        [HttpGet("getcat/{id}")]
        public async Task<ActionResult<IEnumerable<Vegetable>>> Getcat(int id)
        {
            return await _context.Vegetables.Where(s => s.VegetablesId.Equals(id)).ToListAsync();
        }

        [HttpGet("getstock/{id}")]
        public async Task<ActionResult<IEnumerable<VegetableStock>>> Getstocks(int id)
        {
            return await _context.VegetableStocks.Where(s => s.VegetableStocksId.Equals(id)).ToListAsync();
        }


        [HttpGet("getstockimg/{id}")]
        public async Task<ActionResult<IEnumerable<VegetableStock>>> Getstocksimg(int id)
        {
            var Entity = await _context.VegetableStocks.FindAsync(id);
            return Content(Entity.Stock_image);
        }

        [HttpPut("putorder/{id}")]
        public async Task<ActionResult<Order>> Putord(int id,Order order)
        {
            try
            {
                {
                    var Entity = await _context.Orders.FindAsync(id);



                    if (Entity.progress == 0) { Entity.progress = order.progress; }
                    if (Entity.Supplied_or_not == false) { Entity.Supplied_or_not = order.Supplied_or_not; }



                    await _context.SaveChangesAsync();
                    return StatusCode(202);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








    }
}
