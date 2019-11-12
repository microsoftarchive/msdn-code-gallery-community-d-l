using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorShoppingCarts.Shared.Models;

namespace BlazorShoppingCarts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingDetailsController : ControllerBase
    {
        ShoppingDBContext _context = new ShoppingDBContext();



        // GET: api/ShoppingDetails
        //[HttpGet]
        //public IEnumerable<ShoppingDetails> GetShoppingDetails()
        //{
        //    return _context.ShoppingDetails;
        //}
        [HttpGet]
        public IEnumerable<myShopping> GetShoppingDetails()
        {
            var results = (from items in _context.ItemDetails
                           join shop in _context.ShoppingDetails
                                on items.ItemId equals shop.ItemId
                           select new myShopping
                           {

                               ShopId = shop.ShopId,
                               ItemName = items.ItemName,
                               ImageName = items.ImageName,
                               UserName = shop.UserName,
                               Qty = shop.Qty,
                               TotalAmount = shop.TotalAmount,
                               Description = shop.Description,
                               ShoppingDate = shop.ShoppingDate
                      }).ToList();


            return results;
        }

        // GET: api/ShoppingDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shoppingDetails = await _context.ShoppingDetails.FindAsync(id);

            if (shoppingDetails == null)
            {
                return NotFound();
            }

            return Ok(shoppingDetails);
        }

        // PUT: api/ShoppingDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingDetails([FromRoute] int id, [FromBody] ShoppingDetails shoppingDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shoppingDetails.ShopId)
            {
                return BadRequest();
            }

            _context.Entry(shoppingDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingDetailsExists(id))
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

        // POST: api/ShoppingDetails
        [HttpPost]
        public async Task<IActionResult> PostShoppingDetails([FromBody] ShoppingDetails shoppingDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ShoppingDetails.Add(shoppingDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingDetails", new { id = shoppingDetails.ShopId }, shoppingDetails);
        }

        // DELETE: api/ShoppingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shoppingDetails = await _context.ShoppingDetails.FindAsync(id);
            if (shoppingDetails == null)
            {
                return NotFound();
            }

            _context.ShoppingDetails.Remove(shoppingDetails);
            await _context.SaveChangesAsync();

            return Ok(shoppingDetails);
        }

        private bool ShoppingDetailsExists(int id)
        {
            return _context.ShoppingDetails.Any(e => e.ShopId == id);
        }
    }
}