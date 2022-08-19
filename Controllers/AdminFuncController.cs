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
    public class AdminFuncController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly DatabaseContext _context;
        public AdminFuncController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpPost("addcat")]
        public async Task<ActionResult<Vegetable>> Postcat(Vegetable cat)
        {
            try
            {
                
                _context.Vegetables.Add(cat);

                
                await _context.SaveChangesAsync();

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("getcat")]
        public async Task<ActionResult<IEnumerable<Vegetable>>> Getcat()
        {
            return await _context.Vegetables.ToListAsync();
        }

        [HttpGet("getcou")]
        public async Task<ActionResult<IEnumerable<Courier>>> Getcou()
        {
            return await _context.Couriers.ToListAsync();
        }
        [HttpGet("getorder")]
        public async Task<ActionResult<IEnumerable<Order>>> Getorder()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpDelete("delcat/{id}")]
        public async Task<IActionResult> DeleteCat(int id)
        {
            var veg = await _context.Vegetables.FindAsync(id);
            
            _context.Vegetables.Remove(veg);
            await _context.SaveChangesAsync();

            return StatusCode(202);
        }


        [HttpGet("getadmin/{id}")]
        public async Task<ActionResult<IEnumerable<Admin>>> Getadmins(int id)
        {
            return await _context.Admins.Where(s => s.AdminId.Equals(id)).ToListAsync();
        }

        [HttpGet("getorder/{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> Getorderid(int id)
        {
            return await _context.Orders.Where(s => s.OrderId.Equals(id)).ToListAsync();
        }

        [HttpGet("getorderbycus/{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> Getordercus(int id)
        {
            return await _context.Orders.Where(s => s.CustomerId.Equals(id)).ToListAsync();
        }

        [HttpGet("getcus/{id}")]
        public async Task<ActionResult<IEnumerable<Customer>>> Getcus(int id)
        {
            return await _context.Customers.Where(s => s.CustomerId.Equals(id)).ToListAsync();
        }

        [HttpGet("getfarm/{id}")]
        public async Task<ActionResult<IEnumerable<Farmer>>> Getfarmer(int id)
        {
            return await _context.Farmers.Where(s => s.FarmerId.Equals(id)).ToListAsync();
        }


        [HttpPut("updatecat/{id}")]
        public async Task<ActionResult<Vegetable>> Putcat(int id,Vegetable cat)
        {
            try
            {
                {
                    var Entity = await _context.Vegetables.FindAsync(id);

                    

                    if (Entity.Name!=cat.Name) { Entity.Name = cat.Name; Entity.Last_Updated_Time = cat.Last_Updated_Time; Entity.AdminId = cat.AdminId; }
                    if (Entity.Vegtable_image != cat.Vegtable_image) { Entity.Vegtable_image = cat.Vegtable_image; Entity.Last_Updated_Time = cat.Last_Updated_Time; Entity.AdminId = cat.AdminId; }
                    if (Entity.Max_control_price_country != cat.Max_control_price_country) { Entity.Max_control_price_country = cat.Max_control_price_country; Entity.Last_Updated_Time = cat.Last_Updated_Time; Entity.AdminId = cat.AdminId; }
                    

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
