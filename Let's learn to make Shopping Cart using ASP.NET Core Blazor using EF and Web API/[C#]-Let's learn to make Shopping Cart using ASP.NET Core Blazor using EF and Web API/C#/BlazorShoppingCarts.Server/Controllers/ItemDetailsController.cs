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
    public class ItemDetailsController : ControllerBase
    {
        ShoppingDBContext _context = new ShoppingDBContext();

        // GET: api/ItemDetails
        [HttpGet]
        public IEnumerable<ItemDetails> GetItemDetails()
        {
            return _context.ItemDetails;
        }

        // GET:     /5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemDetails = await _context.ItemDetails.FindAsync(id);

            if (itemDetails == null)
            {
                return NotFound();
            }

            return Ok(itemDetails);
        }

        // PUT: api/ItemDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemDetails([FromRoute] int id, [FromBody] ItemDetails itemDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemDetails.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(itemDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemDetailsExists(id))
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

        // POST: api/ItemDetails
        [HttpPost]
        public async Task<IActionResult> PostItemDetails([FromBody] ItemDetails itemDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ItemDetails.Add(itemDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemDetails", new { id = itemDetails.ItemId }, itemDetails);
        }

        // DELETE: api/ItemDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemDetails = await _context.ItemDetails.FindAsync(id);
            if (itemDetails == null)
            {
                return NotFound();
            }

            _context.ItemDetails.Remove(itemDetails);
            await _context.SaveChangesAsync();

            return Ok(itemDetails);
        }

        private bool ItemDetailsExists(int id)
        {
            return _context.ItemDetails.Any(e => e.ItemId == id);
        }
    }
}